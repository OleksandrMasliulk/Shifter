using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using static PlayerData;
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public delegate void PlayerWin();
    public static event PlayerWin OnPlayerWin;

    [SerializeField] private Timer timer;

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
        OnPlayerWin?.Invoke();

        if (PlayerData.levelsDone.ContainsKey(SceneManager.GetActiveScene().buildIndex)) 
        {
            float timeLeft;
            if (PlayerData.levelsDone[SceneManager.GetActiveScene().buildIndex].time >= timer.GetTime())
            {
                timeLeft = PlayerData.levelsDone[SceneManager.GetActiveScene().buildIndex].time;
            }
            else
            {
                timeLeft = timer.GetTime();
            }
            PlayerData.levelsDone[SceneManager.GetActiveScene().buildIndex] = new LevelData(true, timeLeft);
        }

        SaveLoad.Save();
    }

    public Timer GetTimer()
    {
        return timer;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= Lose;
    }
}
