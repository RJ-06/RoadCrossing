using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeCar : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject[] c;

    void Start()
    {
        GameObject car = Instantiate(c[Random.Range(0,c.Length)],this.transform);
        var bc = GetComponent<BoxCollider>();
        bc.transform.position = car.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
