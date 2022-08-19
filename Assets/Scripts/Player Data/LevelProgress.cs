using System.Collections.Generic;

[System.Serializable]
public class LevelProgress {
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
        if (_gameProgress.ContainsKey(level)) {
            if (_gameProgress.TryGetValue(level, out LevelProgressData data)) {
                data.isCompleted = isCompleted;
                data.time = time;
            }
            else
                AddRecord(level, new LevelProgressData(isCompleted, time));
        }
        else
            AddRecord(level, new LevelProgressData(isCompleted, time));
    } 

    public LevelProgressData GetLevelData(LevelSO key) {
        if (_gameProgress.ContainsKey(key))
            return _gameProgress[key];
        else
            return null;
    }
}

[System.Serializable]
public class LevelProgressData {
        public bool isCompleted;
        public float time;

        public LevelProgressData(bool isCompleted, float time) {
            this.isCompleted = isCompleted;
            this.time = time;
        }
    }
