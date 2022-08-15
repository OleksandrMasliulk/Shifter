using UnityEngine;
using Zenject;
using System.Threading.Tasks;

public class PlayerAnimationController : MonoBehaviour {
    private const string GROUNDED = "Grounded";
    private const string JUMP = "Jump";
    private const string WALL = "Wall";
    private const string WALL_JUMP = "WallJump";
    private const string MOVING = "Moving";
    
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;
    private PlayerMovementController _playerMovement;

    [SerializeField] private Transform _root;

    [Inject]
    public void Construct(PlayerMovementController playerMovement) {
        _playerMovement = playerMovement;
    } 

    private void Update() {
        SetGrounded(_playerMovement.OnGround);
        SetWall(_playerMovement.OnWall);
    }

    private void SetMoving(Vector2 direction, bool isGrounded) {
        _animator.SetBool(MOVING, true);
        SetDirection(direction);
    }

    private void StopMoving() {
        _animator.SetBool(MOVING, false);
    }

    private void SetGrounded(bool grounded) {
        _animator.SetBool(GROUNDED, grounded);
    }

    private void SetWall(bool wall) {
        _animator.SetBool(WALL, wall);
    }

    private void SetDirection(Vector2 direction) {
        _root.localScale = new Vector3(direction.normalized.x, 1f, 1f);
    }

    private void SwapDirection() {
        Vector3 newScale = new Vector3(-_root.localScale.x, _root.localScale.y, _root.localScale.z);
        _root.localScale = newScale;
    }

    private void SetJump() {
        _animator.SetTrigger(JUMP);
    }

    private async void SetWallJump() {
        _animator.SetTrigger(WALL_JUMP);
        await Task.Delay(10);

        SwapDirection();
    }

    private void OnEnable() {
        _playerMovement.OnMove += SetMoving;
        _playerMovement.OnStopMove += StopMoving;
        _playerMovement.OnJump += SetJump;
        _playerMovement.OnWallJump += SetWallJump;
    }

    private void OnDisable() {
        _playerMovement.OnMove -= SetMoving;
        _playerMovement.OnStopMove -= StopMoving;
        _playerMovement.OnJump -= SetJump;
        _playerMovement.OnWallJump -= SetWallJump;
    }
}
