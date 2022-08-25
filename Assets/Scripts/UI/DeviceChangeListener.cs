using Zenject;
using UnityEngine;
using TMPro;

public class DeviceChangeListener : MonoBehaviour {
    [SerializeField] private TMP_Text _text;
    
    private KeybindingsDisplayController _keybindingsDisplayController;

    [Inject]
    public void Construct(KeybindingsDisplayController keybindingsDisplayController) {
        _keybindingsDisplayController = keybindingsDisplayController;
    }

    private void ChangeSpriteAsset(KeybindingsRepositorySO repo) {
        _text.spriteAsset = repo.SpriteAsset;
    }

    private void OnEnable() {
        _keybindingsDisplayController.OnBindingsChanged += ChangeSpriteAsset;
    }

    private void OnDisable() {
        _keybindingsDisplayController.OnBindingsChanged -= ChangeSpriteAsset;
    }
}
