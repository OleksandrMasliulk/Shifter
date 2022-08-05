using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Transform graphicsTransform;

    public void SetGraphicsHorizontal(bool isRight)
    {
        Vector3 localScale = graphicsTransform.localScale;

        if (isRight)
        {
            localScale.x = 1;
        }
        else
        {
            localScale.x = -1;
        }
        graphicsTransform.localScale = localScale;
    }

    public void SwitchDirectionHorizontal()
    {
        Vector3 localScale = graphicsTransform.localScale;
        localScale.x *= -1;
        graphicsTransform.localScale = localScale;
    }

    public Vector3 GetGraphicsScale()
    {
        return graphicsTransform.localScale;
    }
}
