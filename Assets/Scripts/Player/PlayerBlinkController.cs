using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBlinkController : MonoBehaviour {
    private PlayerController _palyerController;

    [SerializeField] private float _blinkDistance;
    [SerializeField] private float _blinkCooldown;
    [SerializeField] private LayerMask obstacleLayer;
    private bool _canBlink;
    private float _timeToCD;

    private void Awake() {
        _palyerController = GetComponent<PlayerController>();
        _canBlink = true;
        _timeToCD = 0f;
    }

    private void Update() {
        if (_timeToCD > 0f)
            _timeToCD -= Time.deltaTime;
        else
            _canBlink = true;
    }

    public void Blink() {
        if (!_canBlink)
            return;

        Vector3 directon = new Vector3(_palyerController.AnimationController.GetGraphicsScale().x, 0f, 0f).normalized;
        transform.position = CalculateBlinkPosition(directon);
        _canBlink = false;
        _timeToCD = _blinkCooldown;
    }

    public void BlinkRight() {
        if (!_canBlink)
            return;

        transform.position = CalculateBlinkPosition(Vector3.right);
        _canBlink = false;
        _timeToCD = _blinkCooldown;
    }

    public void BlinkLeft() {
        if (!_canBlink)
            return;

        transform.position = CalculateBlinkPosition(Vector3.left);
        _canBlink = false;
        _timeToCD = _blinkCooldown;
    }

    private Vector3 CalculateBlinkPosition(Vector3 direction)  {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _blinkDistance, obstacleLayer);
        Debug.DrawLine(transform.position, transform.position + direction * _blinkDistance, Color.red, 5f);

        if (hit.collider == null)
            return transform.position + direction * _blinkDistance;
        else
            return hit.point;
    }
}
