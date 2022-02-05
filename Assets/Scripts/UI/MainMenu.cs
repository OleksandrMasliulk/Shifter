using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private void Start()
    {
        SaveLoad.Load();
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            bool val;
            if (PlayerData.levelsDone.TryGetValue(i, out val))
            {
                Debug.Log("Level: " + i + ", " + val);
            };
        }

        playButton.onClick.AddListener(Contiunue);
    }

    public void Contiunue()
    {
        LevelController.Instance.LoadLevel(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
