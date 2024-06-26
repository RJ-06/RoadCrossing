using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTips : MonoBehaviour
{
    [SerializeField] AudioClip[] tips;
    AudioSource thisAudio;

    void Start()
    {
        thisAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null)
            return;

        AudioClip tip = tips[Random.Range(0, tips.Length)];
        thisAudio.clip = tip;
        thisAudio.Play();
    }
}
