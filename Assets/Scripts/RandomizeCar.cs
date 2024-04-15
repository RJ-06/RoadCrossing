using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeCar : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject[] c;

    void Start()
    {
        Instantiate(c[Random.Range(0,c.Length)],this.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
