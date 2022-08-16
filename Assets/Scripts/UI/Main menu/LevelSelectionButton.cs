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

    private LevelLoader _levelLoader;

    [Inject]
    public void Construct(LevelLoader levelLoader) {
        _levelLoader = levelLoader;
    }

    private void Awake() {
        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
        if (data == null)
            data = new PlayerData();
        var op = _level.LoadAssetAsync<LevelSO>();
        op.Completed += (op) => {
            _loadedLevel = op.Result;
            InitVisual(data, _loadedLevel);
            InitButton(_loadedLevel);
            _button.onClick.AddListener(() => _levelLoader.LoadLevel(_loadedLevel));
        };
    }

    private void InitVisual(PlayerData data, LevelSO levelData) {
        _levelIndexText.text = (levelData.Index).ToString();

        // if (data.LevelsProgression.ContainsKey(levelData.Index)) 
        //     _bestTimeText.text = Utils.FloatToTime(data.LevelsProgression[levelData.Index].bestTime);
    }

    private async void InitButton(LevelSO levelData) {
        bool isUnlocked = await levelData.CheckIfUnlocked();
        if (isUnlocked)
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    private void OnDestroy() {
        _loadedLevel = null;
        _level.ReleaseAsset();
    }
}
