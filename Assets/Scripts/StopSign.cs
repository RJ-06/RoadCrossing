using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    [SerializeField] RoadNode r;
    [SerializeField] RoadNode[] next;
    [SerializeField] Car car;
    [SerializeField] float stopTime;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator stopCar() 
    {
        if (car.currentNode == r)
        {
            foreach (RoadNode node in next)
            {
                node.canMoveTo = false;
            }
        }
        yield return new WaitForSeconds(stopTime);

        foreach (RoadNode node in next) 
        {
            node.canMoveTo = true;
        }
        
    }
}
