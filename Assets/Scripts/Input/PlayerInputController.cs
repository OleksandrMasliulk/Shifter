using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInputController : MonoBehaviour
{
    private PlayerController _palyer;

    private void Awake() {
        _palyer = GetComponent<PlayerController>();
    }

    private void MainMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        _palyer.HUDController.MainMenu();
    }

    private void Restart_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        _palyer.HUDController.Restart();
    }

    private void BlinkRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        _palyer.BlinkController.BlinkRight();
    }

    private void BlinkLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        _palyer.BlinkController.BlinkLeft();
    }

    private void Blink_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        _palyer.BlinkController.Blink(_palyer.MovementController.LastDirection);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        _palyer.MovementController.Jump();
    }

    private void Update() {
        Vector2 direction = new Vector2(InputController.Instance.GetInputMapper().Player.Movement.ReadValue<float>(), 0f);
        //if (direction.magnitude > 0f)
        _palyer.MovementController.Move(direction.normalized);
    }

    private void OnEnable() {
        InputController.Instance.GetInputMapper().Player.Jump.performed += Jump_performed;
        InputController.Instance.GetInputMapper().Player.Blink.performed += Blink_performed;
        InputController.Instance.GetInputMapper().Player.BlinkLeft.performed += BlinkLeft_performed;
        InputController.Instance.GetInputMapper().Player.BlinkRight.performed += BlinkRight_performed;
        InputController.Instance.GetInputMapper().Player.Restart.performed += Restart_performed;
        InputController.Instance.GetInputMapper().Player.MainMenu.performed += MainMenu_performed;
    } 

    private void OnDisable() {
        InputController.Instance.GetInputMapper().Player.Jump.performed -= Jump_performed;
        InputController.Instance.GetInputMapper().Player.Blink.performed -= Blink_performed;
        InputController.Instance.GetInputMapper().Player.BlinkLeft.performed -= BlinkLeft_performed;
        InputController.Instance.GetInputMapper().Player.BlinkRight.performed -= BlinkRight_performed;
        InputController.Instance.GetInputMapper().Player.Restart.performed -= Restart_performed;
        InputController.Instance.GetInputMapper().Player.MainMenu.performed -= MainMenu_performed;
    }
}
