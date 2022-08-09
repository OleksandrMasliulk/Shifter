using UnityEngine;
using Zenject;

public class InputController : MonoBehaviour {
    public enum InputMode {
        Player,
        UI
    }

    [SerializeField] private InputMode _initialMode;
    private InputMapper _inputMapper;

    [Inject] 
    public void Construct(InputMapper inputMapper) {
        _inputMapper = inputMapper;
    } 

    private void Awake() {
        SwitchInputMode(_initialMode);
    }

    public void SwitchInputMode(InputMode mode) {
        switch (mode) {
            case InputMode.Player: {
                SwitchModePlayer();
                break;
            }
            case InputMode.UI: {
                SwitchModeUI();
                break;
            }
        }
    }

    private void SwitchModeUI() {
        _inputMapper.Player.Disable();
        _inputMapper.UI.Enable();
    }

    private void SwitchModePlayer() {
        _inputMapper.Player.Enable();
        _inputMapper.UI.Disable();
    }
}
