using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingColors : MonoBehaviour
{
    public Material redM, blueM, yellowM, whiteM, greenM, purpleM, orangeM, brownM;

    [SerializeField] private GameObject battery;
    //[SerializeField] private GameObject batBase;
    private Renderer batRend;

    private bool isBatAttatched = false;

    //private Material currentColor;

    // Start is called before the first frame update
    void Start()
    {
        batRend = battery.GetComponent<Renderer>();
        isBatAttatched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBatAttatched)
        {
            if (ButtonControl.isBlueHit || ButtonControl.isRedHit || ButtonControl.isYellowHit)
            {
                ChangeColor();
            }
            if (ButtonControl.isResetHit)
            {
                ResetColors();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isBatAttatched = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isBatAttatched = false;
    }

    public void ResetColors()
    {
        batRend.material = whiteM;
        ButtonControl.redCount = 0;
        ButtonControl.blueCount = 0;
        ButtonControl.yellowCount = 0;
        ButtonControl.isResetHit = false;
        battery.tag = "whiteBattery";

    }

    public void ChangeColor()
    {
        if (ButtonControl.yellowCount > 0 && ButtonControl.redCount == 0 && ButtonControl.blueCount == 0)
        {
            ButtonControl.isYellowHit = false;
            batRend.material = yellowM;
            battery.tag = "yellowBattery";
        }
        if (ButtonControl.yellowCount == 0 && ButtonControl.redCount > 0 && ButtonControl.blueCount == 0)
        {
            ButtonControl.isRedHit = false;
            batRend.material = redM;
            battery.tag = "redBattery";
        }
        if (ButtonControl.yellowCount == 0 && ButtonControl.redCount == 0 && ButtonControl.blueCount > 0)
        {
            ButtonControl.isBlueHit = false;
            batRend.material = blueM;
            battery.tag = "blueBattery";
        }
        if (ButtonControl.yellowCount > 0 && ButtonControl.redCount > 0 && ButtonControl.blueCount == 0)
        {
            ButtonControl.isYellowHit = false;
            ButtonControl.isRedHit = false;
            batRend.material = orangeM;
            battery.tag = "orangeBattery";
        }
        if (ButtonControl.yellowCount > 0 && ButtonControl.redCount == 0 && ButtonControl.blueCount > 0)
        {
            ButtonControl.isYellowHit = false;
            ButtonControl.isBlueHit = false;
            batRend.material = greenM;
            battery.tag = "greenBattery";
        }
        if (ButtonControl.yellowCount == 0 && ButtonControl.redCount > 0 && ButtonControl.blueCount > 0)
        {
            ButtonControl.isRedHit = false;
            ButtonControl.isBlueHit = false;
            batRend.material = purpleM;
            battery.tag = "purpleBattery";
        }
        if (ButtonControl.yellowCount > 0 && ButtonControl.redCount > 0 && ButtonControl.blueCount > 0)
        {
            ButtonControl.isYellowHit = false;
            ButtonControl.isRedHit = false;
            ButtonControl.isBlueHit = false;
            batRend.material = brownM;
            battery.tag = "brownBattery";
        }
    }
}
