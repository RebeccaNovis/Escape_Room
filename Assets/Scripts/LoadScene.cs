using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //made with help from this video: https://www.youtube.com/watch?v=JCyJ26cIM0Y&ab_channel=ValemTutorials
    public FadeScreen fadeScreen;
    private Scene currentScene;
    private int nextSceenIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        nextSceenIndex = currentScene.buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void LoadWelcomeRoom()
    {
        StartCoroutine(LoadWelcomeRoomRoutine(0));
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextSceneRoutine());
    }

    IEnumerator LoadNextSceneRoutine()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(nextSceenIndex);
    }

    IEnumerator LoadWelcomeRoomRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}
