using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private int levelID;

    [SerializeField] private Text levelIDText;
    [SerializeField] private Button button;

    private void Start()
    {
        InitVisual();
        InitButton();
    }

    private void InitVisual()
    {
        levelIDText.text = levelID.ToString();
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
            bool val;
            if (PlayerData.levelsDone.TryGetValue(levelID - 1, out val))
            {
                button.interactable = val;
                button.onClick.AddListener(delegate { LevelController.Instance.LoadLevel(levelID); });
            }
        }
    }
}
