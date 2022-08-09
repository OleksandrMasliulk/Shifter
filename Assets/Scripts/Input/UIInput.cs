using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class UIInput : MonoBehaviour {
    private InputMapper _inputMapper;
    private UITreeManager _uiTree;

    [Inject]
    public void Construct(InputMapper mapper, UITreeManager uiTree) {
        _inputMapper = mapper;
        _uiTree = uiTree;
    }

    private void OnBack(InputAction.CallbackContext context) {
        _uiTree.LastElement.Back();
    }

    private void OnSubmit(InputAction.CallbackContext context) {
        _uiTree.LastElement.Submit();
    } 

    private void OnEnable() {
        _inputMapper.UI.Back.performed += OnBack;
        _inputMapper.UI.Submit.performed += OnSubmit;
    }

    private void OnDisable() {
        _inputMapper.UI.Back.performed -= OnBack;
        _inputMapper.UI.Submit.performed -= OnSubmit;
    }
}
