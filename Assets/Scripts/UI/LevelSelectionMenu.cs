using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelectionMenu : UIPanel
{
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private GameObject selectButtonPrefab;

    public override void ShowPanel()
    {
        if (buttonsParent.childCount == 0)
            Init();

        base.ShowPanel();
    }

    private void Init()
    {
        int levelsCount = SceneManager.sceneCountInBuildSettings;

        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
        if (data == null)
        {
            data = new PlayerData();
        }

        for (int i = 1; i < levelsCount; i++)
        {
            LevelSelectionButton button = Instantiate(selectButtonPrefab, buttonsParent).GetComponent<LevelSelectionButton>();
            button.Init(data, i);
        }
    }

    public void SelectFirstButton()
    {
        InputController.Instance.SetSelectedObject(buttonsParent.GetChild(0).gameObject);
    }
}
