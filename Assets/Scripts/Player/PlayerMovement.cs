using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameters), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerParameters parameters;
    private Rigidbody2D rb;

    [SerializeField]private LayerMask mask;

    private bool isOnGround;
    private bool isOnWall;

    private float lastDirection;

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (parameters.GetIsAlive())
        {
            float direction = Input.GetAxisRaw("Horizontal");

            if (Mathf.Abs(direction) > 0)
            {
                Move((int)direction);
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            if (Input.GetButtonDown("Blink"))
            {
                Blink();
            }

            if (Mathf.Abs(direction) > 0)
            {
                lastDirection = direction;
                Debug.Log(lastDirection);
            }
        }
    }

    private void Move(int _direction)
    {
        NulifyVelocityX();
        transform.Translate(transform.right * _direction * parameters.GetMovementSpeed() * Time.deltaTime);
    }

    private void Jump()
    {
        if (isOnGround)
        {
            rb.AddForce(transform.up * parameters.GetJumpForce(), ForceMode2D.Impulse);
        }
        else if (isOnWall)
        {
            NulifyVelocityY();

            Vector2 dir = (Quaternion.Euler(0, 0f, 30f) * transform.up) * new Vector2(lastDirection, 1f);
            rb.AddForce(dir * parameters.GetJumpForce() * 1.5f, ForceMode2D.Impulse);

            lastDirection *= -1f;
        }
    }

    private void Blink()
    {
        float direction = lastDirection;
        if (Mathf.Abs(direction) != 1)
        {
            direction = 1;
        }

        Vector2 destination;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * direction, parameters.GetBlinkDistance(), mask);
        Debug.DrawLine(transform.position, transform.position + transform.right * direction * parameters.GetBlinkDistance(), Color.red, 3f);

        if (hit.collider != null)
        {
            destination = hit.point;
            Debug.Log(hit.collider.name);
        }
        else
        {
            destination = transform.position + transform.right * direction * parameters.GetBlinkDistance();
        }

        transform.position = destination;
    }

    public void SetIsOnGround(bool _newValue)
    {
        isOnGround = _newValue;
    }

    public void SetIsOnWall(bool _newValue)
    {
        isOnWall = _newValue;

        if (isOnWall)
        {
            StickToTheWall();
        }
        else
        {
            UnstickOffTheWall();
        }
    }

    private void StickToTheWall()
    {
        rb.gravityScale /= 4f;
    }

    private void UnstickOffTheWall()
    {
        rb.gravityScale *= 4f;
    }

    private void NulifyVelocityX()
    {
        if (Mathf.Abs(rb.velocity.x) > 0)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void NulifyVelocityY()
    {
        if (Mathf.Abs(rb.velocity.y) > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }
}
