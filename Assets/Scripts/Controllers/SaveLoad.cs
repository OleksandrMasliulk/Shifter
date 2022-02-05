using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerScore.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerProgress data = new PlayerProgress();

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Stats saved");
    }

    public static void Load()
    {
        string path = Application.persistentDataPath + "/playerScore.bin";
        Debug.Log(path);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerProgress data = formatter.Deserialize(stream) as PlayerProgress;
            stream.Close();

            PlayerData.levelsDone = data.levelsDone;
        }
        else
        {
            //PlayerData.levelsDone = new PlayerProgress().levelsDone;
            int levelsCount = SceneManager.sceneCountInBuildSettings;
            PlayerData.levelsDone = new Dictionary<int, bool>();
            for (int i = 1; i < levelsCount; i++)
            {
                PlayerData.levelsDone.Add(i, false);
            }

            Save();
            return;
        }

    }
}

[System.Serializable]
public class PlayerProgress
{
    public Dictionary<int, bool> levelsDone;

    public PlayerProgress()
    {
        levelsDone = new Dictionary<int, bool>();
        levelsDone = PlayerData.levelsDone;
    }
}