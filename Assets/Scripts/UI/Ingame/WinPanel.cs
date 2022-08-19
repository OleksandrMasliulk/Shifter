using UnityEngine;
using TMPro;
using Zenject;

public class WinPanel : MonoBehaviour {
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _bestTimeText;
    [SerializeField] private TMP_Text _timeDifference;

    private TimerController _timeController;
    private LevelController _levelLoader;
    private PlayerDataHandler _dataHandler;

    [Inject]
    public void Construct(TimerController timeController, LevelController levelLoader, PlayerDataHandler dataHandler) {
        _timeController = timeController;
        _levelLoader = levelLoader;
        _dataHandler = dataHandler;
    }

    public void InitPanel() {
        _timeText.text = Utils.FloatToTime(_timeController.TimePassed);
        if (!_dataHandler.PlayerData._levelProgress.TryGetLevelData(_levelLoader.CurrentLevel.Index, out LevelProgressData data)) {
            _bestTimeText.text = Utils.FloatToTime(_timeController.TimePassed);
            _timeDifference.text = "";
        }
        else {
            _bestTimeText.text = Utils.FloatToTime(data.time);
            float delta = _timeController.TimePassed - data.time;
            if (delta > 0) {
                _timeDifference.text = "+";
                _timeDifference.color = Color.red;
            }
            else {
                _timeDifference.text = "-";
                _timeDifference.color = Color.green;
            }
            _timeDifference.text += Utils.FloatToTime(Mathf.Abs(delta));
        }
    }

    public void ShowPanel(float delay) {
        GetComponent<UIPanel>().ShowPanelDelayed(delay);
    }

    public void Restart() => _levelLoader.RestartCurrentLevel();
    
    public void MainMenu() => _levelLoader.LoadMainMenu();

    public void NextLevel() {
        var op = _levelLoader.CurrentLevel.NextLevel.LoadAssetAsync<LevelSO>();
        op.Completed += (op) => {
            _levelLoader.LoadLevel(op.Result, true, true);
        };
    }
}
