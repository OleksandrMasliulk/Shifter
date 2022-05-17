using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputController : MonoBehaviour
{
    [SerializeField]private UIPanel activeUIPanel;

    private void Start()
    {
        AssignUIActions();
    }

    private void AssignUIActions()
    {
        InputController.Instance.GetInputMapper().UI.Submit.performed += Submit_performed;
        InputController.Instance.GetInputMapper().UI.Back.performed += Back_performed;
        InputController.Instance.GetInputMapper().UI.ScrollDown.performed += ScrollDown_performed;
        InputController.Instance.GetInputMapper().UI.ScrollUp.performed += ScrollUp_performed;
    }

    private void ScrollUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        activeUIPanel.ScrollUp();
    }

    private void ScrollDown_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        activeUIPanel.ScrollDown();
    }

    private void Back_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("BACK");
        activeUIPanel.Back();
    }

    private void Submit_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        activeUIPanel.Submit();
    }

    public void SetActiveUIPanel(UIPanel panel)
    {
        activeUIPanel = panel;
    }

    private void OnDisable()
    {
        InputController.Instance.GetInputMapper().UI.Submit.performed -= Submit_performed;
        InputController.Instance.GetInputMapper().UI.Back.performed -= Back_performed;
        InputController.Instance.GetInputMapper().UI.ScrollDown.performed -= ScrollDown_performed;
        InputController.Instance.GetInputMapper().UI.ScrollUp.performed -= ScrollUp_performed;
    }
}
