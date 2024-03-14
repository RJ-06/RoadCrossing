using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] RoadNode[] r;
    [SerializeField] Car car;
    private int lightState;

    void Start()
    {
        car = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void redLight() 
    {
        foreach(RoadNode node in r)
            node.canMoveTo = false;
    }

    private void yellowLight() 
    {
        Rigidbody rb = car.getrb();
        rb.velocity *= .4f;
    }

    private void greenLight() 
    {
        foreach (RoadNode node in r)
            node.canMoveTo = true;
    }

    private void changeLight() 
    {
        switch (lightState) //cycles between the stoplight states
        {
            case 0:
                greenLight();
                lightState = 1;
                break;
            case 1:
                yellowLight();
                lightState = 2;
                break;
            case 2:
                redLight();
                lightState = 0;
                break;
            default:
                break;
        }
    }
}
