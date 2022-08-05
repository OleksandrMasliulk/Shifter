using UnityEngine;
using System;
using System.Collections;
using System.Threading.Tasks;

[RequireComponent(typeof(PlayerController), typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove {
    public static event Action OnStartMoving;

    private PlayerController _palyerController;
    private Rigidbody2D _rigidbody;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    private bool _canMove = true;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _walljumpAngle;
    [SerializeField] private float _walljumpForce;
    [SerializeField] private float _wallslideSpeed;
    [SerializeField] private float _walljumpControlImmunity;

    [Header("Ground Check")]
    [SerializeField]private LayerMask _groundLayer;
    [SerializeField]private Transform _groundCheck;
    [SerializeField] private Vector2 _groundCheckBounds;

    [Header("Wall Check")]
    [SerializeField] private LayerMask _wallLayer;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private Vector2 _wallCheckBounds;

    private float _lastDirection;

    private void Awake() {
        _palyerController = GetComponent < PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    } 

    private void Update() {
        if (WallCheck())
            _rigidbody.velocity = new Vector2(0f, Mathf.Clamp(_rigidbody.velocity.y, _wallslideSpeed, float.MaxValue));
    }

    public async void Jump() {
        if (GroundCheck())
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);

        if (WallCheck()) {
            Vector2 direction = new Vector2(-_palyerController.AnimationController.GetGraphicsScale().x, _walljumpAngle * Mathf.Deg2Rad).normalized;
            Debug.DrawLine(transform.position, transform.position + (Vector3)direction * _jumpForce, Color.red, 5f);
            _rigidbody.velocity = direction * _walljumpForce;
            _palyerController.AnimationController.SwitchDirectionHorizontal();

            _canMove = false;
            await Task.Delay((int)(_walljumpControlImmunity * 1000));
            _canMove = true;
        }
    }

    public void Move(Vector2 direction) {
        if (direction.magnitude < .01f && !GroundCheck())
            return;

        if (_canMove) {
            _rigidbody.velocity = new Vector2(_moveSpeed * direction.x, _rigidbody.velocity.y);

            if (direction.x > 0f)
                _palyerController.AnimationController.SetGraphicsHorizontal(true);
            else if (direction.x < 0f)
                _palyerController.AnimationController.SetGraphicsHorizontal(false);

            if (direction.magnitude > 0f)
                OnStartMoving?.Invoke();
        }
    }

    private bool GroundCheck() {
        Collider2D[] cols = Physics2D.OverlapBoxAll(_groundCheck.position, _groundCheckBounds, 0, _groundLayer);
        if (cols.Length > 0)
            return true;
        else
            return false;
    }
    
    private bool WallCheck() {
        Collider2D[] cols = Physics2D.OverlapBoxAll(_wallCheck.position, _wallCheckBounds, 0,  _wallLayer);
        if (cols.Length > 0)
            return true;
        else
            return false;
    }

    private void OnDrawGizmos() {
        //Ground Check circle
        Gizmos.DrawWireCube(_groundCheck.position, _groundCheckBounds);
        //Wall Check circle
        Gizmos.DrawWireCube(_wallCheck.position, _wallCheckBounds);
    }
}
