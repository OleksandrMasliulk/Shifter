using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInputController : MonoBehaviour
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        AssignPlayerActions();
    }

    private void AssignPlayerActions()
    {
        InputController.Instance.GetInputMapper().Player.Jump.performed += Jump_performed;
        InputController.Instance.GetInputMapper().Player.Blink.performed += Blink_performed;
        InputController.Instance.GetInputMapper().Player.BlinkLeft.performed += BlinkLeft_performed;
        InputController.Instance.GetInputMapper().Player.BlinkRight.performed += BlinkRight_performed;
        InputController.Instance.GetInputMapper().Player.Restart.performed += Restart_performed;
        InputController.Instance.GetInputMapper().Player.MainMenu.performed += MainMenu_performed;
    } 

    private void MainMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        playerController.GetPlayerHUD().MainMenu();
    }

    private void Restart_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        playerController.GetPlayerHUD().Restart();
    }

    private void BlinkRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        playerController.GetPlayerBlinkHandler().BlinkRight();
    }

    private void BlinkLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        playerController.GetPlayerBlinkHandler().BlinkLeft();
    }

    private void Blink_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        playerController.GetPlayerBlinkHandler().Blink();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        playerController.GetPlayerMovementController().Jump();
    }

    private void Update()
    {
        Vector2 direction = new Vector2(InputController.Instance.GetInputMapper().Player.Movement.ReadValue<float>(), 0f);
        //if (direction.magnitude > 0f)
        playerController.GetPlayerMovementController().Move(direction.normalized);
    }

    private void OnDisable()
    {
        InputController.Instance.GetInputMapper().Player.Jump.performed -= Jump_performed;
        InputController.Instance.GetInputMapper().Player.Blink.performed -= Blink_performed;
        InputController.Instance.GetInputMapper().Player.BlinkLeft.performed -= BlinkLeft_performed;
        InputController.Instance.GetInputMapper().Player.BlinkRight.performed -= BlinkRight_performed;
        InputController.Instance.GetInputMapper().Player.Restart.performed -= Restart_performed;
        InputController.Instance.GetInputMapper().Player.MainMenu.performed -= MainMenu_performed;
    }
}
