using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour {
    private const string GROUNDED = "Grounded";
    private const string JUMP = "Jump";
    private const string WALL = "Wall";
    private const string WALL_JUMP = "WallJump";
    private const string MOVING = "Moving";
    
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;
    private PlayerMovementController _playerMovement;

    private Transform _t;

    [Inject]
    public void Construct(PlayerMovementController playerMovement) {
        _playerMovement = playerMovement;
    } 

    private void Awake() {
        _t = GetComponent<Transform>();
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
        Vector3 newScale;
        if (direction.x < 0f)
            newScale = new Vector3(-1f, _t.localScale.y, _t.localScale.z);
        else
            newScale = new Vector3(1f, _t.localScale.y, _t.localScale.z);
        _t.localScale = newScale;
    }

    private void SetJump() {
        _animator.SetTrigger(JUMP);
    }

    private void SetWallJump() {
        _animator.SetTrigger(WALL_JUMP);
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
