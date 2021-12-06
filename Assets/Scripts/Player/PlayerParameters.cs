using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameters : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private bool isAlive;

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float blinkDistance;

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

    public float GetBlinkDistance()
    {
        return blinkDistance;
    }
}
