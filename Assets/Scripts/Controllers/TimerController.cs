using UnityEngine;
using System;
using Zenject;

public class TimerController : MonoBehaviour { 
    public event Action OnTimeIsOut;

    private PlayerMovementController _playerMovement;
    private float _levelTime;

    private float _timeLeft;
    public float TimeLeft => _timeLeft;
    private bool _isCounting;

    [Inject]
    public void Construct(PlayerMovementController playerMovement, float time) {   
        _playerMovement = playerMovement;
        _levelTime = time;
    }

    private void Start() {
        _timeLeft = _levelTime;
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
        }
    }

    public void StartCountdown() => _isCounting = true;

    public void StopCountdown() => _isCounting = false;

    private void TimeRanOut() {
        Debug.LogWarning("!!! TIME IS OUT !!!");
        OnTimeIsOut?.Invoke();
    }

    private void OnEnable() {
        _playerMovement.OnMove += OnPlayerStartedMove;
    }

    private void OnPlayerStartedMove(Vector2 dir) {
        StartCountdown();
        _playerMovement.OnMove -= OnPlayerStartedMove;
    }

    private void OnDisable() {
        _playerMovement.OnMove -= OnPlayerStartedMove;
    }
}
