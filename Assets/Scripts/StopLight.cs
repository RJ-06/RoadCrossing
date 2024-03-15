using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] RoadNode[] r;
    [SerializeField] Car car;
    private int lightState;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    void Start()
    {
        car = GetComponent<Car>();
        StartCoroutine(changeLight());
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
        //rb.velocity *= .4f;
        //new idea - have a collision box for each stoplight that can be edited based on stoplight, slowdown is scaled based on stoplight
        //check collision enter
    }

    private void greenLight() 
    {
        foreach (RoadNode node in r)
            node.canMoveTo = true;
    }

    IEnumerator changeLight() 
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
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
    }
}
