using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public delegate void CameraZoomedIn();
    public static event CameraZoomedIn OnCameraZoomedIn;

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

        LevelStart();
    }

    private void LevelStart()
    {
        StartCoroutine(ZoomIn());
    }

    IEnumerator ZoomIn()
    {
        float startSize = cinemachineCam.m_Lens.OrthographicSize;
        float finalSize = 6.5f;
        float time = 2f;
        float currTime = 0f;

        while (currTime <= time)
        {
            cinemachineCam.m_Lens.OrthographicSize = Mathf.Lerp(startSize, finalSize, currTime / time);

            currTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        OnCameraZoomedIn?.Invoke();
    }

    private void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDisable()
    {
        Player.OnPlayerDied -= Lose;
    }
}
