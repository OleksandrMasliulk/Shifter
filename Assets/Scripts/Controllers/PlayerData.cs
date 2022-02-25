using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static Dictionary<int, LevelData> levelsDone;

    [System.Serializable]
    public struct LevelData
    {
        public bool isCompleted;
        public float time;

        public LevelData(bool _isCompleted, float _time)
        {
            isCompleted = _isCompleted;
            time = _time;
        }
    }
}
