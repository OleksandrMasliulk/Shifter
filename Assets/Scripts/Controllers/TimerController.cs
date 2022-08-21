using UnityEngine;
using System;
using Zenject;

public class TimerController : MonoBehaviour { 
    public event Action OnTimeIsOut;

    private PlayerMovementController _playerMovement;
    private float _levelTime;
    public float AllocatedTime => _levelTime;
    private float _timeLeft;
    public float TimeLeft => _timeLeft;
    public float TimePassed => _levelTime - _timeLeft;
    private bool _isCounting;

    [Inject]
    public void Construct(PlayerMovementController playerMovement, float time) {   
        _levelTime = time;
        _playerMovement = playerMovement;
    }

    private void Awake() {
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

    private void StartCountdown() => _isCounting = true;

    public void StopCountdown() => _isCounting = false;

    private void TimeRanOut() {
        Debug.LogWarning("!!! TIME IS OUT !!!");
        OnTimeIsOut?.Invoke();
    }

    private void OnEnable() {
        _playerMovement.OnMove += OnPlayerStartedMove;
    }

    private void OnPlayerStartedMove(Vector2 dir, bool isGrounded) {
        StartCountdown();
        _playerMovement.OnMove -= OnPlayerStartedMove;
    }

    private void OnDisable() {
        _playerMovement.OnMove -= OnPlayerStartedMove;
    }
}
