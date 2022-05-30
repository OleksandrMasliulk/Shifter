using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIPanel : MonoBehaviour
{
    public UnityEvent OnBackEvent;

    public void OnBack()
    {
        OnBackEvent?.Invoke();
    }
}
