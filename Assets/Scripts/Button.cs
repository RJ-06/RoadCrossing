using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    // Reference to the game object you want to enable
    public GameObject objectToEnable;
    [SerializeField] StopLight s;
    [SerializeField] WaitingBox waitHere;

    // Define any actions you want to occur when the button is clicked
    public void OnMouseDown()
    {
        // Check if the click happened on this GameObject
        Debug.Log("Button clicked!");

        // Enable the specified game object
        objectToEnable.SetActive(true);
        //StartCoroutine(CreateScan());
    }

    IEnumerator CreateScan() 
    {
        //requires the light to be red and the player to be waiting in the yellow box
        Debug.Log(waitHere.getWaiting());
        yield return new WaitUntil(() => s.lightState == 2 && waitHere.getWaiting()); 

        objectToEnable.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
