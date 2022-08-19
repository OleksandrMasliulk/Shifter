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
         if (_playerData == null) {
             _playerData = new PlayerData();
             SaveLoad.Save<PlayerData>(_playerData, SaveLoad.levelsDataPath);
         }
    }

    public void HandleBestTime(float time) {
        float currentTime = time;
        if (!_playerData._levelProgress.TryGetLevelData(_levelController.CurrentLevel.Index, out LevelProgressData data)) {
            _playerData._levelProgress.ModifyRecord(_levelController.CurrentLevel.Index, true, currentTime);
            SaveLoad.Save<PlayerData>(_playerData, SaveLoad.levelsDataPath);
            return;
        }
        else if (currentTime < data.time) {
            _playerData._levelProgress.ModifyRecord(_levelController.CurrentLevel.Index, true, currentTime);  
            SaveLoad.Save<PlayerData>(_playerData, SaveLoad.levelsDataPath);   
        }  
    }
}
