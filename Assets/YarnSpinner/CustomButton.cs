using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // This function will be called when the button is clicked

        // Prevent the default button click action
        eventData.Use();

        // Add your custom logic here
        Debug.Log("Button clicked, but default action canceled.");
    }
}