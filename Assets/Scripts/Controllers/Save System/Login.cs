using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] private UIPanel createProfileWindow;

    private void Start()
    {
        HandleLevelDataFile();

        if (LoadProfile())
        {
            LoadMainMenu();   
        }
        else
        {
            createProfileWindow.ShowPanel();
        }
    }

    private void HandleLevelDataFile() 
    {
        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
        if (data == null)
        {
            data = new PlayerData();
            SaveLoad.Save(data, SaveLoad.levelsDataPath);
        }
    }

    private bool LoadProfile()
    {
        PlayerProfile profile = SaveLoad.Load<PlayerProfile>(SaveLoad.playerProfileDataPath);

        if (profile == null)
        {
            return false;
        } 
        else
        {
            return true;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
