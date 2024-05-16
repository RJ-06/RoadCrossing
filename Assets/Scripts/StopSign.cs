using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    [SerializeField] RoadNode r;
    [SerializeField] RoadNode[] next;
    [SerializeField] Car car;
    [SerializeField] float stopTime;

    bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(stopCar());
    }

    // Update is called once per frame
    void Update()
    {
        car = r.carAtNode;



        if (car != null && stop == false)
        {
            
            StartCoroutine(stopCar());
        }


    }

    
    /*private void OnTriggerStay(Collider other)
    {
        if (car != null)
        {
            StartCoroutine(stopCar());
        }
    }*/

    IEnumerator stopCar()
    {

        foreach (RoadNode node in next)
        {
            node.canMoveTo = false;
        }
        stop = true;
        yield return new WaitForSecondsRealtime(stopTime);

        
        foreach (RoadNode node in next)
        {
            node.canMoveTo = true;
        }
        yield return new WaitForSecondsRealtime(stopTime * .2f);
        stop = false;


    }

    
}
