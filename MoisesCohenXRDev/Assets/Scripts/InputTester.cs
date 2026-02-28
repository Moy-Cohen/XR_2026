
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTester : MonoBehaviour
{
    public InputActionReference joystickInput;
    Vector2 joystickValue = Vector2.zero;
    
    private void OnEnable()
    {
        joystickInput.action.Enable();

        joystickInput.action.performed += HandleJoystickInput;
    }

    private void HandleJoystickInput(InputAction.CallbackContext context)
    {
        joystickValue = context.ReadValue<Vector2>();
    }

    private void OnGUI()
    {
        GUILayout.Label($"Input [{joystickValue.x},{joystickValue.y}]");

    }
}
