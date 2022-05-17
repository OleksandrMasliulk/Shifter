using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameters))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public delegate void PlayerDied();
    public static event PlayerDied OnPlayerDied;

    private PlayerParameters parameters;
    private PlayerMovement movement;
    private PlayerBlink blinkHandler;
    private PlayerTimeBody timeBody;
    private PlayerGraphicsController graphics;
    [SerializeField] private PlayerHUD hud;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();
        movement = GetComponent<PlayerMovement>();
        timeBody = GetComponent<PlayerTimeBody>();
        graphics = GetComponent<PlayerGraphicsController>();
        blinkHandler = GetComponent<PlayerBlink>();

        Timer.OnTimeIsOut += Die;
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
    public PlayerMovement GetPlayerMovementController()
    {
        return movement;
    }

    public PlayerGraphicsController GetPlayerGraphicsController()
    {
        return graphics;
    }

    public PlayerParameters GetPlayerParameters()
    {
        return parameters;
    }

    public PlayerTimeBody GetPlayerTimeBody()
    {
        return timeBody;
    }

    public PlayerBlink GetPlayerBlinkHandler()
    {
        return blinkHandler;
    }

    public PlayerHUD GetPlayerHUD()
    {
        return hud;
    }

    private void OnDisable()
    {
        Timer.OnTimeIsOut -= Die;
    }
}
