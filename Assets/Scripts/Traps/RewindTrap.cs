using UnityEngine;

public class RewindTrap : Trap {
    [SerializeField] private float _timeRewindValue;
    [SerializeField] private SpriteRenderer _renderer;

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            Trigger(player);
    }

    private void Trigger(PlayerController target) {
        float rewindTime = Time.fixedTime - _timeRewindValue;
        if (target.TimeBody.GetPointInTime(rewindTime) != Vector3.zero) {
            target.transform.position = target.TimeBody.GetPointInTime(rewindTime);
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
