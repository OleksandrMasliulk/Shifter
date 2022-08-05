using UnityEngine;

public class SpikeTrap : Trap {
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            player.Die();
    }
}
