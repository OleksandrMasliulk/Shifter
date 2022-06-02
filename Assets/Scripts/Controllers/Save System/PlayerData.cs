using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Dictionary<int, LevelData> levelsDone;

    public PlayerData()
    {
        levelsDone = new Dictionary<int, LevelData>();
    }

    public float GetLevelTime(int levelIndex)
    {
        float levelTime = -1;

        if (levelsDone.ContainsKey(levelIndex))
        {
            levelTime = levelsDone[levelIndex].bestTime;
        }
        else
        {
            Debug.Log("No data found");
        }

        return levelTime;
    }

    [System.Serializable]
    public struct LevelData
    {
        public bool isCompleted;
        public float bestTime;

        public LevelData(bool _isCompleted, float _time)
        {
            isCompleted = _isCompleted;
            bestTime = _time;
        }
    }
}
