using UnityEngine;
using Zenject;

public class PlayerDataHandler : MonoBehaviour {
    private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;

    private LevelController _levelController;

    [Inject]
    public void Construct(LevelController levelController) {
        _levelController = levelController;
    }

    private void Awake() {
         _playerData = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
         if (_playerData == null) 
             _playerData = new PlayerData();
    }

    public void HandleBestTime(float time) {
        float currentTime = time;
        LevelProgressData levelData = _playerData._levelProgress.GetLevelData(_levelController.CurrentLevel);
        if (levelData == null) {
            _playerData._levelProgress.ModifyRecord(_levelController.CurrentLevel, true, currentTime);
            SaveLoad.Save<PlayerData>(_playerData, SaveLoad.levelsDataPath);
            return;
        }
        else if (currentTime > levelData.time) {
            _playerData._levelProgress.ModifyRecord(_levelController.CurrentLevel, true, currentTime);  
            SaveLoad.Save<PlayerData>(_playerData, SaveLoad.levelsDataPath);   
        }  
    }
}
