using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour {
    private InputMapper _inputMapper;
    private PlayerMovementController _movementController;
    private PlayerBlinkController _blinkController;

    [Inject]
    public void Construct(InputMapper inputMapper, PlayerMovementController movementController, PlayerBlinkController blinkController) {
        _inputMapper = inputMapper;
        _movementController = movementController;
        _blinkController = blinkController;
    } 

    private void BlinkRight(InputAction.CallbackContext obj) {
        _blinkController.BlinkRight();
    }

    private void BlinkLeft(InputAction.CallbackContext obj) {
        _blinkController.BlinkLeft();
    }

    private void Blink(InputAction.CallbackContext obj) {
        _blinkController.Blink(_movementController.LastDirection);
    }

    private void Jump(InputAction.CallbackContext obj) {
        _movementController.Jump();
    }

    private void Update() {
        Vector2 direction = new Vector2(_inputMapper.Player.Movement.ReadValue<float>(), 0f);
        _movementController.Move(direction.normalized);
    }

    private void OnEnable() {
        _inputMapper.Player.Jump.performed += Jump;
        _inputMapper.Player.Blink.performed += Blink;
        _inputMapper.Player.BlinkLeft.performed += BlinkLeft;
        _inputMapper.Player.BlinkRight.performed += BlinkRight;
    } 

    private void OnDisable() {
        _inputMapper.Player.Jump.performed -= Jump;
        _inputMapper.Player.Blink.performed -= Blink;
        _inputMapper.Player.BlinkLeft.performed -= BlinkLeft;
        _inputMapper.Player.BlinkRight.performed -= BlinkRight;
    }
}
