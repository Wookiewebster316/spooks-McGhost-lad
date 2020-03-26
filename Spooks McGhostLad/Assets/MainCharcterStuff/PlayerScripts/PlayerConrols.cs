// GENERATED AUTOMATICALLY FROM 'Assets/MainCharcterStuff/PlayerScripts/PlayerConrols.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerConrols : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerConrols()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerConrols"",
    ""maps"": [
        {
            ""name"": ""ControllerGamePlay"",
            ""id"": ""521ab375-9f84-4ce2-a471-a0293b3c24d4"",
            ""actions"": [
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""1e87b24d-f622-4b56-89e9-a75907f63d70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""walk"",
                    ""type"": ""Button"",
                    ""id"": ""6dad1992-d57e-4f52-8c51-e00b87f1ef4d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""crouch"",
                    ""type"": ""Button"",
                    ""id"": ""487271e1-fd92-4690-97eb-4336f9ea0f8f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fire"",
                    ""type"": ""Button"",
                    ""id"": ""0f57708c-7a99-47c6-a812-964f8713997a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""swing"",
                    ""type"": ""Button"",
                    ""id"": ""dbba2557-5a73-4871-9bff-93ba157b93c5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a55e62a-e5cb-44df-a0fb-b8e6c1d44905"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17284696-da97-47a3-80fa-cdaa0267d5ce"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b577b3f2-8351-45fe-aa98-e8d41d1eff82"",
                    ""path"": ""<DualShockGamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95d17aa9-e331-4d07-8a91-0b99146fe8ac"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0ef0e7d-42eb-43cf-8ed4-703a2e19403c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ControllerGamePlay
        m_ControllerGamePlay = asset.FindActionMap("ControllerGamePlay", throwIfNotFound: true);
        m_ControllerGamePlay_jump = m_ControllerGamePlay.FindAction("jump", throwIfNotFound: true);
        m_ControllerGamePlay_walk = m_ControllerGamePlay.FindAction("walk", throwIfNotFound: true);
        m_ControllerGamePlay_crouch = m_ControllerGamePlay.FindAction("crouch", throwIfNotFound: true);
        m_ControllerGamePlay_fire = m_ControllerGamePlay.FindAction("fire", throwIfNotFound: true);
        m_ControllerGamePlay_swing = m_ControllerGamePlay.FindAction("swing", throwIfNotFound: true);
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

    // ControllerGamePlay
    private readonly InputActionMap m_ControllerGamePlay;
    private IControllerGamePlayActions m_ControllerGamePlayActionsCallbackInterface;
    private readonly InputAction m_ControllerGamePlay_jump;
    private readonly InputAction m_ControllerGamePlay_walk;
    private readonly InputAction m_ControllerGamePlay_crouch;
    private readonly InputAction m_ControllerGamePlay_fire;
    private readonly InputAction m_ControllerGamePlay_swing;
    public struct ControllerGamePlayActions
    {
        private @PlayerConrols m_Wrapper;
        public ControllerGamePlayActions(@PlayerConrols wrapper) { m_Wrapper = wrapper; }
        public InputAction @jump => m_Wrapper.m_ControllerGamePlay_jump;
        public InputAction @walk => m_Wrapper.m_ControllerGamePlay_walk;
        public InputAction @crouch => m_Wrapper.m_ControllerGamePlay_crouch;
        public InputAction @fire => m_Wrapper.m_ControllerGamePlay_fire;
        public InputAction @swing => m_Wrapper.m_ControllerGamePlay_swing;
        public InputActionMap Get() { return m_Wrapper.m_ControllerGamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerGamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IControllerGamePlayActions instance)
        {
            if (m_Wrapper.m_ControllerGamePlayActionsCallbackInterface != null)
            {
                @jump.started -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnJump;
                @walk.started -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnWalk;
                @walk.performed -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnWalk;
                @walk.canceled -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnWalk;
                @crouch.started -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnCrouch;
                @crouch.performed -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnCrouch;
                @crouch.canceled -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnCrouch;
                @fire.started -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnFire;
                @fire.performed -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnFire;
                @fire.canceled -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnFire;
                @swing.started -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnSwing;
                @swing.performed -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnSwing;
                @swing.canceled -= m_Wrapper.m_ControllerGamePlayActionsCallbackInterface.OnSwing;
            }
            m_Wrapper.m_ControllerGamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @walk.started += instance.OnWalk;
                @walk.performed += instance.OnWalk;
                @walk.canceled += instance.OnWalk;
                @crouch.started += instance.OnCrouch;
                @crouch.performed += instance.OnCrouch;
                @crouch.canceled += instance.OnCrouch;
                @fire.started += instance.OnFire;
                @fire.performed += instance.OnFire;
                @fire.canceled += instance.OnFire;
                @swing.started += instance.OnSwing;
                @swing.performed += instance.OnSwing;
                @swing.canceled += instance.OnSwing;
            }
        }
    }
    public ControllerGamePlayActions @ControllerGamePlay => new ControllerGamePlayActions(this);
    public interface IControllerGamePlayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSwing(InputAction.CallbackContext context);
    }
}
