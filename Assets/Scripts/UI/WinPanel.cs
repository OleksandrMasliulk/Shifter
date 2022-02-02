using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Timer timer;

    [SerializeField] private float showDelay;
    [SerializeField] private Text timeLeftText;

    [SerializeField] private Button nextButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mmenuButton;

    private void Start()
    {
        GameController.OnPlayerWin += ShowPanel;
        nextButton.onClick.AddListener(GameController.Instance.NextLevel);
        retryButton.onClick.AddListener(GameController.Instance.Restart);
        mmenuButton.onClick.AddListener(delegate { LevelController.Instance.LoadLevel(0); });

        gameObject.SetActive(false);
    }

    private void InitPanel()
    {
        timeLeftText.text = timer.GetTimeAsString();
    }

    private void ShowPanel()
    {
        InitPanel();

        Invoke("ShowPanelCoroutine", showDelay);
    }

    private void ShowPanelCoroutine()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameController.OnPlayerWin -= ShowPanel;
    }
}
