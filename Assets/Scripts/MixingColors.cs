using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingColors : MonoBehaviour
{
    public Material redM, blueM, yellowM, whiteM, greenM, purpleM, orangeM, brownM, magentaM, cyanM;

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
            if (ButtonControl.isBlueMixingHit || ButtonControl.isRedMixingHit || ButtonControl.isYellowRBYHit || ButtonControl.isYellowCMYHit || ButtonControl.isCyanHit || ButtonControl.isMagentaHit)
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
        battery = other.gameObject;
        batRend = battery.GetComponent<Renderer>();
        isBatAttatched = true;
        Debug.Log("material on enter: " + batRend.material);
    }

    private void OnTriggerExit(Collider other)
    {
        isBatAttatched = false;
        ButtonControl.redMixingCount = 0;
        ButtonControl.blueMixingCount = 0;
        ButtonControl.yellowRBYCount = 0;
        ButtonControl.magentaCount = 0;
        ButtonControl.cyanCount = 0;
        ButtonControl.yellowCMYCount = 0;
        Debug.Log("material on exit: " + batRend.material);
    }

    public void ResetColors()
    {
        batRend.material = whiteM;
        ButtonControl.redMixingCount = 0;
        ButtonControl.blueMixingCount = 0;
        ButtonControl.yellowRBYCount = 0;

        ButtonControl.magentaCount = 0;
        ButtonControl.cyanCount = 0;
        ButtonControl.yellowCMYCount = 0;
        ButtonControl.isResetHit = false;
        battery.tag = "whiteBattery";

    }

    public void ChangeColor()
    {
        //color mixing for Red Blue Yellow
        if (ButtonControl.yellowRBYCount > 0 && ButtonControl.redMixingCount == 0 && ButtonControl.blueMixingCount == 0)
        {
            ButtonControl.isYellowRBYHit = false;
            batRend.material = yellowM;
            battery.tag = "yellowBattery";
        }
        if (ButtonControl.yellowRBYCount == 0 && ButtonControl.redMixingCount > 0 && ButtonControl.blueMixingCount == 0)
        {
            ButtonControl.isRedHit = false;
            batRend.material = redM;
            battery.tag = "redBattery";
        }
        if (ButtonControl.yellowRBYCount == 0 && ButtonControl.redMixingCount == 0 && ButtonControl.blueMixingCount > 0)
        {
            ButtonControl.isBlueHit = false;
            batRend.material = blueM;
            battery.tag = "blueBattery";
        }
        if (ButtonControl.yellowRBYCount > 0 && ButtonControl.redMixingCount > 0 && ButtonControl.blueMixingCount == 0)
        {
            ButtonControl.isYellowRBYHit = false;
            ButtonControl.isRedHit = false;
            batRend.material = orangeM;
            battery.tag = "orangeBattery";
        }
        if (ButtonControl.yellowRBYCount > 0 && ButtonControl.redMixingCount == 0 && ButtonControl.blueMixingCount > 0)
        {
            ButtonControl.isYellowRBYHit = false;
            ButtonControl.isBlueHit = false;
            batRend.material = greenM;
            battery.tag = "greenBattery";
        }
        if (ButtonControl.yellowRBYCount == 0 && ButtonControl.redMixingCount > 0 && ButtonControl.blueMixingCount > 0)
        {
            ButtonControl.isRedHit = false;
            ButtonControl.isBlueHit = false;
            batRend.material = purpleM;
            battery.tag = "purpleBattery";
        }
        if (ButtonControl.yellowRBYCount > 0 && ButtonControl.redMixingCount > 0 && ButtonControl.blueMixingCount > 0)
        {
            ButtonControl.isYellowRBYHit = false;
            ButtonControl.isRedHit = false;
            ButtonControl.isBlueHit = false;
            batRend.material = brownM;
            battery.tag = "brownBattery";
        }

        //color mixing for Cyan Yellow Magenta
        if (ButtonControl.yellowCMYCount > 0 && ButtonControl.magentaCount == 0 && ButtonControl.cyanCount == 0)
        {
            ButtonControl.isYellowRBYHit = false;
            batRend.material = yellowM;
            battery.tag = "yellowBattery";
        }
        if (ButtonControl.yellowCMYCount == 0 && ButtonControl.magentaCount > 0 && ButtonControl.cyanCount == 0)
        {
            ButtonControl.isMagentaHit = false;
            batRend.material = magentaM;
            battery.tag = "magentaBattery";
        }
        if (ButtonControl.yellowCMYCount == 0 && ButtonControl.magentaCount == 0 && ButtonControl.cyanCount > 0)
        {
            ButtonControl.isCyanHit = false;
            batRend.material = cyanM;
            battery.tag = "cyanBattery";
        }
        if (ButtonControl.yellowCMYCount > 0 && ButtonControl.magentaCount > 0 && ButtonControl.cyanCount == 0)
        {
            ButtonControl.isYellowCMYHit = false;
            ButtonControl.isMagentaHit = false;
            batRend.material = redM;
            battery.tag = "redBattery";
        }
        if (ButtonControl.yellowCMYCount > 0 && ButtonControl.magentaCount == 0 && ButtonControl.cyanCount > 0)
        {
            ButtonControl.isYellowCMYHit = false;
            ButtonControl.isCyanHit = false;
            batRend.material = greenM;
            battery.tag = "greenBattery";
        }
        if (ButtonControl.yellowCMYCount == 0 && ButtonControl.magentaCount > 0 && ButtonControl.cyanCount > 0)
        {
            ButtonControl.isMagentaHit = false;
            ButtonControl.isCyanHit = false;
            batRend.material = blueM;
            battery.tag = "blueBattery";
        }
        if (ButtonControl.yellowCMYCount > 0 && ButtonControl.magentaCount > 0 && ButtonControl.cyanCount > 0)
        {
            ButtonControl.isYellowCMYHit = false;
            ButtonControl.isMagentaHit = false;
            ButtonControl.isCyanHit = false;
            batRend.material = brownM;
            battery.tag = "brownBattery";
        }
    }
}
