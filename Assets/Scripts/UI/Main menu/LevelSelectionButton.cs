using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private Text levelIDText;
    [SerializeField] private Text bestTimeText;
    [SerializeField] private Button button;

    public void Init(PlayerData data, int levelIndex)
    {
        InitVisual(data, levelIndex);
        InitButton(data, levelIndex);
    }

    private void InitVisual(PlayerData data, int levelIndex)
    {
        levelIDText.text = (levelIndex - 1).ToString();

        if (data.levelsDone.ContainsKey(levelIndex)) 
        {
            bestTimeText.text = FormatTime(data.levelsDone[levelIndex].bestTime);
        }
    }

    private void InitButton(PlayerData data, int levelIndex)
    {
        if (levelIndex == LevelController.scenesCountOffset)
        {
            button.interactable = true;
            button.onClick.AddListener(delegate { LevelController.Instance.LoadLevel(LevelController.scenesCountOffset); });

            return;
        }

        if (data.levelsDone.ContainsKey(levelIndex - 1))
        {
            button.interactable = data.levelsDone[levelIndex - 1].isCompleted;
            button.onClick.AddListener(delegate { LevelController.Instance.LoadLevel(levelIndex); });
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
