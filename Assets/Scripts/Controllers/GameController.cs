using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using static PlayerData;
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public delegate void CameraZoomedIn();
    public static event CameraZoomedIn OnCameraZoomedIn;

    public delegate void PlayerWin();
    public static event PlayerWin OnPlayerWin;

    [SerializeField] private Timer timer;

    [SerializeField] private CinemachineVirtualCamera cinemachineCam;

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
        Player.OnPlayerDied += Lose;
        Stabilizer.OnPlayerEnter += Win;

        LevelStart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }
    }

    private void LevelStart()
    {
        //StartCoroutine(ZoomIn());
    }

    //IEnumerator ZoomIn()
    //{
    //   float startSize = cinemachineCam.m_Lens.OrthographicSize;
    //    float finalSize = 6.5f;
    //    float time = 2f;
    //    float currTime = 0f;

    //    while (currTime <= time)
    //    {
    //        cinemachineCam.m_Lens.OrthographicSize = Mathf.Lerp(startSize, finalSize, currTime / time);

    //        currTime += Time.deltaTime;
    //        yield return new WaitForSeconds(Time.deltaTime);
    //    }

    //    OnCameraZoomedIn?.Invoke();
    //}

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

    private void Lose()
    {
        Restart();
    }

    private void Win()
    {
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

    private void OnDisable()
    {
        Player.OnPlayerDied -= Lose;
        Stabilizer.OnPlayerEnter -= Win;
    }
}
