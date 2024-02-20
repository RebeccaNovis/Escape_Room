using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource source;
    private bool hasSoundPlayed = false;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("purpleBattery"))
        {
            if(hasSoundPlayed == false)
            {
                source.Play();
                Debug.Log("audio.Play Called");
                hasSoundPlayed = true;
            } else
            {
                Debug.Log("asound aldready played");
            }

        }


    }
}
