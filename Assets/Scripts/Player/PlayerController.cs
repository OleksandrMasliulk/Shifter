using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDied;

    private PlayerMovementController _movementController;
    public PlayerMovementController MovementController => _movementController;
    private PlayerBlinkController _blinkController;
    public PlayerBlinkController BlinkController => _blinkController;
    private PlayerTimeBody _timeBody;
    public PlayerTimeBody TimeBody => _timeBody;
    private PlayerAnimationController _animationController;
    public PlayerAnimationController AnimationController => _animationController;
    [SerializeField] private PlayerHUDController _hudController;
    public PlayerHUDController HUDController => _hudController;

    public bool IsAlive { get; private set; }

    private void Awake() {
        _movementController = GetComponent<PlayerMovementController>();
        _timeBody = GetComponent<PlayerTimeBody>();
        _animationController = GetComponent<PlayerAnimationController>();
        _blinkController = GetComponent<PlayerBlinkController>();
        IsAlive = true;
    }

    private void OnEnable() {
        TimerController.Instance.OnTimeIsOut += Die;
    }

    public void Die() {
        Debug.LogWarning("!!!Player's dead!!!");
    
        IsAlive = false;
        OnPlayerDied?.Invoke();
    }

    private void OnDisable() => TimerController.Instance.OnTimeIsOut -= Die;
}
