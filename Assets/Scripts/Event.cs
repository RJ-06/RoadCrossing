using UnityEngine;

public class Event : MonoBehaviour
{
    public string eventName;
    // Function to trigger an event by setting its flag to true
    public void TriggerEvent()
    {
        EventManager.Instance.SetEventFlag(eventName, true);
    }
}
