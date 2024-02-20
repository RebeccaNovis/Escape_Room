using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertBattery : MonoBehaviour
{
    //private bool isBatteryInserted = false;
    //private float insertStartTime = 0f;

    static public bool isRedInserted = false;
    static public bool isBlueInserted = false;
    static public bool isPinkInserted = false;
    static public bool isPurpleInserted = false;
    //public bool isDuoInserted = false;

    private void Start()
    {
        isRedInserted = false;
        isBlueInserted = false;
        isPinkInserted = false;
        isPurpleInserted = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "redBattery" && gameObject.tag == "redSlot") 
        {
            isRedInserted = true;
           // insertStartTime = Time.time;
        }

        if (other.gameObject.tag == "purpleBattery" && gameObject.tag == "blueSlot")
        {
            isBlueInserted = true;
            //insertStartTime = Time.time;
        }

        if (other.gameObject.tag == "pinkBattery" && gameObject.tag == "pinkSlot")
        {
            isPinkInserted = true;
        }

        if (other.gameObject.tag == "purpleBattery" && gameObject.tag == "purpleSlot")
        {
            isPurpleInserted = true;
        }

        /*
        if(gameObject.tag == "duoSlotBlue")
        {
            if (other.gameObject.tag == "duoBatteryBlue")
            {
                isDuoInserted = true;
            }
            else if (other.gameObject.tag == "duoBatteryRed")
            {
                isDuoInserted = false;
                Debug.Log("duo battery interted incorrectly");
            }
        }
        /*if (other.gameObject.tag == "duoBlueBattery" && gameObject.tag == "duoSlotBlue")
        {
            isDuoInserted = true;
        }
        if(other.transform.gameObject.CompareTag("duoBatteryBlue"))
        if(other.gameObject.tag == "duoBatteryBlue")*/


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "redBattery" && gameObject.tag == "redSlot")
        {
            isRedInserted = false;
            //insertStartTime = 0f;
        }

        if (other.gameObject.tag == "purpleBattery" && gameObject.tag == "blueSlot")
        {
            isBlueInserted = false;
        }

        if (other.gameObject.tag == "pinkBattery" && gameObject.tag == "pinkSlot")
        {
            isPinkInserted = false;
        }

        if (other.gameObject.tag == "purpleBattery" && gameObject.tag == "purpleSlot")
        {
            isPurpleInserted = false;
        }

        /*if (other.gameObject.tag == "duoBatteryBlue" && gameObject.tag == "duoSlotBlue")
        {
            isDuoInserted = false;
        } */

    }

    // Update is called once per frame
    void Update()
    {

        //if (isRedInserted && Time.time - insertStartTime >= 5f)

        if(isRedInserted)
        {
            Debug.Log("Red battery has been inserted: " + isRedInserted);
        }

        if (isBlueInserted)
        {
            Debug.Log("Blue battery has been inserted: " + isBlueInserted);
        }

        if (isPinkInserted)
        {
            Debug.Log("Pink battery has been inserted: " + isPinkInserted);
        }

        /*if (isDuoInserted)
        {
            Debug.Log("Duo battery has been inserted:" + isDuoInserted);
        }*/

    }
}
