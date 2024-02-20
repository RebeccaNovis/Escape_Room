using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject doorVoid;

    //public BoxCollider voidCollider;

    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        //voidCollider = doorVoid.GetComponent<BoxCollider>();

        doorVoid.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScene.name == "SlotsTutorial")
        {
            if (InsertBattery.isRedInserted)
            {
                RevealDoor();
            }
            else
            {
                CloseDoor();
            }
        }

        if (currentScene.name == "FirstSlotPuzzle")
        {
            if (InsertBattery.isRedInserted && InsertBattery.isPinkInserted)
            {
                RevealDoor();
            }
            else
            {
                CloseDoor();
            }
        }

        if (currentScene.name == "SecondSlotPuzzle")
        {
            if (InsertBattery.isRedInserted && InsertBattery.isPinkInserted && InsertBattery.isBlueInserted)
            {
                RevealDoor();
            }
            else
            {
                CloseDoor();
            }
        }

        if (currentScene.name == "ThirdPuzzle")
        {
            if (InsertBattery.isRedInserted && InsertBattery.isPinkInserted)
            {
                RevealDoor();
            }
            else
            {
                CloseDoor();
            }
        }

        if (currentScene.name == "FourthPuzzle")
        {
            if (InsertBattery.isPurpleInserted)
            {
                RevealDoor();
            }
            else
            {
                CloseDoor();
            }
        }

    }

    public void RevealDoor()
    {
        //Destroy(closedDoor);
        closedDoor.SetActive(false);
        doorVoid.SetActive(true);
    }

    public void CloseDoor()
    {
        closedDoor.SetActive(true);
        doorVoid.SetActive(false);
    }
}
