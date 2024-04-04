using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] RoadNode[] rStop;
    //[SerializeField] Car car;
    private int lightState = 0;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    [SerializeField] RoadNode[] slowDownPoints;
    [SerializeField] float slowDownSpeed;
    private List<float> speedList = new List<float>();

    private Dictionary<int,string> colorDict = new Dictionary<int,string>();

    void Start()
    {
        //car = GetComponent<Car>();
        colorDict.Add(0, "green");
        colorDict.Add(1, "yellow");
        colorDict.Add(2, "red");

        foreach (RoadNode node in slowDownPoints)
        {
            speedList.Add(node.speed);
        }

        StartCoroutine(changeLight());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void redLight() 
    {


        foreach (RoadNode node in rStop)
            node.canMoveTo = false;
    }

    private void yellowLight() 
    {
        foreach(RoadNode node in slowDownPoints) 
        {
            node.speed *= slowDownSpeed;
        }
    }

    private void greenLight() 
    {
        for (int i = 0; i < slowDownPoints.Length; i++)
        {
            slowDownPoints[i].speed = speedList[i];
        }


        foreach (RoadNode node in rStop)
        {
            node.canMoveTo = true;
        }

    }

    IEnumerator changeLight() 
    {
        while(true)
        {
            Debug.Log("changed state: " + colorDict[lightState]);
            switch (lightState) //cycles between the stoplight states
            {

                case 0:
                    greenLight();
                    lightState = 1;
                    yield return new WaitForSeconds(Random.Range(minTime, maxTime));
                    break;
                case 1:
                    yellowLight();
                    lightState = 2;
                    yield return new WaitForSeconds(0.3f*Random.Range(minTime, maxTime));
                    break;
                case 2:
                    redLight();
                    lightState = 0;
                    yield return new WaitForSeconds(Random.Range(minTime, maxTime));
                    break;
                default:
                    break;
            }
            
        }


       
    }
}