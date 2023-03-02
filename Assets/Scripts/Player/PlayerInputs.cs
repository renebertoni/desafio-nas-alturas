using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public static Action Fly;

    [SerializeField] InputActionReference FlyInput;

    void OnEnable()
    {
        FlyInput.action.performed += DoFly;
    }

    void OnDisable()
    {
        FlyInput.action.performed -= DoFly;
    }

    private void DoFly(InputAction.CallbackContext obj)
    {
        Fly?.Invoke();
    }
}
