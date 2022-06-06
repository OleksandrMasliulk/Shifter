using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public delegate void PlayerDied();
    public static event PlayerDied OnPlayerDied;

    private PlayerMovement movement;
    private PlayerBlink blinkHandler;
    private PlayerTimeBody timeBody;
    private PlayerGraphicsController graphics;
    [SerializeField] private PlayerHUD hud;

    public bool isAlive { get; private set; }

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
        isAlive = true;

        movement = GetComponent<PlayerMovement>();
        timeBody = GetComponent<PlayerTimeBody>();
        graphics = GetComponent<PlayerGraphicsController>();
        blinkHandler = GetComponent<PlayerBlink>();

        TimerController.OnTimeIsOut += Die;
    }

    private void SetUnactive()
    {
        SetIsAlive(false);
    }

    public void Die()
    {
        Debug.LogWarning("!!!Player's dread!!!");
        SetIsAlive(false);

        OnPlayerDied?.Invoke();
    }

    public void SetIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

    public PlayerMovement GetPlayerMovementController()
    {
        return movement;
    }

    public PlayerGraphicsController GetPlayerGraphicsController()
    {
        return graphics;
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
        TimerController.OnTimeIsOut -= Die;
    }
}
