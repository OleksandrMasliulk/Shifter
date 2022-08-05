using UnityEngine;

public class FakePlatform : Trap {
    [SerializeField] private GameObject _fakeObject;
    [SerializeField] private float _timeBeforeBreak;
    private bool _isPlayerOnIt = false;
    private float _timeToBreak;

    private void Awake() => Reset();

    private void Update() {
        if (_timeToBreak <= 0f && _isPlayerOnIt)
            Break();
        else if (_isPlayerOnIt)
            _timeToBreak -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            _isPlayerOnIt = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            Reset();
    }

    private void Break() => Destroy(_fakeObject);

    private void Reset() {
        _isPlayerOnIt = false;
        _timeToBreak = _timeBeforeBreak;
    }
}
