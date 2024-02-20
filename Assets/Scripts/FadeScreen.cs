using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    //made with help from this video: https://www.youtube.com/watch?v=JCyJ26cIM0Y&ab_channel=ValemTutorials

    public float fadeDuration = 1f;
    public Color fadeColor;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        FadeIn();
        
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration); //gradually fades the alpha value of the color (the opacity) 

            rend.material.SetColor("_BaseColor", newColor);

            timer += Time.deltaTime; //increases timer value by time passed in game
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a =alphaOut; //changes the alpha value of the color (the opacity) 

        rend.material.SetColor("_BaseColor", newColor2);
    }
}
