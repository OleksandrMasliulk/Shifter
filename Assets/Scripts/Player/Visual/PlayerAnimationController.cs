using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour {
    [SerializeField] private SpriteRenderer _renderer;
    private PlayerController _player;

    private void Awake() {
        _player = GetComponent<PlayerController>();
    }

    private void SetDirection(Vector2 direction) {
        _renderer.flipX = direction.x < 0f;
    }

    private void SetJump() {
    }

    private void SetWallJump() {
    }

    private void OnEnable() {
        _player.MovementController.OnMove += SetDirection;
    }

    private void OnDisable() {
        _player.MovementController.OnMove -= SetDirection;
    }
}
