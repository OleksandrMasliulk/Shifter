using UnityEngine;
using Zenject;

public class PlayerHUDController : MonoBehaviour {
    private GameController _gameController;

    [Inject]
    public void Construct(GameController gameController) {
        _gameController = gameController;
    }

    public void Restart() => LevelLoader.Instance.RestartCurrentLevel();

    public void MainMenu() => LevelLoader.Instance.LoadMainMenu();

    public void ShowHUD() => gameObject.SetActive(true);

    public void HideHUD() => gameObject.SetActive(false);

    private void OnEnable() => _gameController.OnPlayerWin += HideHUD;
    
    private void OnDisable() => _gameController.OnPlayerWin -= HideHUD;
}
