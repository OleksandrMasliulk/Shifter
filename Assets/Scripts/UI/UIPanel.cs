using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIPanel : MonoBehaviour
{
    public UnityEvent OnBack;
    public UnityEvent OnEnablePanel;

    [SerializeField] private Button[] interractibleElements;

    private int higlightedElement;

    private void OnEnable()
    {
        OnEnablePanel?.Invoke();
        higlightedElement = 0;
        HighlightElement(0);
    }

    public void ScrollUp()
    {
        higlightedElement--;
        if (higlightedElement < 0)
        {
            higlightedElement = interractibleElements.Length - 1;
        }
        HighlightElement(higlightedElement);
    }

    public void ScrollDown()
    {
        higlightedElement++;
        if (higlightedElement > interractibleElements.Length - 1)
        {
            higlightedElement = 0;
        }
        HighlightElement(higlightedElement);
    }

    public void Submit()
    {
        interractibleElements[higlightedElement].onClick?.Invoke();
    }

    public void Back()
    {
        OnBack?.Invoke();
    }

    private void HighlightElement(int index)
    {
        UnHighlightAll();
        interractibleElements[index].Select();
    }

    private void UnHighlightAll()
    {
        foreach (Button b in interractibleElements)
        {
            b.OnPointerExit(null);
        }
    }
}
