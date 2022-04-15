using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Data;

public class Switch : MonoBehaviour
{

    public void PlaySpelling(){
        SceneManager.LoadScene("Spelling");
    }

    public void PlayMathematics(){
        SceneManager.LoadScene("Math");
    }

    public void QuitGame(){

		string message = "1 + 200 * (3 + 4)";
		DataTable dt = new DataTable();
		var v = dt.Compute(message, "");
		Debug.Log(v);

        Debug.Log("Exited Game, Thanks for Playing!");
        Application.Quit();
    }

    public void GoLeaderboard(){
        SceneManager.LoadScene("Leaderboard");
    }
}
