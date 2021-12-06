using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameters))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Die()
    {
        Debug.LogWarning("!!!Player's dread!!!");
    }
}
