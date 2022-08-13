using UnityEngine;
using System;
using System.Threading.Tasks;

[RequireComponent(typeof(PlayerController), typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove {
    public event Action<Vector2, bool> OnMove;
    public event Action OnStopMove;
    public event Action OnJump;
    public event Action OnWallJump;

    private Rigidbody2D _rigidbody;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    private bool _canMove = true;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _walljumpAngle;
    [SerializeField] private float _walljumpForce;
    [SerializeField] private float _wallslideSpeed;
    [SerializeField] private float _walljumpControlImmunity;

    [Header("Collision check")]
    [SerializeField] private LayerChecker _groundCheck;
    public bool OnGround => _groundCheck.IsColliding;
    [SerializeField] private LayerChecker _wallCheck;
    public bool OnWall => _wallCheck.IsColliding;

    private Vector2 _lastDirection;
    public Vector2 LastDirection => _lastDirection;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    } 

    private void Update() {
        if (OnWall && _canMove)
            _rigidbody.velocity = new Vector2(0f, Mathf.Clamp(_rigidbody.velocity.y, _wallslideSpeed, float.MaxValue));
    }

    public void Jump() {
        if (OnGround) {
            GroundJump();
            return;
        }

        if (OnWall)
            WallJump();
    }

    private void GroundJump() {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        OnJump?.Invoke();
    }

    private async void WallJump() {
        Vector2 direction = new Vector2(-_lastDirection.x, _walljumpAngle * Mathf.Deg2Rad).normalized;
        Debug.DrawLine(transform.position, transform.position + (Vector3)direction, Color.red, 5f);
        _rigidbody.velocity = direction * _walljumpForce;
        OnWallJump?.Invoke();
        await WallJumpRecovery();
    }

    private async Task WallJumpRecovery() {
        _canMove = false;
        await Task.Delay((int)(_walljumpControlImmunity * 1000));
        _canMove = true;
    }

    public void Move(Vector2 direction) {
        if (direction.magnitude < .01f || !_canMove) {
            OnStopMove?.Invoke();
            return;
        }

        _rigidbody.velocity = new Vector2(_moveSpeed * direction.x, _rigidbody.velocity.y);
        _lastDirection = direction;
        OnMove?.Invoke(direction, OnGround);
    }
}
