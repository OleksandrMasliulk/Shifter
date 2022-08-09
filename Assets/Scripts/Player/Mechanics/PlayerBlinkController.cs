using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBlinkController : MonoBehaviour {
    [SerializeField] private float _blinkDistance;
    [SerializeField] private float _blinkCooldown;
    [SerializeField] private LayerMask _obstacleLayer;
    private bool _canBlink;
    private float _timeToCD;

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

        transform.position = CalculateBlinkPosition(direction);
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
