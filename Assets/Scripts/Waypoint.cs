using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem p;

    private void Awake()
    {
        p.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            return;

        Scoring.onCross();
        this.gameObject.SetActive(false);
    }
}
