using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameters), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerParameters parameters;
    private Rigidbody2D rb;

    [SerializeField]private LayerMask mask;

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
            Blink(direction);
        }
    }

    private void Move(int _direction)
    {
        transform.Translate(transform.right * _direction * parameters.GetMovementSpeed() * Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * parameters.GetJumpForce(), ForceMode2D.Impulse);
    }

    private void Blink(float _direction)
    {
        float direction = _direction;
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
}
