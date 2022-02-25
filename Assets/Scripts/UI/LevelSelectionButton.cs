using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerData;
public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private int levelID;

    [SerializeField] private Text levelIDText;
    [SerializeField] private Text bestTimeText;
    [SerializeField] private Button button;

    private void Start()
    {
        InitVisual();
        InitButton();
    }

    private void InitVisual()
    {
        levelIDText.text = levelID.ToString();

        if (PlayerData.levelsDone.ContainsKey(levelID)) 
        {
            bestTimeText.text = FormatTime(PlayerData.levelsDone[levelID].time);
        }
    }

    private void InitButton()
    {
        if (levelID == 1)
        {
            button.interactable = true;
            button.onClick.AddListener(delegate { LevelController.Instance.LoadLevel(1); });

            return;
        }

        if (PlayerData.levelsDone.ContainsKey(levelID))
        {
            LevelData val;
            if (PlayerData.levelsDone.TryGetValue(levelID - 1, out val))
            {
                button.interactable = val.isCompleted;
                button.onClick.AddListener(delegate { LevelController.Instance.LoadLevel(levelID); });
            }
        }
    }

    private string FormatTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliSeconds = (time % 1) * 1000;

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
