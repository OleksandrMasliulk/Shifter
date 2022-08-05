using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour {
    public static InputController Instance { get; private set; }
    public enum InputMode {
        Player,
        UI
    }

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private EventSystem eSystem;

    private InputMapper inputMapper;
    [SerializeField] private InputMode _initialMode;
    [SerializeField] private UIPanel _activePanel;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        inputMapper = new InputMapper();
        SwitchInputMode(_initialMode);
    }

    private void OnBack() {
        _activePanel.OnBackEvent?.Invoke();
    }

    public void SetActivePanel(UIPanel panel) {
        _activePanel = panel;
    }

    public UIPanel GetActivePanel() {
        return _activePanel;
    }

    private void OnControlsChanged() {
        Debug.Log("New Device: " + playerInput.devices[0]);
    }

    public void SwitchInputMode(InputMode mode) {
        playerInput.SwitchCurrentActionMap(mode.ToString());

        switch (mode) {
            case InputMode.Player: {
                inputMapper.Player.Enable();
                inputMapper.UI.Disable();
                break;
            }
            case InputMode.UI: {
                inputMapper.Player.Disable();
                inputMapper.UI.Enable();
                break;
            }
        }
    }

    public InputMapper GetInputMapper() {
        return inputMapper;
    }

    public void SetSelectedObject(GameObject obj) {
        eSystem.SetSelectedGameObject(obj);
    }
}
