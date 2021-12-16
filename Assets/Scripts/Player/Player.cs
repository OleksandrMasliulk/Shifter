using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameters))]
public class Player : MonoBehaviour
{
    //public static Player Instance { get; private set; }

    public delegate void PlayerDied();
    public static event PlayerDied OnPlayerDied;

    private PlayerParameters parameters;

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    else
    //    {
    //        Destroy(this);
    //    }
    //}

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();

        Timer.OnTimeIsOut += Die;
        GameController.OnCameraZoomedIn += AwakePlayer;
    }

    private void AwakePlayer()
    {
        parameters.SetIsAlive(true);
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
        GameController.OnCameraZoomedIn -= AwakePlayer;
    }
}
