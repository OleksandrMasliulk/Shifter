using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizer : MonoBehaviour
{
    public delegate void PlayerEnter();
    public static event PlayerEnter OnPlayerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            OnPlayerEnter?.Invoke();
        }
    }
}
