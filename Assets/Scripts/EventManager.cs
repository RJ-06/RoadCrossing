using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

public class EventManager : MonoBehaviour
{
    // Dictionary to store event flags keyed by event names
    private Dictionary<string, bool> eventFlags = new Dictionary<string, bool>();
    [SerializeField] string[] eventNames;
    [SerializeField] public int score = 0;

    // Singleton instance
    public static EventManager instance;
    public static EventManager Instance{get;}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) Destroy(this);

        // Initialize event flags with event names as keys and default value false
        foreach (string eventName in eventNames)
        {
            eventFlags.Add(eventName, false);
        }
    }

    // Function to reset all event flags
    public void ResetEvents()
    {
        eventFlags.Clear();
    }

    // Function to set the flag for a specific event
    public void SetEventFlag(string eventName, bool value)
    {
        if (eventFlags.ContainsKey(eventName))
        {
            eventFlags[eventName] = value;
        }
        else
        {
            eventFlags.Add(eventName, value);
        }
    }

    // Function to get the flag for a specific event
    public bool GetEventFlag(string eventName)
    {
        if (eventFlags.ContainsKey(eventName))
        {
            return eventFlags[eventName];
        }
        else
        {
            Debug.LogWarning("Event flag not found for event: " + eventName);
            return false;
        }
    }
}
