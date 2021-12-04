using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameters), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerParameters parameters;
    private Rigidbody2D rb;

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
    }

    private void Move(int _direction)
    {
        transform.Translate(transform.right * _direction * parameters.GetMovementSpeed() * Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * parameters.GetJumpForce(), ForceMode2D.Impulse);
    }
}
