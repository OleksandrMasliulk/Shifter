using System.Collections.Generic;

[System.Serializable]
public class LevelProgress {
    private Dictionary<int, LevelProgressData> _gameProgress;

    public LevelProgress() {
        _gameProgress = new Dictionary<int, LevelProgressData>();
    }

    private void AddRecord(int level, LevelProgressData levelData) {
        if (_gameProgress.ContainsKey(level))
            throw new System.Exception($"Game Progress dictionary already contains {level} key.");

        _gameProgress.Add(level, levelData);
    }  

    public void ModifyRecord(int level, bool isCompleted, float time) {
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

    public bool TryGetLevelData(int key, out LevelProgressData levelProgressData) {
        if (_gameProgress.ContainsKey(key)) {
            levelProgressData = _gameProgress[key];
            return true;
        }
        else {
            levelProgressData = null;
            return false;
        }
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
