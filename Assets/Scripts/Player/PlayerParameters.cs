using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameters : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private bool isAlive;
    public bool a_isAlive 
    {
        get 
        {
            return isAlive;
        }
        private set
        {
            SetIsAlive(value);
        }
    }

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    public float a_movementSpeed
    {
        get
        {
            return movementSpeed;
        }
        private set
        {
            SetMovementSpeed(value);
        }
    }

    [SerializeField] private float jumpForce;
    public float a_jumpForce
    {
        get
        {
            return jumpForce;
        }
        private set
        {
            SetJumpForce(value);
        }
    }

    [SerializeField] private float wallSlideSpeed;
    public float a_wallSlideSpeed
    {
        get
        {
            return wallSlideSpeed;
        }
        set
        {
            SetWallSlideSpeed(value);
        }
    }

    [SerializeField] private float wallJumpAngle;
    public float a_wallJumpAngle
    {
        get
        {
            return wallJumpAngle;
        }
        set
        {
            SetWallJumpAngle(value);
        }
    }

    [SerializeField] private float wallJumForce;
    public float a_wallJumpForce
    {
        get
        {
            return wallJumForce;
        }
        set
        {
            SetWallJumpForce(value);
        }
    }

    [SerializeField] private float blinkDistance;
    public float a_blinkDistance
    {
        get
        {
            return blinkDistance;
        }
        private set
        {
            SetBlinkDistance(value);
        }
    }

    public void SetMovementSpeed(float _newValue)
    {
        movementSpeed = _newValue;
    }

    public void SetJumpForce(float _newValue)
    {
        jumpForce = _newValue;
    }

    public void SetIsAlive(bool _newValue)
    {
        isAlive = _newValue;
    }

    public void SetBlinkDistance(float _newValue)
    {
        blinkDistance = _newValue;
    }

    public void SetWallSlideSpeed(float newValue)
    {
        wallSlideSpeed = newValue;
    }

    public void SetWallJumpAngle(float newValue)
    {
        wallJumpAngle = newValue;
    }

    public void SetWallJumpForce(float newValue)
    {
        wallJumForce = newValue;
    }
 }
