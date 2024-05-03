using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingBox : MonoBehaviour
{
    bool waiting = false;

    private void OnTriggerEnter(Collider other)
    {
        waiting = true;

        /*if (other.GetComponent<PlayerController>() != null) 
        {
            
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        waiting = false;
        /*
        if (other.GetComponent<PlayerController>() != null)
        {
            waiting = false
        }*/
    }

    public bool getWaiting() {return waiting;}

}
