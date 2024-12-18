//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/EntradasDeMoviento.inputactions
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

public partial class @EntradasDeMoviento: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @EntradasDeMoviento()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EntradasDeMoviento"",
    ""maps"": [
        {
            ""name"": ""Moviemiento"",
            ""id"": ""cbeeb146-94e9-47ea-87e2-87c7cd90eb73"",
            ""actions"": [
                {
                    ""name"": ""Horizontal "",
                    ""type"": ""PassThrough"",
                    ""id"": ""6d438937-955f-4b4b-8b82-93fad9e21e7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Arco"",
                    ""type"": ""Button"",
                    ""id"": ""9b2466ee-b506-47d9-bfa6-a7b5938128dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Golpe"",
                    ""type"": ""Button"",
                    ""id"": ""56adf132-8b12-479d-b843-bb8a3d40f4c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Flechas"",
                    ""id"": ""7148b1a3-efa1-4b6d-b4ad-df04391b0fd4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal "",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""29b53820-1232-4480-9fc1-db797166df1d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4214fd21-f710-4bda-b486-60aa9f7ea969"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""440d9458-85d3-4c8a-a914-e4a59fbf6707"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal "",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""de4f0170-56ce-492a-874f-21be4837338c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7542bdf3-f62b-4ba4-9616-b53e01c396f1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""707f2992-2483-4734-9b97-80cf7361ae43"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arco"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50165a3d-ef4b-4efb-b688-ad6e0076240e"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Golpe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Moviemiento
        m_Moviemiento = asset.FindActionMap("Moviemiento", throwIfNotFound: true);
        m_Moviemiento_Horizontal = m_Moviemiento.FindAction("Horizontal ", throwIfNotFound: true);
        m_Moviemiento_Arco = m_Moviemiento.FindAction("Arco", throwIfNotFound: true);
        m_Moviemiento_Golpe = m_Moviemiento.FindAction("Golpe", throwIfNotFound: true);
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

    // Moviemiento
    private readonly InputActionMap m_Moviemiento;
    private List<IMoviemientoActions> m_MoviemientoActionsCallbackInterfaces = new List<IMoviemientoActions>();
    private readonly InputAction m_Moviemiento_Horizontal;
    private readonly InputAction m_Moviemiento_Arco;
    private readonly InputAction m_Moviemiento_Golpe;
    public struct MoviemientoActions
    {
        private @EntradasDeMoviento m_Wrapper;
        public MoviemientoActions(@EntradasDeMoviento wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Moviemiento_Horizontal;
        public InputAction @Arco => m_Wrapper.m_Moviemiento_Arco;
        public InputAction @Golpe => m_Wrapper.m_Moviemiento_Golpe;
        public InputActionMap Get() { return m_Wrapper.m_Moviemiento; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoviemientoActions set) { return set.Get(); }
        public void AddCallbacks(IMoviemientoActions instance)
        {
            if (instance == null || m_Wrapper.m_MoviemientoActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MoviemientoActionsCallbackInterfaces.Add(instance);
            @Horizontal.started += instance.OnHorizontal;
            @Horizontal.performed += instance.OnHorizontal;
            @Horizontal.canceled += instance.OnHorizontal;
            @Arco.started += instance.OnArco;
            @Arco.performed += instance.OnArco;
            @Arco.canceled += instance.OnArco;
            @Golpe.started += instance.OnGolpe;
            @Golpe.performed += instance.OnGolpe;
            @Golpe.canceled += instance.OnGolpe;
        }

        private void UnregisterCallbacks(IMoviemientoActions instance)
        {
            @Horizontal.started -= instance.OnHorizontal;
            @Horizontal.performed -= instance.OnHorizontal;
            @Horizontal.canceled -= instance.OnHorizontal;
            @Arco.started -= instance.OnArco;
            @Arco.performed -= instance.OnArco;
            @Arco.canceled -= instance.OnArco;
            @Golpe.started -= instance.OnGolpe;
            @Golpe.performed -= instance.OnGolpe;
            @Golpe.canceled -= instance.OnGolpe;
        }

        public void RemoveCallbacks(IMoviemientoActions instance)
        {
            if (m_Wrapper.m_MoviemientoActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMoviemientoActions instance)
        {
            foreach (var item in m_Wrapper.m_MoviemientoActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MoviemientoActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MoviemientoActions @Moviemiento => new MoviemientoActions(this);
    public interface IMoviemientoActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnArco(InputAction.CallbackContext context);
        void OnGolpe(InputAction.CallbackContext context);
    }
}
