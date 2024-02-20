using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewSlots : MonoBehaviour
{
    [SerializeField] private GameObject[] slotArray = new GameObject[4];
    [SerializeField] private GameObject[] powerDisplayArray = new GameObject[3];
    [SerializeField] private Transform[] slotSpawnPoints = new Transform[5];
    private Vector3 slotPos;
    private Quaternion slotRotation;
    private Vector3 powDisplayPos;
    private Quaternion powDisplayRotation;
    //[SerializeField] private Transform[] powerDisplaySpawnPoints = new Transform[5]; should actually be able to just use the other spawn points and just add to the Y

    // Start is called before the first frame update
    void Start()
    {
        slotRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (InsertBattery.isRedInserted)
        {
            slotPos = new Vector3(2.22f, 1.38f, -0.173f);
            slotRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            powDisplayPos = new Vector3(0.667f, 1.44f, 0.49f);

            Instantiate(slotArray[0], slotPos, slotRotation);
            Instantiate(powerDisplayArray[0], powDisplayPos, powDisplayRotation);

        }
        if (InsertBattery.isRedInserted && InsertBattery.isBlueInserted)
        {
            slotPos = new Vector3(2.23f, 1.38f, 3.422f);
            slotRotation = Quaternion.Euler(0.0f, 90f, 0.0f);

            powDisplayPos = new Vector3(2.894f, 1.44f, 4.98f);

            Instantiate(slotArray[1], slotPos, slotRotation);
            Instantiate(powerDisplayArray[1], powDisplayPos, powDisplayRotation);
        }
        if (InsertBattery.isRedInserted && InsertBattery.isBlueInserted && InsertBattery.isPinkInserted)
        {
            slotPos = new Vector3(2.22f, 1.38f, .65f);
            slotRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            for (int i = 0; i < slotArray.Length; i++)
            {
                Destroy(slotArray[i]);
            }
            for (int i = 0; i < powerDisplayArray.Length; i++)
            {
                Destroy(powerDisplayArray[i]);
            }

            Instantiate(slotArray[3], slotPos, slotRotation);
        }
    }
}
