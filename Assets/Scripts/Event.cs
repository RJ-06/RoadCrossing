using UnityEngine;

public class Event : MonoBehaviour
{
    // Function to trigger an event by setting its flag to true
    public void TriggerEvent(string eventName)
    {
        EventManager.Instance.SetEventFlag(eventName, true);
    }
}
