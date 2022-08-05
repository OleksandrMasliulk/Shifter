using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    public Dictionary<int, LevelData> LevelsProgression {get; set;}

    public PlayerData() => LevelsProgression = new Dictionary<int, LevelData>();

    public float GetLevelTime(int level) {
        float levelTime = -1;

        if (LevelsProgression.ContainsKey(level))
            levelTime = LevelsProgression[level].bestTime;
        else
            Debug.Log("No data found");

        return levelTime;
    }

    [System.Serializable]
    public struct LevelData {
        public bool isCompleted;
        public float bestTime;

        public LevelData(bool _isCompleted, float _time) {
            isCompleted = _isCompleted;
            bestTime = _time;
        }
    }
}
