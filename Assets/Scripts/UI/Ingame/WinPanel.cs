using UnityEngine;
using TMPro;
using Zenject;

public class WinPanel : MonoBehaviour {
    [SerializeField] private TMP_Text _timeLeftText;
    [SerializeField] private TMP_Text _bestTimeText;
    [SerializeField] private TMP_Text _timeDifference;

    private TimerController _timeController;
    private LevelLoader _levelLoader;

    [Inject]
    public void Construct(TimerController timeController, LevelLoader levelLoader) {
        _timeController = timeController;
        _levelLoader = levelLoader;
    }

    private void InitPanel() {
        _timeLeftText.text = Utils.FloatToTime(_timeController.TimeLeft);

        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
        if (data == null)
            data = new PlayerData();
        // if (data.LevelsProgression.ContainsKey(LevelLoader.Instance.CurrentLevel.Index))
        // {
        //     _bestTimeText.text = Utils.FloatToTime(data.GetLevelTime(LevelLoader.Instance.CurrentLevel.Index));

        //     float delta = _timeController.TimeLeft - data.GetLevelTime(LevelLoader.Instance.CurrentLevel.Index);
        //     if (delta > 0) {
        //         _timeDifference.text = "+";
        //         _timeDifference.color = Color.green;
        //     }
        //     else {
        //         _timeDifference.text = "-";
        //         _timeDifference.color = Color.red;
        //     }
        //     _timeDifference.text += "" + Utils.FloatToTime(Mathf.Abs(delta));
        // }
    }

    public void Restart() => _levelLoader.RestartCurrentLevel();
    
    public void MainMenu() => _levelLoader.LoadMainMenu();
}
