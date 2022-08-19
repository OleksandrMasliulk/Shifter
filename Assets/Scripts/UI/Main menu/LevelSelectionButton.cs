using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;
using Zenject;

public class LevelSelectionButton : MonoBehaviour {
    [SerializeField] private TMP_Text _levelIndexText;
    [SerializeField] private TMP_Text _bestTimeText;
    [SerializeField] private Button _button;

    [SerializeField] private AssetReference _level;
    private LevelSO _loadedLevel;

    private LevelController _levelLoader;
    private PlayerDataHandler _playerData;

    [Inject]
    public void Construct(PlayerDataHandler playerDataHandler, LevelController levelController) {
        _playerData = playerDataHandler;
        _levelLoader = levelController;
    }

    private void Awake() {
        var op = _level.LoadAssetAsync<LevelSO>();
        op.Completed += (op) => {
            _loadedLevel = op.Result;
            InitVisual(_playerData.PlayerData, _loadedLevel);
            InitButton(_loadedLevel);
            _button.onClick.AddListener(() => _levelLoader.LoadLevel(_loadedLevel, true, true));
        };
    }

    private void InitVisual(PlayerData data, LevelSO levelData) {
        _levelIndexText.text = (levelData.Index).ToString();

        if (data._levelProgress.TryGetLevelData(levelData.Index, out LevelProgressData levelProgressData)) { 
             _bestTimeText.text = Utils.FloatToTime(levelProgressData.time);
        }
    }

    private async void InitButton(LevelSO levelData) {
        bool isUnlocked = await levelData.CheckIfUnlocked(_playerData.PlayerData);
        _button.interactable = isUnlocked;
    }

    private void OnDestroy() {
        _loadedLevel = null;
        _level.ReleaseAsset();
    }
}
