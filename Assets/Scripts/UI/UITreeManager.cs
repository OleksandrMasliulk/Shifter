using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Zenject;

public class UITreeManager : MonoBehaviour {
    public UIElement LastElement => _uiElementsStack.Peek();

    private EventSystem _eventSystem;
    private Stack<UIElement> _uiElementsStack;
    [SerializeField] private UIElement _rootElement;

    [Inject]
    public void Construct(EventSystem eventSystem) {
        _eventSystem = eventSystem;
    }

    private void Awake() {
        _uiElementsStack = new Stack<UIElement>();
        _uiElementsStack.Push(_rootElement);
    } 

    public void AddElementToStack(UIElement element) {
        if (_uiElementsStack.Contains(element))
            return;

        _uiElementsStack.Push(element);
        SetSelectedElement(_uiElementsStack.Peek());
    }

    public void RemoveLastElementFromStack() {
        if (LastElement == _rootElement)
            return;

        _uiElementsStack.Pop();
        SetSelectedElement(_uiElementsStack.Peek());
    }

    private void SetSelectedElement(UIElement element) {
        if (element is UIPanel panel) 
            _eventSystem.SetSelectedGameObject(panel.FirstSelected.gameObject);
        else
            _eventSystem.SetSelectedGameObject(element.gameObject);
    }
}
