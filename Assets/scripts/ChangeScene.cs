using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public void ChangeScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        QuestionManager.score = 0;

    }
    public void ExitGame()
    {
       
        
        Application.Quit();
        print("Exit game");
        
    }
}
