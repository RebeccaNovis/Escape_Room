using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public GameObject firstText;
    public GameObject secondText;

    void Start()
    {
        firstText.SetActive(true);
        secondText.SetActive(false);
    }
    public void NextText()
    {
        if (firstText.activeSelf)
        {
            firstText.SetActive(false);
            secondText.SetActive(true);
        } else if (secondText.activeSelf)
        {
            firstText.SetActive(true);
            secondText.SetActive(false);
        }
    }
}
