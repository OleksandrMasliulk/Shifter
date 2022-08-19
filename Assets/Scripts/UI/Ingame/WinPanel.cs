using UnityEngine;
using TMPro;
using Zenject;

public class WinPanel : MonoBehaviour {
    [SerializeField] private TMP_Text _timeLeftText;
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
        //_timeLeftText.text = Utils.FloatToTime(_timeController.TimeLeft);
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
