using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public delegate void PlayerWin();
    public static event PlayerWin OnPlayerWin;

    [SerializeField] private float timeForLevel;
    [SerializeField] private WinPanel winPanel;

    //[SerializeField] private CinemachineVirtualCamera cinemachineCam;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        PlayerController.OnPlayerDied += Lose;

        TimerController.Instance.Init(timeForLevel);
    }

    private void Lose()
    {
        Restart();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win()
    {
        InputController.Instance.SwitchInputMode(InputController.InputMode.UI);
        winPanel.ShowPanelDelayed(1f);

        HandleBestLevelTime();
        OnPlayerWin?.Invoke();
    }

    private void HandleBestLevelTime() 
    {
        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
        if (data == null)
        {
            data = new PlayerData();
        }

        float time = TimerController.Instance.GetTime();
        if (data.levelsDone.ContainsKey(SceneManager.GetActiveScene().buildIndex))
        {
            float bestTime = data.GetLevelTime(SceneManager.GetActiveScene().buildIndex);
            if (bestTime < time)
            {
                data.levelsDone[SceneManager.GetActiveScene().buildIndex] = new PlayerData.LevelData(true, time);
                SaveLoad.Save(data, SaveLoad.levelsDataPath);
            }
        }
        else
        {
            data.levelsDone.Add(SceneManager.GetActiveScene().buildIndex, new PlayerData.LevelData(true, time));
            SaveLoad.Save(data, SaveLoad.levelsDataPath);
        }

        TestJson(data.levelsDone[SceneManager.GetActiveScene().buildIndex].bestTime);
    }

    private void TestJson(float time)
    {
        SavePackage package = new SavePackage("PlayerName", SceneManager.GetActiveScene().buildIndex, time);
        string json = SaveLoad.ToJson<SavePackage>(package);
        File.WriteAllText(Application.persistentDataPath + "/TestJson_" + package.levelIndex + ".json", json);
        Debug.Log(json);
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= Lose;
    }
}
