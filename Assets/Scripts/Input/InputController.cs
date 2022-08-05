using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    public enum InputMode
    {
        Player,
        UI
    }

    public static InputController Instance { get; private set; }

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private EventSystem eSystem;

    private InputMapper inputMapper;
    [SerializeField] private InputMode initialMode;

    [SerializeField] private UIPanel activePanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        inputMapper = new InputMapper();
        SwitchInputMode(initialMode);
    }

    private void OnBack()
    {
        activePanel.OnBackEvent?.Invoke();
    }

    public void SetActivePanel(UIPanel panel)
    {
        activePanel = panel;
    }

    public UIPanel GetActivePanel()
    {
        return activePanel;
    }

    private void OnControlsChanged()
    {
        Debug.Log("New Device: " + playerInput.devices[0]);
    }

    public void SwitchInputMode(InputMode mode)
    {
        playerInput.SwitchCurrentActionMap(mode.ToString());

        switch (mode)
        {
            case InputMode.Player:
            {
                inputMapper.Player.Enable();
                inputMapper.UI.Disable();
                break;
            }
            case InputMode.UI:
            {
                inputMapper.Player.Disable();
                inputMapper.UI.Enable();
                break;
            }
        }
    }

    public InputMapper GetInputMapper()
    {
        return inputMapper;
    }

    public void SetSelectedObject(GameObject obj)
    {
        eSystem.SetSelectedGameObject(obj);
    }
}
