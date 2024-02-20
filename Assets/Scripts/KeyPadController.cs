using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyPadController : MonoBehaviour
{
    public GameObject button; //the visible part of the button that we see move up and down when we push it
    public UnityEvent onPress; //adds a customizable event in the Inspector
    public UnityEvent onRelease; //adds a customizable event in the Inspector

    public float buttonStartingPosX;
    public float buttonStartingPosY;
    public float buttonStartingPosZ;

    //public static bool is1Hit, is2Hit, is3Hit, is4Hit, is5Hit, is6Hit, is7Hit, is8Hit, is9Hit, is0Hit, isResetHit, isEnterHit = false;
    public static bool[] whatButtonsHit = new bool[12];
    //public int buttonPressed;

    private XRBaseInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(ButtonPushed); //everytime we hover over the interactable, the PowerOn function is called
        interactable.hoverExited.AddListener(ResetPosition); //everytime we exit hover, the ResetPosition function is called

        buttonStartingPosX = button.transform.position.x;
        buttonStartingPosY = button.transform.position.y;
        buttonStartingPosZ = button.transform.position.z;

        for(int i = 0; i < whatButtonsHit.Length; i++)
        {
            whatButtonsHit[i] = false;
        }
    }

    public void ButtonPushed(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            button.transform.localPosition = new Vector3(buttonStartingPosX, buttonStartingPosY, buttonStartingPosZ - 0.0146f); //moves the button down
            onPress.Invoke(); //calls whatever function you want to happen when you press the button. set the function in the inspector
        }
    }

    public void ResetPosition(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            button.transform.localPosition = new Vector3(buttonStartingPosX, buttonStartingPosY, buttonStartingPosZ); //moves the button back to starting position
        }
    }

    public void TrackingInput()
    {
        if (button.name == "1 button")
        {
            whatButtonsHit[1] = true;
        } 
    }
}
