using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    // Define any actions you want to occur when the button is clicked
    public void OnMouseDown()
    {
        // Check if the click happened on this GameObject
        Debug.Log("Button clicked!");
    }
}
