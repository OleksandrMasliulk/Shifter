using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TimerController : MonoBehaviour { 
    public static TimerController Instance { get; private set; }

    public event Action OnTimeIsOut;

    [SerializeField] private TMP_Text _indicatorText;
    [SerializeField] private float _levelTime;
    private float _timeLeft;
    public float TimeLeft => _timeLeft;
    private bool _isCounting;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void OnEnable() {
        //PlayerMovementController.OnStartMoving += StartCountdown;
        GameController.Instance.OnPlayerWin += StopCountdown;
    }

    public void Init() {
        _timeLeft = _levelTime;
        UpdateTimer(_timeLeft);
    }

    private void Update() {
        if (_isCounting) {
            if (_timeLeft > 0)
                _timeLeft -= Time.deltaTime;
            else {
                _timeLeft = 0f;
                _isCounting = false;
                TimeRanOut();
            }
            UpdateTimer(_timeLeft);
        }
    }

    public void StartCountdown() {
        _isCounting = true;
        //PlayerMovementController.OnStartMoving -= StartCountdown;
    }

    public void StopCountdown() => _isCounting = false;

    private void TimeRanOut() {
        Debug.LogWarning("!!! TIME IS OUT !!!");
        OnTimeIsOut?.Invoke();
    }

    private void UpdateTimer(float time) => _indicatorText.text = Utils.FloatToTime(time);

    private void OnDisable() => GameController.Instance.OnPlayerWin -= StopCountdown;
}
