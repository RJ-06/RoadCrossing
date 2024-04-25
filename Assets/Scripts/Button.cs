using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    // Reference to the game object you want to enable
    public GameObject objectToEnable;
    [SerializeField] StopLight s;

    // Define any actions you want to occur when the button is clicked
    public void OnMouseDown()
    {
        // Check if the click happened on this GameObject
        Debug.Log("Button clicked!");

        // Enable the specified game object

        StartCoroutine(CreateScan());
    }

    IEnumerator CreateScan() 
    {
        yield return new WaitUntil(() => s.lightState == 2);

        objectToEnable.SetActive(true);
    }
}
