using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Timer timer;

    [SerializeField] private float showDelay;
    [SerializeField] private Text timeLeftText;
    [SerializeField] private Text bestTimeText;
    [SerializeField] private Text timeDelta;

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
        if (PlayerData.levelsDone.ContainsKey(SceneManager.GetActiveScene().buildIndex))
        {
            bestTimeText.text = FormatTime(PlayerData.levelsDone[SceneManager.GetActiveScene().buildIndex].time);

            float delta = timer.GetTime() - PlayerData.levelsDone[SceneManager.GetActiveScene().buildIndex].time;
            if (delta > 0)
            {
                timeDelta.text = "+";
                timeDelta.color = Color.green;
            }
            else
            {
                timeDelta.text = "-";
                timeDelta.color = Color.red;
            }
            timeDelta.text += ""+FormatTime(Mathf.Abs(delta));
        }
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

    private string FormatTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliSeconds = (time % 1) * 1000;

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    private void OnDestroy()
    {
        GameController.OnPlayerWin -= ShowPanel;
    }
}
