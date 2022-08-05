using UnityEngine;
using System;
using System.Threading.Tasks;

[RequireComponent(typeof(PlayerController), typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove {
    public event Action<Vector2> OnMove;

    private PlayerController _palyer;
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
    [SerializeField] private LayerChecker _wallCheck;

    private Vector2 _lastDirection;
    public Vector2 LastDirection => _lastDirection;

    private void Awake() {
        _palyer = GetComponent < PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    } 

    private void Update() {
        if (_wallCheck.IsColliding)
            _rigidbody.velocity = new Vector2(0f, Mathf.Clamp(_rigidbody.velocity.y, _wallslideSpeed, float.MaxValue));
    }

    public void Jump() {
        if (_groundCheck.IsColliding) {
            GroundJump();
            return;
        }

        if (_wallCheck.IsColliding)
            WallJump();
    }

    private void GroundJump() {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        //Invoke jump event
    }

    private async void WallJump() {
        Vector2 direction = new Vector2(-_lastDirection.x, _walljumpAngle * Mathf.Deg2Rad).normalized;
        _rigidbody.velocity = direction * _walljumpForce;
        //Invoke walljump event
        await WallJumpRecovery();
    }

    private async Task WallJumpRecovery() {
        _canMove = false;
        await Task.Delay((int)(_walljumpControlImmunity * 1000));
        _canMove = true;
    }

    public void Move(Vector2 direction) {
        if (direction.magnitude < .01f && _groundCheck.IsColliding)
            return;

        if (_canMove) {
            _rigidbody.velocity = new Vector2(_moveSpeed * direction.x, _rigidbody.velocity.y);
            _lastDirection = direction;
            if (direction.magnitude > 0f)
                OnMove?.Invoke(direction);
        }
    }
}
