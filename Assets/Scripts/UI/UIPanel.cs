using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPanel : MonoBehaviour
{
    public UnityEvent OnBackEvent;
    public UnityEvent OnEnableEvent;

    private UIPanel prevActivePanel;

    public virtual void ShowPanelDelayed(float delay)
    {
        Invoke("ShowPanel", delay);
    }

    public virtual void ShowPanel()
    {
        prevActivePanel = InputController.Instance.GetActivePanel();
        InputController.Instance.SetActivePanel(this);
        gameObject.SetActive(true);

        OnEnableEvent?.Invoke();
    }

    public virtual void HidePanel()
    {
        InputController.Instance.SetActivePanel(prevActivePanel);
        prevActivePanel = null;
        gameObject.SetActive(false);
    }
}
