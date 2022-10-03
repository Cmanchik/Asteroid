//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/InputSystem/InputSystem.inputactions
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

public partial class @InputSystem : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Starship"",
            ""id"": ""30c0a0bc-ed21-4470-8c0a-60131cf68c87"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""008bf609-c16c-4394-8c97-f8baf5a8c4b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Turning"",
                    ""type"": ""Button"",
                    ""id"": ""cfdaced5-98de-4fe7-9203-e188a80eedf3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackMachineGun"",
                    ""type"": ""Button"",
                    ""id"": ""f5ceb281-d6a6-4b5b-8286-fbb46522a214"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackLaser"",
                    ""type"": ""Button"",
                    ""id"": ""b5bfeb99-76b8-433b-b29a-b65a023c05ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""444c02af-b60d-4cb5-afb6-faa7f1eb37a2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""eb53ee18-b3dc-4b57-bed3-8aa08fc4da5d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turning"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""36c705a9-1cd0-4502-baf6-f42173e1d6af"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8bf9b946-cc0d-433a-9010-16c740c27947"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1ea20425-4874-4927-bbcb-6fcc55735bfd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackMachineGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""128d1b7a-de8c-450a-a974-32edd41f32b3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackLaser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Starship
        m_Starship = asset.FindActionMap("Starship", throwIfNotFound: true);
        m_Starship_Accelerate = m_Starship.FindAction("Accelerate", throwIfNotFound: true);
        m_Starship_Turning = m_Starship.FindAction("Turning", throwIfNotFound: true);
        m_Starship_AttackMachineGun = m_Starship.FindAction("AttackMachineGun", throwIfNotFound: true);
        m_Starship_AttackLaser = m_Starship.FindAction("AttackLaser", throwIfNotFound: true);
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

    // Starship
    private readonly InputActionMap m_Starship;
    private IStarshipActions m_StarshipActionsCallbackInterface;
    private readonly InputAction m_Starship_Accelerate;
    private readonly InputAction m_Starship_Turning;
    private readonly InputAction m_Starship_AttackMachineGun;
    private readonly InputAction m_Starship_AttackLaser;
    public struct StarshipActions
    {
        private @InputSystem m_Wrapper;
        public StarshipActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Starship_Accelerate;
        public InputAction @Turning => m_Wrapper.m_Starship_Turning;
        public InputAction @AttackMachineGun => m_Wrapper.m_Starship_AttackMachineGun;
        public InputAction @AttackLaser => m_Wrapper.m_Starship_AttackLaser;
        public InputActionMap Get() { return m_Wrapper.m_Starship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StarshipActions set) { return set.Get(); }
        public void SetCallbacks(IStarshipActions instance)
        {
            if (m_Wrapper.m_StarshipActionsCallbackInterface != null)
            {
                @Accelerate.started -= m_Wrapper.m_StarshipActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_StarshipActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_StarshipActionsCallbackInterface.OnAccelerate;
                @Turning.started -= m_Wrapper.m_StarshipActionsCallbackInterface.OnTurning;
                @Turning.performed -= m_Wrapper.m_StarshipActionsCallbackInterface.OnTurning;
                @Turning.canceled -= m_Wrapper.m_StarshipActionsCallbackInterface.OnTurning;
                @AttackMachineGun.started -= m_Wrapper.m_StarshipActionsCallbackInterface.OnAttackMachineGun;
                @AttackMachineGun.performed -= m_Wrapper.m_StarshipActionsCallbackInterface.OnAttackMachineGun;
                @AttackMachineGun.canceled -= m_Wrapper.m_StarshipActionsCallbackInterface.OnAttackMachineGun;
                @AttackLaser.started -= m_Wrapper.m_StarshipActionsCallbackInterface.OnAttackLaser;
                @AttackLaser.performed -= m_Wrapper.m_StarshipActionsCallbackInterface.OnAttackLaser;
                @AttackLaser.canceled -= m_Wrapper.m_StarshipActionsCallbackInterface.OnAttackLaser;
            }
            m_Wrapper.m_StarshipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Turning.started += instance.OnTurning;
                @Turning.performed += instance.OnTurning;
                @Turning.canceled += instance.OnTurning;
                @AttackMachineGun.started += instance.OnAttackMachineGun;
                @AttackMachineGun.performed += instance.OnAttackMachineGun;
                @AttackMachineGun.canceled += instance.OnAttackMachineGun;
                @AttackLaser.started += instance.OnAttackLaser;
                @AttackLaser.performed += instance.OnAttackLaser;
                @AttackLaser.canceled += instance.OnAttackLaser;
            }
        }
    }
    public StarshipActions @Starship => new StarshipActions(this);
    public interface IStarshipActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnTurning(InputAction.CallbackContext context);
        void OnAttackMachineGun(InputAction.CallbackContext context);
        void OnAttackLaser(InputAction.CallbackContext context);
    }
}
