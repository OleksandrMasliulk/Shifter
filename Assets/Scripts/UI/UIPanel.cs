using UnityEngine.Events;
using UnityEngine;

public class UIPanel : UIElement
{
    public UnityEvent OnEnable;
    public UnityEvent OnDisable;

    [SerializeField] private UIElement _firstSelected;
    public UIElement FirstSelected => _firstSelected;

    public void ShowPanelDelayed(float delay) {
        Invoke("ShowPanel", delay);
    }

    public void ShowPanel() {
        gameObject.SetActive(true);
        OnEnable?.Invoke();
    }

    public void HidePanel() {
        OnDisable?.Invoke();
    }
}
