using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameters))]
public class Player : MonoBehaviour
{
    public delegate void PlayerDied();
    public static event PlayerDied OnPlayerDied;

    private PlayerParameters parameters;

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();

        Timer.OnTimeIsOut += Die;
        Stabilizer.OnPlayerEnter += SetUnactive;
    }

    private void SetUnactive()
    {
        parameters.SetIsAlive(false);
    }

    public void Die()
    {
        Debug.LogWarning("!!!Player's dread!!!");
        parameters.SetIsAlive(false);

        OnPlayerDied?.Invoke();
    }

    private void OnDisable()
    {
        Timer.OnTimeIsOut -= Die;
        Stabilizer.OnPlayerEnter -= SetUnactive;
    }
}
