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
    public UnityEvent noPower; //unity event for when trying to use something that needs power
    public static bool isLightCubeOn = false;

    //button down/up positions
    private Vector3 buttonDownPos;
    private Vector3 buttonUpPos;
    private float buttonUpX;
    private float buttonUpY;
    private float buttonUpZ;

    //red and blue counts for pattern test
    public static int redCount = 0;
    public static int blueCount = 0;

    //color counts for mixing
    public static int redMixingCount = 0;
    public static int blueMixingCount = 0;
    public static int yellowCMYCount = 0; //yellow used when mixing cyan/magenta/yellow
    public static int yellowRBYCount = 0; //yellow when mixing red/blue/yellow
    public static int magentaCount = 0;
    public static int cyanCount = 0;
    
    //checks what button is hit on pattern test
    public static bool isRedHit = false;
    public static bool isBlueHit = false;
    public static bool isEnterHit = false;

    //checks what buttons are hit on mixing tables
    public static bool isRedMixingHit = false;
    public static bool isBlueMixingHit = false;
    public static bool isYellowCMYHit = false; //yellow used when mixing cyan/magenta/yellow
    public static bool isYellowRBYHit = false; //yellow when mixing red/blue/yellow
    public static bool isMagentaHit = false;
    public static bool isCyanHit = false;
    public static bool isResetHit = false;


    private XRBaseInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        redCount = 0;
        blueCount = 0;
        yellowRBYCount = 0;
        isLightCubeOn = false;
        isRedHit = false;
        isBlueHit = false;
        isYellowRBYHit = false;
        isEnterHit = false;
        isResetHit = false;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(PowerOn); //everytime we hover over the interactable, the PowerOn function is called
        interactable.hoverExited.AddListener(ResetPosition); //everytime we exit hover, the ResetPosition function is called

        buttonUpPos = button.transform.localPosition;
        Debug.Log("button pos:" + buttonUpPos);
        buttonUpX = buttonUpPos.x;
        buttonUpY = buttonUpPos.y;
        buttonUpZ = buttonUpPos.z;
        buttonDownPos = new Vector3(buttonUpX, (buttonUpY - .003810924f), buttonUpZ);
        
    }

    public void PowerOn(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            button.transform.localPosition = buttonDownPos; //moves the button down
            onPress.Invoke(); //calls whatever function you want to happen when you press the button. set the function in the inspector
        }
    }

    public void ResetPosition(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            button.transform.localPosition = buttonUpPos; //moves the button back to starting position
            onRelease.Invoke(); //calls whatever function/what you want to happen when you remove finger from button
        }
    }

    public void ChangeLightCubePower()
    {
        if (InsertBattery.isPinkInserted)
        {
            if (!isLightCubeOn)
            {
                isLightCubeOn = true;
            }
            else if (isLightCubeOn)
            {
                isLightCubeOn = false;
            }
        }
        else if (!InsertBattery.isPinkInserted)
        {
            noPower.Invoke();
        }

    }

    public void TrackingButtonPattern()
    {
        if (InsertBattery.isPinkInserted)
        {
            if (button.tag == "redSlot")
            {
                redCount += 1;
                isRedHit = true;
            }
            if (button.tag == "blueSlot")
            {
                blueCount += 1;
                isBlueHit = true;
            }
            if (button.tag == "enterButton")
            {
                isEnterHit = true;
            }
            if (button.tag == "revertButton")
            {
                isResetHit = true;
            }
        } else if (!InsertBattery.isPinkInserted)
        {
            noPower.Invoke();
        }
    }

    public void TrackingElementMix()
    {
        //checking colors on cyan/magenta/yellow mixing table
        if (button.tag == "magentaButton")
        {
            magentaCount += 1;
            isMagentaHit = true;
        }
        if (button.tag == "cyanButton")
        {
            cyanCount += 1;
            isCyanHit = true;
        }
        if (button.tag == "yellowButtonCMY")
        {
            yellowCMYCount += 1;
            isYellowCMYHit = true;
        }

        //checking colors on red/blue/yellow mixing table
        if (button.tag == "redButton")
        {
            redMixingCount += 1;
            isRedMixingHit = true;
        }
        if (button.tag == "blueButton")
        {
            blueMixingCount += 1;
            isBlueMixingHit = true;
        }
        if (button.tag == "yellowButtonRBY")
        {
            yellowRBYCount += 1;
            isYellowRBYHit = true;
        }

        //reset
        if (button.tag == "revertButton")
        {
            isResetHit = true;
        }
    }



}
