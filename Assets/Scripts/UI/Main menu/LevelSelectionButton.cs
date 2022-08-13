using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;

public class LevelSelectionButton : MonoBehaviour {
    [SerializeField] private TMP_Text _levelIndexText;
    [SerializeField] private TMP_Text _bestTimeText;
    [SerializeField] private Button _button;

    [SerializeField] private AssetReference _level;

    private void Awake() {
        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
        if (data == null)
            data = new PlayerData();
        var op = _level.LoadAssetAsync<LevelSO>();
        op.Completed += (op) => {
            InitVisual(data, op.Result);
            InitButton(op.Result);
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
}
