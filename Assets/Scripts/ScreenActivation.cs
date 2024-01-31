using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenActivation : PlayerInputManager
{
    [SerializeField]
    private List <Transform> PlayerSpawns;
    private void Start() {
        playerJoinedEvent.AddListener(SetPlayerMonitor);
        playerJoinedEvent.AddListener(SetPlayerSpawn);
        Display.displays[0].Activate();
        Display.displays[1].Activate();
    }

    private static void SetPlayerMonitor(PlayerInput arg0)
    {
        Debug.Log($"Set player monitor: {arg0.playerIndex}, Displays: {Display.displays.Length}, {arg0.GetComponentsInChildren<Canvas>().Length}");

        arg0.camera.targetDisplay = arg0.playerIndex;
        arg0.GetComponentInChildren<Canvas>().targetDisplay = arg0.playerIndex;
    }
    private void SetPlayerSpawn(PlayerInput arg0)
    {
        arg0.gameObject.GetComponentInChildren<UINavigation>().SetDeviceID(arg0.playerIndex);
        arg0.gameObject.transform.position = PlayerSpawns[arg0.playerIndex].position;
    }
}