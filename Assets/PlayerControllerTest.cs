using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerTest : MonoBehaviour
{
    private InputAction jumpAction;

    

    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        // Get the InputDevice associated with the jump action
        InputDevice device = context.control.device;

        // Get the deviceId (unique identifier) of the input device
        string deviceId = device.deviceId.ToString();

        // Print the deviceId
        Debug.Log($"Jumping using device with ID: {deviceId}");
    }
}