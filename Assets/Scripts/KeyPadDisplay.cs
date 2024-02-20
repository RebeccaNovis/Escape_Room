using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPadDisplay : MonoBehaviour
{
    private string[] numbersArray = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

    [SerializeField] private TextMeshProUGUI[] numberDisplayArray = new TextMeshProUGUI[5];

    [SerializeField] private GameObject door;

    private int inputDisIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(KeyPadController.is1Hit == true)
        {
            if (inputDisIndex < numberDisplayArray.Length)
            {
                //UpdateInputDisplay(inputDisIndex);
            }
        }*/
    }
}
