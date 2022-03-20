using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{

    public void PlaySpelling(){
        SceneManager.LoadScene("Spelling");
    }

    public void PlayMathematics(){
        SceneManager.LoadScene("Math");
    }

    public void QuitGame(){
    Debug.Log("Exited Game, Thanks for Playing!");
    Application.Quit();
    }
}
