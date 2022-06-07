using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        timeLeftText.text = Utils.FloatToTime(TimerController.Instance.GetTime());

        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
        if (data == null)
        {
            data = new PlayerData();
        }
        if (data.levelsDone.ContainsKey(LevelController.currentLevel))
        {
            bestTimeText.text = Utils.FloatToTime(data.GetLevelTime(LevelController.currentLevel));

            float delta = TimerController.Instance.GetTime() - data.GetLevelTime(LevelController.currentLevel);
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
            timeDelta.text += "" + Utils.FloatToTime(Mathf.Abs(delta));
        }
    }

    public void Restart()
    {
        LevelController.Instance.RestartCurrentLevel();
    }

    public void MainMenu()
    {
        LevelController.Instance.LoadMainMenu();
    }

    public void NextLevel()
    {
        Debug.Log("START");
        int nextLevelID;
        if (LevelController.levelsCount - 1 > LevelController.currentLevel)
        {
            nextLevelID = LevelController.currentLevel + 1;
        }
        else
        {
            return;
        }

        LevelController.Instance.LoadLevel(nextLevelID);
        Debug.Log("END");
    }
}
