using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class UINavigation : MonoBehaviour
{
    [SerializeField] public int deviceID = -1;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Transform scrollView;
    [SerializeField] private string debugTag;
    [SerializeField] private LineView lineView;
    private Selectable selectableObject;
    public float cooldownTime = 1f; // Set the cooldown time in seconds
    private bool canClick = true;
    private bool tmpBool;
    private int count = 0;

    public void SetDeviceID(int id)
    {   
        if(deviceID != -1) {
            Debug.Log("Not going to set the ID again");
            return;
        }

        if (id == 0)
        {

            deviceID = 4;
        }
        else
        {
            deviceID = 3;
        }
        Debug.Log($"Settting ID: {deviceID}");
    }

    private IEnumerator StartCooldown()
    {
        // Prevent further clicks during the cooldown period
        canClick = false;

        // Wait for the cooldown period
        yield return new WaitForSeconds(cooldownTime);

        // Allow the button to be clicked again
        canClick = true;
    }

    public void OnSubmitPerformed(InputAction.CallbackContext context)
    {
        // Get the InputDevice associated with the move action
        InputDevice device = context.control.device;

        // Check the deviceId to determine which UI to move
        int deviceId = device.deviceId;
        
        Debug.Log($"Device ID UI: {deviceID}, Device iD: {deviceId}, Can Link: {canClick}");

        if (deviceId == deviceID && canClick)
        {
            if(!tmpBool) {
                StartCoroutine(StartCooldown());
                Debug.Log($"on submit performed: {deviceId}, {deviceID}");
                lineView.OnContinueClicked();
            } else {
                UINavigation parentObject = GameObjectExtensions.FindParentComponent<UINavigation>(selectableObject.gameObject);
                if(parentObject.deviceID != deviceID) return;
                ExecuteEvents.Execute(selectableObject.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
                tmpBool = false;
            }

        }
    }

    public void OnMovePerformed(InputAction.CallbackContext context)
    {
        if(tmpBool) {

            if(count + 1 > 2) {
                count  = 0;
            } else {
                count++;
            }
        } else {
            count = 0;
        }
        // Get the InputDevice associated with the move action
        // InputDevice device = context.control.device;

        // // Check the deviceId to determine which UI to move
        // int deviceId = device.deviceId;
        // Debug.Log($"on move performed: {deviceId}");
        // if (deviceId == deviceID)
        // {

        // }
    }

    private void Update() {
        FixUI(eventSystem, scrollView);



    }

     private void FixUI(EventSystem eventSystem, Transform scrollview)
     {
         if(IsAnyChildObjectWithTagActive(scrollview))
         {
             GameObject tmp = null;
            
             Transform[] childTransforms = scrollview.GetComponentsInChildren<Transform>(true);
                List<GameObject> listOfOptions = new List<GameObject>();
             foreach (Transform childTransform in childTransforms)
             {
                 if (childTransform != scrollview) // Exclude the parent itself
                 {
                    GameObject childObject = childTransform.gameObject;
                    UINavigation parentObject = GameObjectExtensions.FindParentComponent<UINavigation>(childTransform.gameObject);

                     if (!childObject.CompareTag(debugTag) || !childObject.activeSelf || parentObject == null || parentObject.deviceID != deviceID) continue;
                     tmp = childObject;
                     Debug.Log($"ID of parent: {parentObject.deviceID}");
                     listOfOptions.Add(tmp);
                 }
             }

             if (listOfOptions.Count > 0)
             {
                Debug.Log("setting multiple choice");
                tmp = listOfOptions[count];
                eventSystem.SetSelectedGameObject(tmp);
                selectableObject = tmp.GetComponent<Selectable>();
                tmpBool = true;
             } else {
                tmpBool = false;
             }
         }
     }
    
    
    public bool IsAnyChildObjectWithTagActive(Transform scrollview)
    {
        if (scrollview == null)
        {
            Debug.LogWarning("Parent object not assigned.");
            return false;
        }

        // Find children with the specified tag
        Transform[] childTransforms = scrollview.GetComponentsInChildren<Transform>(true);

        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform != scrollview) // Exclude the parent itself
            {
                GameObject childObject = childTransform.gameObject;

                if (childObject.CompareTag(debugTag) && childObject.activeSelf)
                {
                    return true; // At least one active child with the specified tag found
                }
            }
        }

        return false; // No active child with the specified tag found
    }

}

public static class GameObjectExtensions
{
    // This method returns the component of the first parent GameObject with the specified component
    public static T FindParentComponent<T>(this GameObject childObject) where T : Component
    {
        Transform parentTransform = childObject.transform.parent;

        while (parentTransform != null)
        {
            // Check if the parent GameObject has the specified component attached
            T component = parentTransform.gameObject.GetComponent<T>();

            if (component != null)
            {
                return component;
            }

            // Move up to the next parent in the hierarchy
            parentTransform = parentTransform.parent;
        }

        // If no parent with the specified component is found, return null
        return null;
    }
}
