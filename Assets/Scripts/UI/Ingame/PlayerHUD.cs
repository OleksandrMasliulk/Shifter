using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    private void Start()
    {
        GameController.OnPlayerWin += HideHUD;
    }

    public void Restart()
    {
        LevelController.Instance.RestartCurrentLevel();
    }

    public void MainMenu()
    {
        LevelController.Instance.LoadMainMenu();
    }

    public void ShowHUD()
    {
        gameObject.SetActive(true);
    }

    public void HideHUD()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameController.OnPlayerWin -= HideHUD;
    }
}
