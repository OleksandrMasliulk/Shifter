using UnityEngine;
using TMPro;

public class WinPanel : UIPanel {
    [SerializeField] private TMP_Text _timeLeftText;
    [SerializeField] private TMP_Text _bestTimeText;
    [SerializeField] private TMP_Text _timeDifference;

    public override void ShowPanelDelayed(float delay) {
        InitPanel();
        base.ShowPanelDelayed(delay);
    }

    private void InitPanel() {
        _timeLeftText.text = Utils.FloatToTime(TimerController.Instance.TimeLeft);

        PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
        if (data == null)
            data = new PlayerData();
        if (data.LevelsProgression.ContainsKey(LevelLoader.Instance.CurrentLevel.Index))
        {
            _bestTimeText.text = Utils.FloatToTime(data.GetLevelTime(LevelLoader.Instance.CurrentLevel.Index));

            float delta = TimerController.Instance.TimeLeft - data.GetLevelTime(LevelLoader.Instance.CurrentLevel.Index);
            if (delta > 0) {
                _timeDifference.text = "+";
                _timeDifference.color = Color.green;
            }
            else {
                _timeDifference.text = "-";
                _timeDifference.color = Color.red;
            }
            _timeDifference.text += "" + Utils.FloatToTime(Mathf.Abs(delta));
        }
    }

    public void Restart() => LevelLoader.Instance.RestartCurrentLevel();

    public void MainMenu() => LevelLoader.Instance.LoadMainMenu();
}
