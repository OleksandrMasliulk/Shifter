using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDied;

    [SerializeField] private PlayerMovementController _movementController;
    public PlayerMovementController MovementController => _movementController;
    [SerializeField] private PlayerBlinkController _blinkController;
    public PlayerBlinkController BlinkController => _blinkController;
    [SerializeField] private PlayerTimeBody _timeBody;
    public PlayerTimeBody TimeBody => _timeBody;
    [SerializeField] private PlayerAnimationController _animationController;
    public PlayerAnimationController AnimationController => _animationController;
    [SerializeField] private PlayerHUDController _hudController;
    public PlayerHUDController HUDController => _hudController;

    public bool IsAlive { get; private set; }

    private void Awake() {
        IsAlive = true;
    }


    public void Die() {
        Debug.LogWarning("!!!Player's dead!!!");
    
        IsAlive = false;
        OnPlayerDied?.Invoke();
    }

    private void OnEnable() => TimerController.Instance.OnTimeIsOut += Die;

    private void OnDisable() => TimerController.Instance.OnTimeIsOut -= Die;
}
