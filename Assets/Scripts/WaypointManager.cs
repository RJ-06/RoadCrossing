using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Waypoint[] waypoints;
    public int TarWaypoint = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextWP() 
    {
        waypoints[TarWaypoint].enabled = false;
        TarWaypoint++;
        waypoints[TarWaypoint].enabled = true;
        Scoring.onScore();
    }
}
