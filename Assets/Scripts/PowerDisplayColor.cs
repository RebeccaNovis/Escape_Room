using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDisplayColor : MonoBehaviour
{
    //public InsertBattery insertBattery = new InsertBattery();
    [SerializeField] private Material powerOn;
    [SerializeField] private Material powerOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "redPowerDisplay")
        {
            if (InsertBattery.isRedInserted)
            {
                gameObject.GetComponent<Renderer>().material = powerOn;
            } else if (!InsertBattery.isRedInserted)
            {
                gameObject.GetComponent<Renderer>().material = powerOff;
            }
        }

        if (gameObject.tag == "bluePowerDisplay")
        {
            if (InsertBattery.isBlueInserted)
            {
                gameObject.GetComponent<Renderer>().material = powerOn;
            }
            else if (!InsertBattery.isBlueInserted)
            {
                gameObject.GetComponent<Renderer>().material = powerOff;
            }
        }

        if (gameObject.tag == "pinkPowerDisplay")
        {
            if (InsertBattery.isPinkInserted)
            {
                gameObject.GetComponent<Renderer>().material = powerOn;
            }
            else if (!InsertBattery.isPinkInserted)
            {
                gameObject.GetComponent<Renderer>().material = powerOff;
            }
        }

        if (gameObject.tag == "purplePowerDisplay")
        {
            if (InsertBattery.isPurpleInserted)
            {
                gameObject.GetComponent<Renderer>().material = powerOn;
            }
            else if (!InsertBattery.isPurpleInserted)
            {
                gameObject.GetComponent<Renderer>().material = powerOff;
            }
        }
    }
}
