using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress {
    private struct LevelProgressData {
        public bool isCompleted;
        public float time;

        public LevelProgressData(bool isCompleted, float time) {
            this.isCompleted = isCompleted;
            this.time = time;
        }
    }

    private Dictionary<LevelSO, LevelProgressData> _gameProgress;

    public LevelProgress() {
        _gameProgress = new Dictionary<LevelSO, LevelProgressData>();
    }

    private void AddRecord(LevelSO level, LevelProgressData levelData) {
        if (_gameProgress.ContainsKey(level))
            throw new System.Exception($"Game Progress dictionary already contains {level} key.");

        _gameProgress.Add(level, levelData);
    }  

    public void ModifyRecord(LevelSO level, bool isCompleted, float time) {
        if (_gameProgress.TryGetValue(level, out LevelProgressData data)) {
            data.isCompleted = isCompleted;
            data.time = time;
        }
        else
            AddRecord(level, new LevelProgressData(isCompleted, time));
    } 
}
