using UnityEngine;

public class PlayerHUDController : MonoBehaviour {
    private void OnEnable() => GameController.Instance.OnPlayerWin += HideHUD;

    public void Restart() => LevelLoader.Instance.RestartCurrentLevel();

    public void MainMenu() => LevelLoader.Instance.LoadMainMenu();

    public void ShowHUD() => gameObject.SetActive(true);

    public void HideHUD() => gameObject.SetActive(false);

    private void OnDisable() => GameController.Instance.OnPlayerWin -= HideHUD;
}
