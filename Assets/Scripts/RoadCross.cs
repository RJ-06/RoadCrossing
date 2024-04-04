using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCross : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ScanArea s;

    private bool shouldCross;


    void Start()
    {
        //use eventmanager to make it add the scoring function so when you score it does the function
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startRoadCrossing() 
    {
        //Danial to do:
        //instantiate new ScanArea
        //if ScanArea has been completed, set the bool shouldCross to true
    }

    private void OnTriggerEnter(Collider other)
    {
        if (shouldCross) 
        {
            if (other.GetComponent<PlayerController>()) 
            {
                
            }
        }
    }
}
