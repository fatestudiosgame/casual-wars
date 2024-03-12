// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""401bb09e-f41a-40fe-9617-8289fbce5ea4"",
            ""actions"": [
                {
                    ""name"": ""BotonDisparo"",
                    ""type"": ""Button"",
                    ""id"": ""6e653751-6e77-429d-b6e6-d4823c954207"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonAccion"",
                    ""type"": ""Button"",
                    ""id"": ""1b21873d-dd10-455f-b609-0287d9d86c8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonIzquierda"",
                    ""type"": ""Button"",
                    ""id"": ""2dbee3c6-5375-442a-80b0-ec1e3c4ca951"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonDerecha"",
                    ""type"": ""Button"",
                    ""id"": ""6b8065a8-8143-42a9-8c5f-242d9cd0c890"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonVoltear"",
                    ""type"": ""Button"",
                    ""id"": ""b9816f3b-4627-4503-81ae-42a04486f1aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonPausa"",
                    ""type"": ""Button"",
                    ""id"": ""00d4b303-66e4-4e98-ac29-39c568ee05fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonSeleccionarTropa"",
                    ""type"": ""Button"",
                    ""id"": ""61fddf3b-76b4-47a4-a3c4-84a883b3d5da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonApuntar"",
                    ""type"": ""Value"",
                    ""id"": ""ed788265-2841-4522-9e83-5b2dd2c30711"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonCancelar"",
                    ""type"": ""Button"",
                    ""id"": ""b52fb320-093a-4e19-bf19-35ccd710a9f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dc1dec49-4e0d-46c8-a4ec-4e0294139341"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonDisparo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dae5e5f0-a186-47ac-b52a-48f0abc48287"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""teclado"",
                    ""action"": ""BotonDisparo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""903b88db-8a99-464c-b91d-afbc9bd407b2"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonDisparo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f931b735-9a5c-4237-8abb-e7d8ba290ef2"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonAccion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f78e66d1-7c98-4a8e-ac01-b7fa71768ae7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""teclado"",
                    ""action"": ""BotonAccion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""807cc221-8ecc-4a00-b614-17111ddd70e5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""teclado"",
                    ""action"": ""BotonAccion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""352831d1-d5ca-4e47-8dfa-5a6f619122a1"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonAccion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ec7b18a-2916-403c-bc19-117e3b737947"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonIzquierda"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f391aa6-930f-414b-a631-64724c0fa234"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""teclado"",
                    ""action"": ""BotonIzquierda"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6995fe8-bf58-44ba-8a08-2b6e208ed470"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonIzquierda"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8d36716-e4e6-4d25-bc20-5e99133fc8c9"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonIzquierda"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0d47be9-83c0-44c6-876f-762cb7e4a555"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonDerecha"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9812aea5-843a-42fa-8489-c893d83525de"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""teclado"",
                    ""action"": ""BotonDerecha"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f6249a6-6a27-40a8-b58e-b31b380d81c3"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonDerecha"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7a174bd-c035-4b7d-9391-844ea04a0b92"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonDerecha"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ea56ded-14b2-447b-86b1-a1be601aca5f"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonVoltear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""616128ba-0ec5-46f5-9d3f-010b93390f1a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""teclado"",
                    ""action"": ""BotonVoltear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40d06e2d-5b15-49d2-9778-2ad9c0d3e3e3"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonVoltear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""353a12bc-3c60-46f0-b189-4a8b218e9964"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonPausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33d082e2-8f70-4429-a251-ca5a2c13b330"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""teclado"",
                    ""action"": ""BotonPausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4ebe652-df3f-472d-8579-8530b635acf2"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonPausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a33f4a3-d686-42ad-a12e-c203f502a23e"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonSeleccionarTropa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6d6b040-8fec-4df7-8c32-9d5d1112b489"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonSeleccionarTropa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38f3d900-1aff-4912-8709-2c1825a72329"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""teclado"",
                    ""action"": ""BotonApuntar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26d6c53e-39f8-479c-8618-b45d5a73545b"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonApuntar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b81b4916-0f20-439e-a462-89f19ecc9c4e"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonApuntar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b29fe5c5-7dca-4353-af0f-e9d935df3075"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonCancelar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6aa1a274-c7b2-4c96-9670-0e5ad1cc50c2"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BotonCancelar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameplayTropas"",
            ""id"": ""f74f881b-ac4e-4cca-98d6-0c71822de52d"",
            ""actions"": [
                {
                    ""name"": ""BotonIzquierda"",
                    ""type"": ""Button"",
                    ""id"": ""e1559a0c-e7b9-4a74-b107-0fb9710548c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonSeleccionarTropa"",
                    ""type"": ""Button"",
                    ""id"": ""4155562b-6155-43d1-940f-23d971618b6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonDerecha"",
                    ""type"": ""Button"",
                    ""id"": ""0b441a85-7cef-432d-815a-35ea2a0eb821"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonAccion"",
                    ""type"": ""Button"",
                    ""id"": ""68700e7a-d907-4150-ba84-f4daed7bb225"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BotonSeleccionarTropa1"",
                    ""type"": ""Button"",
                    ""id"": ""4b3e5050-fadd-42d7-b243-84fc6e3f72a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cf989626-11cf-480b-bb96-cb0d7ea89bd9"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonIzquierda"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9f995ad-0e69-4aa7-8e4a-5168c58e1fac"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonSeleccionarTropa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24450e93-d405-4b8c-8795-0abaa5d0283e"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonDerecha"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c68f992a-ccd9-4c53-b433-95ffe7434701"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonAccion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""910620b8-aeab-406b-91fe-db478c5e97fe"",
                    ""path"": ""<HID::ShanWan USB WirelessGamepad >/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mando_verde"",
                    ""action"": ""BotonSeleccionarTropa1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""mando_verde"",
            ""bindingGroup"": ""mando_verde"",
            ""devices"": []
        },
        {
            ""name"": ""teclado"",
            ""bindingGroup"": ""teclado"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_BotonDisparo = m_Gameplay.FindAction("BotonDisparo", throwIfNotFound: true);
        m_Gameplay_BotonAccion = m_Gameplay.FindAction("BotonAccion", throwIfNotFound: true);
        m_Gameplay_BotonIzquierda = m_Gameplay.FindAction("BotonIzquierda", throwIfNotFound: true);
        m_Gameplay_BotonDerecha = m_Gameplay.FindAction("BotonDerecha", throwIfNotFound: true);
        m_Gameplay_BotonVoltear = m_Gameplay.FindAction("BotonVoltear", throwIfNotFound: true);
        m_Gameplay_BotonPausa = m_Gameplay.FindAction("BotonPausa", throwIfNotFound: true);
        m_Gameplay_BotonSeleccionarTropa = m_Gameplay.FindAction("BotonSeleccionarTropa", throwIfNotFound: true);
        m_Gameplay_BotonApuntar = m_Gameplay.FindAction("BotonApuntar", throwIfNotFound: true);
        m_Gameplay_BotonCancelar = m_Gameplay.FindAction("BotonCancelar", throwIfNotFound: true);
        // GameplayTropas
        m_GameplayTropas = asset.FindActionMap("GameplayTropas", throwIfNotFound: true);
        m_GameplayTropas_BotonIzquierda = m_GameplayTropas.FindAction("BotonIzquierda", throwIfNotFound: true);
        m_GameplayTropas_BotonSeleccionarTropa = m_GameplayTropas.FindAction("BotonSeleccionarTropa", throwIfNotFound: true);
        m_GameplayTropas_BotonDerecha = m_GameplayTropas.FindAction("BotonDerecha", throwIfNotFound: true);
        m_GameplayTropas_BotonAccion = m_GameplayTropas.FindAction("BotonAccion", throwIfNotFound: true);
        m_GameplayTropas_BotonSeleccionarTropa1 = m_GameplayTropas.FindAction("BotonSeleccionarTropa1", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_BotonDisparo;
    private readonly InputAction m_Gameplay_BotonAccion;
    private readonly InputAction m_Gameplay_BotonIzquierda;
    private readonly InputAction m_Gameplay_BotonDerecha;
    private readonly InputAction m_Gameplay_BotonVoltear;
    private readonly InputAction m_Gameplay_BotonPausa;
    private readonly InputAction m_Gameplay_BotonSeleccionarTropa;
    private readonly InputAction m_Gameplay_BotonApuntar;
    private readonly InputAction m_Gameplay_BotonCancelar;
    public struct GameplayActions
    {
        private @PlayerControl m_Wrapper;
        public GameplayActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @BotonDisparo => m_Wrapper.m_Gameplay_BotonDisparo;
        public InputAction @BotonAccion => m_Wrapper.m_Gameplay_BotonAccion;
        public InputAction @BotonIzquierda => m_Wrapper.m_Gameplay_BotonIzquierda;
        public InputAction @BotonDerecha => m_Wrapper.m_Gameplay_BotonDerecha;
        public InputAction @BotonVoltear => m_Wrapper.m_Gameplay_BotonVoltear;
        public InputAction @BotonPausa => m_Wrapper.m_Gameplay_BotonPausa;
        public InputAction @BotonSeleccionarTropa => m_Wrapper.m_Gameplay_BotonSeleccionarTropa;
        public InputAction @BotonApuntar => m_Wrapper.m_Gameplay_BotonApuntar;
        public InputAction @BotonCancelar => m_Wrapper.m_Gameplay_BotonCancelar;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @BotonDisparo.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonDisparo;
                @BotonDisparo.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonDisparo;
                @BotonDisparo.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonDisparo;
                @BotonAccion.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonAccion;
                @BotonAccion.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonAccion;
                @BotonAccion.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonAccion;
                @BotonIzquierda.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonIzquierda;
                @BotonIzquierda.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonIzquierda;
                @BotonIzquierda.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonIzquierda;
                @BotonDerecha.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonDerecha;
                @BotonDerecha.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonDerecha;
                @BotonDerecha.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonDerecha;
                @BotonVoltear.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonVoltear;
                @BotonVoltear.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonVoltear;
                @BotonVoltear.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonVoltear;
                @BotonPausa.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonPausa;
                @BotonPausa.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonPausa;
                @BotonPausa.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonPausa;
                @BotonSeleccionarTropa.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonSeleccionarTropa;
                @BotonSeleccionarTropa.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonSeleccionarTropa;
                @BotonSeleccionarTropa.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonSeleccionarTropa;
                @BotonApuntar.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonApuntar;
                @BotonApuntar.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonApuntar;
                @BotonApuntar.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonApuntar;
                @BotonCancelar.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonCancelar;
                @BotonCancelar.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonCancelar;
                @BotonCancelar.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBotonCancelar;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @BotonDisparo.started += instance.OnBotonDisparo;
                @BotonDisparo.performed += instance.OnBotonDisparo;
                @BotonDisparo.canceled += instance.OnBotonDisparo;
                @BotonAccion.started += instance.OnBotonAccion;
                @BotonAccion.performed += instance.OnBotonAccion;
                @BotonAccion.canceled += instance.OnBotonAccion;
                @BotonIzquierda.started += instance.OnBotonIzquierda;
                @BotonIzquierda.performed += instance.OnBotonIzquierda;
                @BotonIzquierda.canceled += instance.OnBotonIzquierda;
                @BotonDerecha.started += instance.OnBotonDerecha;
                @BotonDerecha.performed += instance.OnBotonDerecha;
                @BotonDerecha.canceled += instance.OnBotonDerecha;
                @BotonVoltear.started += instance.OnBotonVoltear;
                @BotonVoltear.performed += instance.OnBotonVoltear;
                @BotonVoltear.canceled += instance.OnBotonVoltear;
                @BotonPausa.started += instance.OnBotonPausa;
                @BotonPausa.performed += instance.OnBotonPausa;
                @BotonPausa.canceled += instance.OnBotonPausa;
                @BotonSeleccionarTropa.started += instance.OnBotonSeleccionarTropa;
                @BotonSeleccionarTropa.performed += instance.OnBotonSeleccionarTropa;
                @BotonSeleccionarTropa.canceled += instance.OnBotonSeleccionarTropa;
                @BotonApuntar.started += instance.OnBotonApuntar;
                @BotonApuntar.performed += instance.OnBotonApuntar;
                @BotonApuntar.canceled += instance.OnBotonApuntar;
                @BotonCancelar.started += instance.OnBotonCancelar;
                @BotonCancelar.performed += instance.OnBotonCancelar;
                @BotonCancelar.canceled += instance.OnBotonCancelar;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // GameplayTropas
    private readonly InputActionMap m_GameplayTropas;
    private IGameplayTropasActions m_GameplayTropasActionsCallbackInterface;
    private readonly InputAction m_GameplayTropas_BotonIzquierda;
    private readonly InputAction m_GameplayTropas_BotonSeleccionarTropa;
    private readonly InputAction m_GameplayTropas_BotonDerecha;
    private readonly InputAction m_GameplayTropas_BotonAccion;
    private readonly InputAction m_GameplayTropas_BotonSeleccionarTropa1;
    public struct GameplayTropasActions
    {
        private @PlayerControl m_Wrapper;
        public GameplayTropasActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @BotonIzquierda => m_Wrapper.m_GameplayTropas_BotonIzquierda;
        public InputAction @BotonSeleccionarTropa => m_Wrapper.m_GameplayTropas_BotonSeleccionarTropa;
        public InputAction @BotonDerecha => m_Wrapper.m_GameplayTropas_BotonDerecha;
        public InputAction @BotonAccion => m_Wrapper.m_GameplayTropas_BotonAccion;
        public InputAction @BotonSeleccionarTropa1 => m_Wrapper.m_GameplayTropas_BotonSeleccionarTropa1;
        public InputActionMap Get() { return m_Wrapper.m_GameplayTropas; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayTropasActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayTropasActions instance)
        {
            if (m_Wrapper.m_GameplayTropasActionsCallbackInterface != null)
            {
                @BotonIzquierda.started -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonIzquierda;
                @BotonIzquierda.performed -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonIzquierda;
                @BotonIzquierda.canceled -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonIzquierda;
                @BotonSeleccionarTropa.started -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonSeleccionarTropa;
                @BotonSeleccionarTropa.performed -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonSeleccionarTropa;
                @BotonSeleccionarTropa.canceled -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonSeleccionarTropa;
                @BotonDerecha.started -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonDerecha;
                @BotonDerecha.performed -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonDerecha;
                @BotonDerecha.canceled -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonDerecha;
                @BotonAccion.started -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonAccion;
                @BotonAccion.performed -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonAccion;
                @BotonAccion.canceled -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonAccion;
                @BotonSeleccionarTropa1.started -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonSeleccionarTropa1;
                @BotonSeleccionarTropa1.performed -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonSeleccionarTropa1;
                @BotonSeleccionarTropa1.canceled -= m_Wrapper.m_GameplayTropasActionsCallbackInterface.OnBotonSeleccionarTropa1;
            }
            m_Wrapper.m_GameplayTropasActionsCallbackInterface = instance;
            if (instance != null)
            {
                @BotonIzquierda.started += instance.OnBotonIzquierda;
                @BotonIzquierda.performed += instance.OnBotonIzquierda;
                @BotonIzquierda.canceled += instance.OnBotonIzquierda;
                @BotonSeleccionarTropa.started += instance.OnBotonSeleccionarTropa;
                @BotonSeleccionarTropa.performed += instance.OnBotonSeleccionarTropa;
                @BotonSeleccionarTropa.canceled += instance.OnBotonSeleccionarTropa;
                @BotonDerecha.started += instance.OnBotonDerecha;
                @BotonDerecha.performed += instance.OnBotonDerecha;
                @BotonDerecha.canceled += instance.OnBotonDerecha;
                @BotonAccion.started += instance.OnBotonAccion;
                @BotonAccion.performed += instance.OnBotonAccion;
                @BotonAccion.canceled += instance.OnBotonAccion;
                @BotonSeleccionarTropa1.started += instance.OnBotonSeleccionarTropa1;
                @BotonSeleccionarTropa1.performed += instance.OnBotonSeleccionarTropa1;
                @BotonSeleccionarTropa1.canceled += instance.OnBotonSeleccionarTropa1;
            }
        }
    }
    public GameplayTropasActions @GameplayTropas => new GameplayTropasActions(this);
    private int m_mando_verdeSchemeIndex = -1;
    public InputControlScheme mando_verdeScheme
    {
        get
        {
            if (m_mando_verdeSchemeIndex == -1) m_mando_verdeSchemeIndex = asset.FindControlSchemeIndex("mando_verde");
            return asset.controlSchemes[m_mando_verdeSchemeIndex];
        }
    }
    private int m_tecladoSchemeIndex = -1;
    public InputControlScheme tecladoScheme
    {
        get
        {
            if (m_tecladoSchemeIndex == -1) m_tecladoSchemeIndex = asset.FindControlSchemeIndex("teclado");
            return asset.controlSchemes[m_tecladoSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnBotonDisparo(InputAction.CallbackContext context);
        void OnBotonAccion(InputAction.CallbackContext context);
        void OnBotonIzquierda(InputAction.CallbackContext context);
        void OnBotonDerecha(InputAction.CallbackContext context);
        void OnBotonVoltear(InputAction.CallbackContext context);
        void OnBotonPausa(InputAction.CallbackContext context);
        void OnBotonSeleccionarTropa(InputAction.CallbackContext context);
        void OnBotonApuntar(InputAction.CallbackContext context);
        void OnBotonCancelar(InputAction.CallbackContext context);
    }
    public interface IGameplayTropasActions
    {
        void OnBotonIzquierda(InputAction.CallbackContext context);
        void OnBotonSeleccionarTropa(InputAction.CallbackContext context);
        void OnBotonDerecha(InputAction.CallbackContext context);
        void OnBotonAccion(InputAction.CallbackContext context);
        void OnBotonSeleccionarTropa1(InputAction.CallbackContext context);
    }
}
