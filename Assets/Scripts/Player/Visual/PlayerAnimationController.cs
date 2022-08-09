using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour {
    [SerializeField] private SpriteRenderer _renderer;
    private PlayerMovementController _playerMovement;

    [Inject]
    public void Construct(PlayerMovementController playerMovement) {
        _playerMovement = playerMovement;
    } 

    private void SetDirection(Vector2 direction) {
        _renderer.flipX = direction.x < 0f;
    }

    private void SetJump() {
    }

    private void SetWallJump() {
    }

    private void OnEnable() {
        _playerMovement.OnMove += SetDirection;
    }

    private void OnDisable() {
        _playerMovement.OnMove -= SetDirection;
    }
}
