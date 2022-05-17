using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private float showDelay;
    [SerializeField] private Text timeLeftText;
    [SerializeField] private Text bestTimeText;
    [SerializeField] private Text timeDelta;

    private void Start()
    {
        GameController.OnPlayerWin += ShowPanel;

        gameObject.SetActive(false);
    }

    private void InitPanel()
    {
        timeLeftText.text = GameController.Instance.GetTimer().GetTimeAsString();
        if (PlayerData.levelsDone.ContainsKey(SceneManager.GetActiveScene().buildIndex))
        {
            bestTimeText.text = FormatTime(PlayerData.levelsDone[SceneManager.GetActiveScene().buildIndex].time);

            float delta = GameController.Instance.GetTimer().GetTime() - PlayerData.levelsDone[SceneManager.GetActiveScene().buildIndex].time;
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        Debug.Log("START");
        int nextLevelID;
        if (SceneManager.sceneCountInBuildSettings - 1 > SceneManager.GetActiveScene().buildIndex)
        {
            nextLevelID = SceneManager.GetActiveScene().buildIndex + 1;
        }
        else
        {
            return;
        }

        LevelController.Instance.LoadLevel(nextLevelID);
        Debug.Log("END");
    }

    private void OnDestroy()
    {
        GameController.OnPlayerWin -= ShowPanel;
    }
}
