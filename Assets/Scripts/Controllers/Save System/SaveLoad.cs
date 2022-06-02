using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using static PlayerData;

public static class SaveLoad
{
    public const string levelsDataPath = "/levelsData.bin";
    public const string playerLoginData = "/loginData.bin";

    public static void Save<T>(T dataToSave, string savePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savePath;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, dataToSave);
        stream.Close();

        Debug.Log("Data of " + dataToSave.GetType().ToString() + " type is saved!");
    }

    public static T Load<T>(string loadPath)
    {
        string path = Application.persistentDataPath + loadPath;
        Debug.Log(path);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            T data = (T)formatter.Deserialize(stream);
            stream.Close();

            Debug.Log("Data of " + data.GetType().ToString() + " type is loaded!");
            return data;
        }
        else
        {
            Debug.Log("No data found at " + path + " path!");
            return default(T);
        }
    }

    public static string ToJson<T>(T dataToConvert)
    {
        string json = JsonUtility.ToJson(dataToConvert);
        return json;
    }
}