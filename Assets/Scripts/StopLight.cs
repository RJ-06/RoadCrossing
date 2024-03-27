using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] RoadNode[] r;
    //[SerializeField] Car car;
    private int lightState = 0;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    void Start()
    {
        //car = GetComponent<Car>();
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
        
    }

    private void greenLight() 
    {
        foreach (RoadNode node in r)
            node.canMoveTo = true;
    }

    IEnumerator changeLight() 
    {
        Debug.Log("changed state: " + lightState);
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
