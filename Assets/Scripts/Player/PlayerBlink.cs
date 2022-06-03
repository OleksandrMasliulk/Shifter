using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBlink : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private float blinkDistance;

    [SerializeField] private LayerMask obstacleLayer;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void Blink()
    {
        Vector3 directon = new Vector3(playerController.GetPlayerGraphicsController().GetGraphicsScale().x, 0f, 0f).normalized;
        transform.position = CalculateBlinkPosition(directon);
    }

    public void BlinkRight()
    {
        transform.position = CalculateBlinkPosition(Vector3.right);
    }

    public void BlinkLeft()
    {
        transform.position = CalculateBlinkPosition(Vector3.left);
    }

    private Vector3 CalculateBlinkPosition(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, blinkDistance, obstacleLayer);
        Debug.DrawLine(transform.position, transform.position + direction * blinkDistance, Color.red, 5f);

        if (hit.collider == null)
        {
            return transform.position + direction * blinkDistance;
        }
        else
        {
            return hit.point;// - new Vector2(.5f, 0f) * playerController.GetPlayerGraphicsController().GetGraphicsScale().x;
        }
    }
}
