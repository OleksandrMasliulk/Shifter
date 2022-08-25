using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using Zenject;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class KeybindingsDisplayController : MonoBehaviour {
    public Action<KeybindingsRepositorySO> OnBindingsChanged;

    private const string PLAYER_BINDINGS = "playerBindings";
    private const string UI_BINDINGS = "uiBindings";
    private const string KEYBOARD_SCHEME = "Keyboard";
    private const string XBOX_SCHEME = "XboxController";
    private const string PS_SCHEME = "PS4Controller";

    [SerializeField] private AssetReference _keyboardBindings;
    [SerializeField] private AssetReference _xboxBindings;
    [SerializeField] private AssetReference _psBindings;
    [SerializeField] private string _defaultStyleOpen;
    [SerializeField] private string _defaultStyleClose;

    private PersistentVariablesSource _source;

    private PlayerInput _playerInput;
    private InputMapper _inputMapper;

    [Inject]
    public void Construcs(PlayerInput playerInput, InputMapper inputMapper) {
        _playerInput = playerInput;
        _inputMapper = inputMapper;
    }

    private void Awake() {
        _source = LocalizationSettings.StringDatabase.SmartFormatter.GetSourceExtension<PersistentVariablesSource>();
        OnControlsChanged(_playerInput);
    }

    private void OnControlsChanged(PlayerInput playerInput) {
        AssetReference loadRef = null;

        switch(_playerInput.currentControlScheme) {
            case KEYBOARD_SCHEME:
                loadRef = _keyboardBindings;
                break;
            case XBOX_SCHEME:
                loadRef = _xboxBindings;
                break;
            case PS_SCHEME:
                loadRef = _psBindings;
                break;
            default:
                loadRef = _keyboardBindings;
                break;
        }

        LoadRepo(loadRef).Completed += (op) => {
            SetupPlayerInput(op.Result);
            SetupUIInput(op.Result);
            OnBindingsChanged?.Invoke(op.Result);
        };
    } 

    private void SetupPlayerInput(KeybindingsRepositorySO keybindings) {
        SetGlobalStringVariable(PLAYER_BINDINGS, "mainmenu", ResolveSpriteTag(_inputMapper.Player.MainMenu, keybindings));
        SetGlobalStringVariable(PLAYER_BINDINGS, "retry", ResolveSpriteTag(_inputMapper.Player.Restart, keybindings));
    }

    private void SetupUIInput(KeybindingsRepositorySO keybindings) {

    }

    private string ResolveSpriteTag(InputAction action, KeybindingsRepositorySO repo) {
        if (repo.TryGetSprite(action.GetBindingControlPath(_playerInput.currentControlScheme), out string spriteTag, out string key))
            return spriteTag;
        else
            return _defaultStyleOpen + key.ToUpper() + _defaultStyleClose;
    }

    private void SetGlobalStringVariable(string group, string variable, string value){
        var bind = _source[group][variable] as StringVariable;
        bind.Value = value;
    }

    private AsyncOperationHandle<KeybindingsRepositorySO> LoadRepo(AssetReference reference) {
        AsyncOperationHandle op = reference.OperationHandle;
        if (op.IsValid())
            return op.Convert<KeybindingsRepositorySO>();
        else
            return reference.LoadAssetAsync<KeybindingsRepositorySO>();
    }

    private void OnEnable() {
        _playerInput.onControlsChanged += OnControlsChanged;
    }

    private void OnDisable() {
        _playerInput.onControlsChanged -= OnControlsChanged;
    }
}
