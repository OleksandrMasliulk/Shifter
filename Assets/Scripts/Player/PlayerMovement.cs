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

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    private bool canMove = true;

    [SerializeField] private float jumpForce;
    [SerializeField] private float wallJumpAngle;
    [SerializeField] private float wallJumpForce;
    [SerializeField] private float wallSlideSpeed;
    [SerializeField] private float wallJumpControlImmunity;

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
            rb.velocity = new Vector2(0f, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MaxValue));
        }
    }

    public void Jump()
    {
        if (GroundCheck())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (WallCheck())
        {
            Vector2 direction = new Vector2(-playerController.GetPlayerGraphicsController().GetGraphicsScale().x, wallJumpAngle * Mathf.Deg2Rad).normalized;

            Debug.DrawLine(transform.position, transform.position + (Vector3)direction * jumpForce, Color.red, 5f);
            rb.velocity = direction * wallJumpForce;
            playerController.GetPlayerGraphicsController().SwitchDirectionHorizontal();

            StopCoroutine(ReclaimControl());
            canMove = false;
            StartCoroutine(ReclaimControl());
        }
    }

    IEnumerator ReclaimControl()
    {
        yield return new WaitForSeconds(wallJumpControlImmunity);
        canMove = true;
    }

    public void Move(Vector2 direction)
    {
        if (direction.magnitude < .01f && !GroundCheck())
            return;

        if (canMove)
        {
            rb.velocity = new Vector2(movementSpeed * direction.x, rb.velocity.y);
            //transform.Translate(direction * movementSpeed * Time.deltaTime);
            //rb.velocity = new Vector2(direction.normalized.x * playerController.GetPlayerParameters().a_movementSpeed, rb.velocity.y);

            if (direction.x > 0f)
            {
                playerController.GetPlayerGraphicsController().SetGraphicsHorizontal(true);
            }
            else if (direction.x < 0f)
            {
                playerController.GetPlayerGraphicsController().SetGraphicsHorizontal(false);
            }

            if (direction.magnitude > 0f)
                OnStartMoving?.Invoke();
        }
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
