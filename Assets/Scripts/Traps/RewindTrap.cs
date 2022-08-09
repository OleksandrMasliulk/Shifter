using UnityEngine;

public class RewindTrap : Trap {
    [SerializeField] private float _timeRewindValue;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<PlayerTimeBody>(out PlayerTimeBody player))
            Trigger(player);
    }

    private void Trigger(PlayerTimeBody target) {
        float rewindTime = Time.fixedTime - _timeRewindValue;
        if (target.GetPointInTime(rewindTime) != Vector3.zero) {
            target.transform.position = target.GetPointInTime(rewindTime);
            Deactivate();
        }
        else
            Debug.LogWarning("Point in time not found!");
    }

    private void Deactivate() {
        _renderer.color = Color.gray;
        Destroy(this);
    }
}
