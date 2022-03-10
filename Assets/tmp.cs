using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tmp : MonoBehaviour
{

    public void PlayGame(){
        SceneManager.LoadScene("Spelling");
    }

    public void QuitGame(){
        Debug.Log("QUIT");
        Application.Quit();
    }
}
