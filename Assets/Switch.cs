using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Data;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{

    public Text greeting;

    void Start(){
        greeting.text = "Welcome, " + NameController.usernamee + "!";
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SpellingTutorial()
    {
        SceneManager.LoadScene("HowToSpell");
    }
    public void PlaySpelling(){
        SceneManager.LoadScene("PracticeSpelling");
    }

    public void MathTutorial()
    {
        SceneManager.LoadScene("HowToMath");
    }
    public void PlayMathematics(){
        SceneManager.LoadScene("PracticeMath");
    }

    public void PlayCompetitive()
    {
        NameController.currentScore = 0;
        NameController.roundCounter = 1;
        SceneManager.LoadScene("Spelling");
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
