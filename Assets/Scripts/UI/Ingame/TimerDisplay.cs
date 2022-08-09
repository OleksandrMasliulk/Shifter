using UnityEngine;
using Zenject;
using TMPro;

public class TimerDisplay : MonoBehaviour {
    [SerializeField] private TMP_Text _indicatorText;
    private TimerController _timeController;

    [Inject]
    public void Construct(TimerController timeController) {
        _timeController = timeController;
    }

    private void Update() {
        _indicatorText.text = Utils.FloatToTime(_timeController.TimeLeft);
    }
}
