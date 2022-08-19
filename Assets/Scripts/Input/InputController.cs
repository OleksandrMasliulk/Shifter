using UnityEngine;
using Zenject;

public class InputController : MonoBehaviour {
    public enum InputMode {
        Player,
        UI
    }

    private InputMapper _inputMapper;
    private GameController _gameController;

    [Inject] 
    public void Construct(InputMapper inputMapper) {
        _inputMapper = inputMapper;
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

    public void DisableAllInput() {
        _inputMapper.Player.Disable();
        _inputMapper.UI.Disable();
    }
}
