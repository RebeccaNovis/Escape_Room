using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetSnapshot : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot initialSnap;

    public static bool isPatternComplete;
    //public static bool is

    //the time it should take to transition
    public float transitionTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        initialSnap.TransitionTo(transitionTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
