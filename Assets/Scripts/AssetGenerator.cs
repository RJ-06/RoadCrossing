using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AssetGenerator : MonoBehaviour
{
    [SerializeField] (GameObject,float)[] decorations;
    [SerializeField] float decoCap;
    [SerializeField] float radius;
    // Start is called before the first frame update
    void Awake()
    {
        while (decoCap > 0) 
        {
            var objectPlace = decorations[Random.Range(0, decorations.Length)];
            GameObject obj = objectPlace[0];
            var 
        }
    }
}
