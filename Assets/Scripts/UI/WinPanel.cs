using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : UIPanel
{
    [SerializeField] private Text timeLeftText;
    [SerializeField] private Text bestTimeText;
    [SerializeField] private Text timeDelta;

    public override void ShowPanelDelayed(float delay)
    {
        InitPanel();
        base.ShowPanelDelayed(delay);
    }
    private void InitPanel()
    {
        timeLeftText.text = GameController.Instance.GetTimer().GetTimeAsString();
        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);

        if (data.levelsDone.ContainsKey(SceneManager.GetActiveScene().buildIndex))
        {
            bestTimeText.text = FormatTime(data.GetLevelTime(SceneManager.GetActiveScene().buildIndex));

            float delta = GameController.Instance.GetTimer().GetTime() - data.GetLevelTime(SceneManager.GetActiveScene().buildIndex);
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
}
