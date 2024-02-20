using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPattern : MonoBehaviour
{
    //code assisted with ChatGPT 

    [SerializeField] private Material[] colors;

    public float changeInterval = 5.0f;

    private Renderer boxRend;
    private int currentColorIndex = 0;

    private bool isCoroutineStarted = false;
    private bool isStartOfLoop = false;

    // Start is called before the first frame update
    void Start()
    {
        boxRend = GetComponent<Renderer>(); //get renderer from gameobject
        boxRend.material = colors[0];
    }

    // Update is called once per frame
    void Update()
    {
        //if the button has been pushed to turn the power on AND the coroutine is NOT already started
        if (ButtonControl.isLightCubeOn && !isCoroutineStarted) 
        {
            StartCoroutine(ChangeMaterialLoop()); //starting the coroutine that will change the colors
            isCoroutineStarted = true;
            isStartOfLoop = true;
        } else if(!ButtonControl.isLightCubeOn && isCoroutineStarted) //if power is off AND coroutine is already started
        {
            StopCoroutine(ChangeMaterialLoop()); //stopping the coroutine
            isCoroutineStarted = false;
        }

        if(!ButtonControl.isLightCubeOn && !isCoroutineStarted)
        {
            boxRend.material = colors[0]; //if power off AND coroutine stopped, make the box turn back to black
        }
    
    }

    private IEnumerator ChangeMaterialLoop() //function with an IEnumerator return type
    {
        while (ButtonControl.isLightCubeOn) //loop runs while isRedInserted is true
        {
            yield return new WaitForSeconds(changeInterval); // delay between material changes for the length of time changeInterval
                                                             // is set to. In this case, the default is 5 unless changed in the inspector
            ChangeMaterial(); //runs the ChangeMaterial() function
        }
    }

    private void ChangeMaterial() //This method is responsible for changing the material
    {
        if (isStartOfLoop)
        {
            currentColorIndex = 0;
            isStartOfLoop = false;
        }

        if (colors.Length == 0) //checks if the materials array is empty and returns early if there are no materials assigned.
        {
            return;
        }

        currentColorIndex = (currentColorIndex + 1) % colors.Length; //This line updates the currentIndex by incrementing it and wrapping it back to zero if it exceeds the length of the materials array. This ensures that the index always stays within valid bounds.
        boxRend.material = colors[currentColorIndex]; //sets the material of the object's renderer (boxRend) to the material at the current index from the colors array, effectively changing the material of the object
    }


}
