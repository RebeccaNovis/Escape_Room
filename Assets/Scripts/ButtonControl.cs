using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

//button made using help from the following videoes:
//https://www.youtube.com/watch?v=bts8VkDP_vU&ab_channel=ValemTutorials
//https://www.youtube.com/watch?v=yUmrtwflmeg&list=PLpEoiloH-4eN0_53RMyv9p2oG2BB8uasX&index=39&ab_channel=ValemTutorials
//https://www.youtube.com/watch?v=lPPa9y_czlE&ab_channel=RealaryVR
public class ButtonControl : MonoBehaviour
{
    public GameObject button; //the visible part of the button that we see move up and down when we push it
    public UnityEvent onPress; //adds a customizable event in the Inspector
    public UnityEvent onRelease; //adds a customizable event in the Inspector
    public static bool isLightCubeOn = false;

    public static int redCount = 0;
    public static int blueCount = 0;
    public static int yellowCount = 0;
    public static bool isRedHit = false;
    public static bool isBlueHit = false;
    public static bool isYellowHit = false;
    public static bool isEnterHit = false;
    public static bool isResetHit = false;


    private XRBaseInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        redCount = 0;
        blueCount = 0;
        yellowCount = 0;
        isLightCubeOn = false;
        isRedHit = false;
        isBlueHit = false;
        isYellowHit = false;
        isEnterHit = false;
        isResetHit = false;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(PowerOn); //everytime we hover over the interactable, the PowerOn function is called
        interactable.hoverExited.AddListener(ResetPosition); //everytime we exit hover, the ResetPosition function is called
    }

    public void PowerOn(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            button.transform.localPosition = new Vector3(0.565f, -0.42f, 0.548f); //moves the button down
            onPress.Invoke(); //calls whatever function you want to happen when you press the button. set the function in the inspector
        }
    }

    public void ResetPosition(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            button.transform.localPosition = new Vector3(0.565f, -0.41f, 0.548f); //moves the button back to starting position
        }
    }

    public void ChangeLightCubePower()
    {
        if (!isLightCubeOn)
        {
            isLightCubeOn = true;
        } else if (isLightCubeOn)
        {
            isLightCubeOn = false;
            redCount = 0;
            blueCount = 0;
        }
    }

    public void TrackingButtonPattern()
    {
        if(button.tag == "redSlot")
        {
            redCount += 1;
            isRedHit = true;
        }
        if(button.tag == "blueSlot")
        {
            blueCount += 1;
            isBlueHit = true;
        }
        if(button.tag == "yellowButton")
        {
            yellowCount += 1;
            isYellowHit = true;
        }
        if(button.tag == "enterButton")
        {
            isEnterHit = true;
        }
        if(button.tag == "revertButton")
        {
            isResetHit = true;
        }
    }



}
