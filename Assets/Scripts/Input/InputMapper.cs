//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.1
//     from Assets/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputMapper : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMapper()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""35f5cd02-b127-4c39-8617-4546a66265c0"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""bde52f63-d7b8-47b4-bfaa-b84ab4e61da9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""55355df1-a45c-4cea-9df6-15c58b31ac2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Blink"",
                    ""type"": ""Button"",
                    ""id"": ""816f4da6-5c15-462b-9b8e-8b8ba34ce822"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Blink Left"",
                    ""type"": ""Button"",
                    ""id"": ""55d337c6-009b-4fcf-801e-37a4906d2912"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Blink Right"",
                    ""type"": ""Button"",
                    ""id"": ""299859d2-ff2d-4cfd-8810-4328f991e852"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Call Pause"",
                    ""type"": ""Button"",
                    ""id"": ""113912ed-13a0-468f-9cfe-1deb716b0d20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""afbadfa3-1b36-42a1-ad31-a0bb0428aad5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Main Menu"",
                    ""type"": ""Button"",
                    ""id"": ""78935d01-ff31-49c5-91c5-0c8e7ed188ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""d2679243-5e62-4bfa-b73e-5b4ec0f0e445"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2f22622f-8c70-4d5f-9e53-028a0845eced"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""55687aa0-7a16-4544-822c-75eda6d3a49b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""d5d1463d-b022-418f-99a8-c2d95fbbaaf5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8f01c35e-81fb-4b65-b37c-03bae5d7a705"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f024684a-0be3-47f1-bb03-5685b5337512"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""426df9d8-c713-4826-89b2-efce469a59e2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f34dbe96-3050-423b-8184-2a05f07842a5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64efcbd4-de58-46d0-8485-a9c9bb8e76b6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cc38cbc-08ae-474d-8203-7e3d0e135191"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Blink"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""370b2a10-c6fa-4354-b0fd-f9d20eaff6e4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Blink Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""740a2879-60d8-4bc0-91c1-a6b9a371045d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Blink Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0094e72a-a17a-452f-901b-164c1e072f64"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Call Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5fa0f56-dd86-4ce8-98c0-f6b76d8c602a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7997266-b4a9-4517-81c6-fc4c18371545"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Main Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""0a1cc3eb-0cdb-4304-8e6c-fbc6f39fa7e5"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""5cf0823e-c00b-44f1-9311-78cf91373669"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""5661a645-6ece-4736-b4f4-f124a98bd6e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll Down"",
                    ""type"": ""Button"",
                    ""id"": ""03ceedb6-56ae-4685-a178-86636b3b5c3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll Up"",
                    ""type"": ""Button"",
                    ""id"": ""339597b1-890d-4a90-b897-c3eac2380677"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""be1c6539-cc53-4258-87fe-1e4d1a152691"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7e34a5d-6345-429e-8209-4e1c6d8ed164"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72766142-51bd-4328-861d-3d8f633d246d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b28853d2-752f-4bfb-ae6e-c07e57f03b43"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Scroll Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac6927bd-38b9-47dd-93f8-137f9318994b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Scroll Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c18e38b-7165-45bc-9a90-62974dd2b71a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Scroll Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40e585d5-af8a-4c98-a42e-ea64a0c2beb0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Scroll Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XboxController"",
            ""bindingGroup"": ""XboxController"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PS4Controller"",
            ""bindingGroup"": ""PS4Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Blink = m_Player.FindAction("Blink", throwIfNotFound: true);
        m_Player_BlinkLeft = m_Player.FindAction("Blink Left", throwIfNotFound: true);
        m_Player_BlinkRight = m_Player.FindAction("Blink Right", throwIfNotFound: true);
        m_Player_CallPause = m_Player.FindAction("Call Pause", throwIfNotFound: true);
        m_Player_Restart = m_Player.FindAction("Restart", throwIfNotFound: true);
        m_Player_MainMenu = m_Player.FindAction("Main Menu", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Back = m_UI.FindAction("Back", throwIfNotFound: true);
        m_UI_ScrollDown = m_UI.FindAction("Scroll Down", throwIfNotFound: true);
        m_UI_ScrollUp = m_UI.FindAction("Scroll Up", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Blink;
    private readonly InputAction m_Player_BlinkLeft;
    private readonly InputAction m_Player_BlinkRight;
    private readonly InputAction m_Player_CallPause;
    private readonly InputAction m_Player_Restart;
    private readonly InputAction m_Player_MainMenu;
    public struct PlayerActions
    {
        private @InputMapper m_Wrapper;
        public PlayerActions(@InputMapper wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Blink => m_Wrapper.m_Player_Blink;
        public InputAction @BlinkLeft => m_Wrapper.m_Player_BlinkLeft;
        public InputAction @BlinkRight => m_Wrapper.m_Player_BlinkRight;
        public InputAction @CallPause => m_Wrapper.m_Player_CallPause;
        public InputAction @Restart => m_Wrapper.m_Player_Restart;
        public InputAction @MainMenu => m_Wrapper.m_Player_MainMenu;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Blink.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlink;
                @Blink.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlink;
                @Blink.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlink;
                @BlinkLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlinkLeft;
                @BlinkLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlinkLeft;
                @BlinkLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlinkLeft;
                @BlinkRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlinkRight;
                @BlinkRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlinkRight;
                @BlinkRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlinkRight;
                @CallPause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCallPause;
                @CallPause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCallPause;
                @CallPause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCallPause;
                @Restart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @MainMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMainMenu;
                @MainMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMainMenu;
                @MainMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMainMenu;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Blink.started += instance.OnBlink;
                @Blink.performed += instance.OnBlink;
                @Blink.canceled += instance.OnBlink;
                @BlinkLeft.started += instance.OnBlinkLeft;
                @BlinkLeft.performed += instance.OnBlinkLeft;
                @BlinkLeft.canceled += instance.OnBlinkLeft;
                @BlinkRight.started += instance.OnBlinkRight;
                @BlinkRight.performed += instance.OnBlinkRight;
                @BlinkRight.canceled += instance.OnBlinkRight;
                @CallPause.started += instance.OnCallPause;
                @CallPause.performed += instance.OnCallPause;
                @CallPause.canceled += instance.OnCallPause;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @MainMenu.started += instance.OnMainMenu;
                @MainMenu.performed += instance.OnMainMenu;
                @MainMenu.canceled += instance.OnMainMenu;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Back;
    private readonly InputAction m_UI_ScrollDown;
    private readonly InputAction m_UI_ScrollUp;
    public struct UIActions
    {
        private @InputMapper m_Wrapper;
        public UIActions(@InputMapper wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Back => m_Wrapper.m_UI_Back;
        public InputAction @ScrollDown => m_Wrapper.m_UI_ScrollDown;
        public InputAction @ScrollUp => m_Wrapper.m_UI_ScrollUp;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Back.started -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @ScrollDown.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollDown;
                @ScrollDown.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollDown;
                @ScrollDown.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollDown;
                @ScrollUp.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollUp;
                @ScrollUp.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollUp;
                @ScrollUp.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollUp;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @ScrollDown.started += instance.OnScrollDown;
                @ScrollDown.performed += instance.OnScrollDown;
                @ScrollDown.canceled += instance.OnScrollDown;
                @ScrollUp.started += instance.OnScrollUp;
                @ScrollUp.performed += instance.OnScrollUp;
                @ScrollUp.canceled += instance.OnScrollUp;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("XboxController");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    private int m_PS4ControllerSchemeIndex = -1;
    public InputControlScheme PS4ControllerScheme
    {
        get
        {
            if (m_PS4ControllerSchemeIndex == -1) m_PS4ControllerSchemeIndex = asset.FindControlSchemeIndex("PS4Controller");
            return asset.controlSchemes[m_PS4ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBlink(InputAction.CallbackContext context);
        void OnBlinkLeft(InputAction.CallbackContext context);
        void OnBlinkRight(InputAction.CallbackContext context);
        void OnCallPause(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnMainMenu(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnScrollDown(InputAction.CallbackContext context);
        void OnScrollUp(InputAction.CallbackContext context);
    }
}
