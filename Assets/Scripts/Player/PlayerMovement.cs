using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IMove
{
    public delegate void StartMoving();
    public static event StartMoving OnStartMoving;

    private PlayerController playerController;
    private Rigidbody2D rb;

    [Header("Grouund Check")]
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckBounds;

    [Header("Wall Check")]
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Vector2 wallCheckBounds;


    private float lastDirection;

    private void Start()
    {
        playerController = GetComponent < PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (WallCheck())
        {
            rb.velocity = new Vector2(0f, Mathf.Clamp(rb.velocity.y, playerController.GetPlayerParameters().a_wallSlideSpeed, float.MaxValue));
        }
    }

    public void Jump()
    {
        if (GroundCheck())
            rb.velocity = new Vector2(rb.velocity.x, playerController.GetPlayerParameters().a_jumpForce);

        if (WallCheck())
        {
            Vector2 direction = new Vector2(-playerController.GetPlayerGraphicsController().GetGraphicsScale().x, playerController.GetPlayerParameters().a_wallJumpAngle * Mathf.Deg2Rad).normalized;

            Debug.DrawLine(transform.position, transform.position + (Vector3)direction * playerController.GetPlayerParameters().a_jumpForce, Color.red, 5f);
            rb.velocity = direction * playerController.GetPlayerParameters().a_wallJumpForce;
            playerController.GetPlayerGraphicsController().SwitchDirectionHorizontal();
        }
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        transform.Translate(direction * playerController.GetPlayerParameters().a_movementSpeed * Time.deltaTime);
        //rb.velocity = new Vector2(direction.normalized.x * playerController.GetPlayerParameters().a_movementSpeed, rb.velocity.y);

        if (direction.x > 0f)
        {
            playerController.GetPlayerGraphicsController().SetGraphicsHorizontal(true);
        }
        else if (direction.x < 0f)
        {
            playerController.GetPlayerGraphicsController().SetGraphicsHorizontal(false);
        }

        OnStartMoving?.Invoke();
    }

    private bool GroundCheck()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(groundCheck.position, groundCheckBounds, 0, groundLayer);
        if (cols.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private bool WallCheck()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(wallCheck.position, wallCheckBounds, 0,  wallLayer);
        if (cols.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        //Ground Check circle
        Gizmos.DrawWireCube(groundCheck.position, groundCheckBounds);

        //Wall Check circle
        Gizmos.DrawWireCube(wallCheck.position, wallCheckBounds);
    }
}
