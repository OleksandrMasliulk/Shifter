using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBlink : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private float blinkDistance;

    private bool canBlink;
    [SerializeField] private float blinkCD;
    private float timeToCD;

    [SerializeField] private LayerMask obstacleLayer;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();

        canBlink = true;
        timeToCD = 0f;
    }

    private void Update()
    {
        if (timeToCD > 0f)
        {
            timeToCD -= Time.deltaTime;
        }
        else
        {
            canBlink = true;
        }
    }

    public void Blink()
    {
        if (!canBlink)
            return;

        Vector3 directon = new Vector3(playerController.GetPlayerGraphicsController().GetGraphicsScale().x, 0f, 0f).normalized;
        transform.position = CalculateBlinkPosition(directon);

        canBlink = false;
        timeToCD = blinkCD;
    }

    public void BlinkRight()
    {
        if (!canBlink)
            return;

        transform.position = CalculateBlinkPosition(Vector3.right);

        canBlink = false;
        timeToCD = blinkCD;
    }

    public void BlinkLeft()
    {
        if (!canBlink)
            return;

        transform.position = CalculateBlinkPosition(Vector3.left);

        canBlink = false;
        timeToCD = blinkCD;
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
