using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTrap : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private SpriteRenderer graphics;

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController player = collision.collider.GetComponent<PlayerController>();

        if (player != null)
        {
            Activate(player);
        }
    }

    private void Activate(PlayerController target)
    {
        float rewindTime = Time.fixedTime - time;
        if (target.GetPlayerTimeBody().GetPointInTime(rewindTime) != Vector3.zero)
        {
            target.transform.position = target.GetPlayerTimeBody().GetPointInTime(rewindTime);
            Deactivate();
        }
        else
            Debug.LogWarning("Point in time not found!");
    }

    private void Deactivate()
    {
        graphics.color = Color.gray;
        Destroy(this);
    }
}
