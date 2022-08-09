using UnityEngine;
using UnityEngine.Events;

public class UIElement : MonoBehaviour {
    public UnityEvent OnBack;
    public UnityEvent OnSubmit;

    public void Back() {
        OnBack?.Invoke();
    }

    public void Submit() {
        OnSubmit?.Invoke();
    }
}
