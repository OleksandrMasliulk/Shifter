using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameters : MonoBehaviour
{
    [SerializeField] private bool isAlive;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public void SetMovementSpeed(float _newValue)
    {
        movementSpeed = _newValue;
    }

    public float GetJumpForce()
    {
        return jumpForce;
    }

    public void SetJumpForce(float _newValue)
    {
        jumpForce = _newValue;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }

    public void SetIsAlive(bool _newValue)
    {
        isAlive = _newValue;
    }
}
