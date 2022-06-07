using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public const int scenesCountOffset = 2;

    public static LevelController Instance { get; private set; }
    public static int currentLevel
    { 
        get
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
    
    public static int levelsCount
    { 
        get
        {
            return SceneManager.sceneCountInBuildSettings;
        }
    }

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

    public void LoadLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
