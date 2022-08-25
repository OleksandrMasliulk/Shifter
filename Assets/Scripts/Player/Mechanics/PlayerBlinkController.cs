using UnityEngine;
using System;

[RequireComponent(typeof(PlayerController))]
public class PlayerBlinkController : MonoBehaviour, IRechargable {
    public event Action OnAfterBlink;
    public event Action OnBeforeBlink;

    [SerializeField] private float _blinkDistance;
    public float RechargeTime => _blinkCooldown;
    [SerializeField] private float _blinkCooldown;
    private float _timeToCD;
    public float TimeToRecharge => _timeToCD;
    private bool _canBlink;

    [SerializeField] private LayerMask _obstacleLayer;

    private void Awake() {
        _canBlink = true;
        _timeToCD = 0f;
    }

    private void Update() {
        if (_timeToCD > 0f)
            _timeToCD -= Time.deltaTime;
        else
            _canBlink = true;
    }

    public void Blink(Vector2 direction) {
        if (!_canBlink)
            return;

        OnBeforeBlink?.Invoke();
        transform.position = CalculateBlinkPosition(direction);
        OnAfterBlink?.Invoke();
        _canBlink = false;
        _timeToCD = _blinkCooldown;
    }

    public void BlinkRight() => Blink(Vector2.right);

    public void BlinkLeft() => Blink(Vector2.left);

    private Vector3 CalculateBlinkPosition(Vector3 direction)  {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _blinkDistance, _obstacleLayer);
        if (hit.collider == null)
            return transform.position + direction * _blinkDistance;
        else
            return hit.point;
    }
}
