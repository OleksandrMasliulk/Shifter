using UnityEngine;
using Zenject;

public class MainMenu : MonoBehaviour {
    private InputController _inputController;
    
    [Inject]
    public void Construct(InputController inputController) {
        _inputController = inputController;
    }

    private void Start() {
        _inputController.SwitchInputMode(InputController.InputMode.UI);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
