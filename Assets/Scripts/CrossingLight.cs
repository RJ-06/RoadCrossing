using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingLight : MonoBehaviour
{
    //script to change the crossing light (could probably just use an animation but this works)
    [SerializeField] StopLight s;
    int ls;
    [SerializeField] GameObject[] symbols;
    [SerializeField] Light[] lights;

    void Start()
    {
        StartCoroutine(ChangeLight());
    }

    void Update()
    {
        ls = s.lightState;
        /*if (ls == 2)
        {
            symbols[0].SetActive(true);
            symbols[1].SetActive(false);
            lights[0].enabled = true;
            lights[1].enabled = false;
        }
        else 
        {
            symbols[0].SetActive(false);
            symbols[1].SetActive(true);
            lights[0].enabled = false;
            lights[1].enabled = true;
        }
        */
        
    }

    IEnumerator ChangeLight() 
    {
        while (true) 
        {
            if (ls == 2)
            {
                yield return new WaitUntil(() => ls != 2);
                symbols[0].SetActive(false);
                symbols[1].SetActive(true);
                lights[0].enabled = false;
                lights[1].enabled = true;

            }
            else
            {
                yield return new WaitUntil(() => ls == 2);
                symbols[0].SetActive(true);
                symbols[1].SetActive(false);
                lights[0].enabled = true;
                lights[1].enabled = false;
            }
        }
    }
}
