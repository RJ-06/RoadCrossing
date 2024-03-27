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
        
    }

    // Update is called once per frame
    void Update()
    {
        car = r.carAtNode;

        if (car != null)
        {
            StartCoroutine(stopCar());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (car != null)
        {
            StartCoroutine(stopCar());
        }
    }

    IEnumerator stopCar()
    {
        foreach (RoadNode node in next)
        {
            node.canMoveTo = false;
        }

        yield return new WaitForSecondsRealtime(stopTime);

        foreach(RoadNode node in next)
        {
            node.canMoveTo = true;
        }
    }

    
}
