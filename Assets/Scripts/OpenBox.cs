using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OpenBox : MonoBehaviour
{
    [SerializeField] private GameObject[] inputDisplay;
    [SerializeField] private GameObject door;
    [SerializeField] private AudioMixerSnapshot newSnapshot;
    //the time it should take to transition
    public float transitionTime = 1.0f;

    private int inputDisIndex;
    private int[] colorValue = new int[3]; //array of integers to keep track of the colors that have been input. 0 = black, 1 = blue, 2 = red

    public Material redM;
    public Material blueM;
    public Material greenM;
    public Material blackM;

    // Start is called before the first frame update
    void Start()
    {
        inputDisIndex = 0;
        //set color values to 0, since all display boxes are black
        colorValue[0] = 0;
        colorValue[1] = 0;
        colorValue[2] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonControl.isBlueHit || ButtonControl.isRedHit) //check if either of the two buttons are pressed
        {
            if (inputDisIndex < inputDisplay.Length) //check that the index is less than the amount of display boxes
            {
                UpdateInputDisplay(inputDisIndex); //update the color of the coresponding display box
            }

        }

        if (ButtonControl.isEnterHit) //check inputs once enter button is pressed
        {
            Debug.Log("checking inputs...");
            ButtonControl.isEnterHit = false;
            CheckInputs();
            return;
        }
        
    }

    //function to change the colors of the input display boxes
    public void UpdateInputDisplay(int index)
    {
        if (ButtonControl.isBlueHit && !ButtonControl.isRedHit) //if blue is pressed and red is NOT pressed
        {
            inputDisplay[index].GetComponent<Renderer>().material = blueM; //change corresponding display box to blue
            colorValue[index] = 1; //set the color value to "blue" 
            ButtonControl.isBlueHit = false;
            Debug.Log("pressed blue on index: " + index);
            inputDisIndex++;
            return;
        }
        else if (!ButtonControl.isBlueHit && ButtonControl.isRedHit)
        {
            inputDisplay[index].GetComponent<Renderer>().material = redM;
            colorValue[index] = 2;
            ButtonControl.isRedHit = false;
            Debug.Log("pressed red on index: " + index);
            inputDisIndex++;
            return;
        }
    }

    //function to check the inputs for this puzzle
    public void CheckInputs()
    {
        if (colorValue[0] == 1) //if first input was blue, move on to check the next input. Else, it is incorrect and needs to be reset
        {
            Debug.Log("First box correct");
            if (colorValue[1] == 1) //if second input was blue, else reset
            {
                Debug.Log("Second box correct");
                if (colorValue[2] == 2) //if third input was red, open the box!
                {
                    OpenPuzBox();
                    return;
                }
                else
                {
                    Debug.Log("last box wrong");
                    ResetBoxes();
                    return;
                }
            }
            else
            {
                Debug.Log("second box wrong");
                ResetBoxes();
                return;
            }
        }
        else
        {
            Debug.Log("First box wrong");
            ResetBoxes();
            return;
        }
    }

    public void OpenPuzBox()
    {
        Destroy(door);
        inputDisplay[0].GetComponent<Renderer>().material = greenM;
        inputDisplay[1].GetComponent<Renderer>().material = greenM;
        inputDisplay[2].GetComponent<Renderer>().material = greenM;
        newSnapshot.TransitionTo(transitionTime);
    }

    public void ResetBoxes()
    {
        //resets material back to black
        inputDisplay[0].GetComponent<Renderer>().material = blackM;
        inputDisplay[1].GetComponent<Renderer>().material = blackM;
        inputDisplay[2].GetComponent<Renderer>().material = blackM;

        //resets color values back to black
        colorValue[0] = 0;
        colorValue[1] = 0;
        colorValue[2] = 0;

        //reset inputDisIndex so that UpdateInputDisplay() can be called again. Otherwise, inputDisIndex will continue increasing past the inputDisplay[] length
        inputDisIndex = 0;
    }
}
