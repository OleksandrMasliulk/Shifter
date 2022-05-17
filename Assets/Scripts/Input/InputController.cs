using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public enum InputMode
    {
        Player,
        UI
    }

    public static InputController Instance { get; private set; }

    [SerializeField] private PlayerInput playerInput;

    private InputMapper inputMapper;
    [SerializeField] private InputMode initialMode;

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

        inputMapper = new InputMapper();
        SwitchInputMode(initialMode);
    }

    public void SwitchInputMode(InputMode mode)
    {
        playerInput.SwitchCurrentActionMap(mode.ToString());

        switch (mode)
        {
            case InputMode.Player:
            {
                inputMapper.Player.Enable();
                inputMapper.UI.Disable();
                break;
            }
            case InputMode.UI:
            {
                inputMapper.Player.Disable();
                inputMapper.UI.Enable();
                break;
            }
        }
    }

    public InputMapper GetInputMapper()
    {
        return inputMapper;
    }
}
