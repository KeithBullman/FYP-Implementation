using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PracticeSpellingResult : MonoBehaviour
{

    public Text header;
    public Text yourWord;
    public Text mainMessage;

    void Start()
    {
        if(NameController.word != "")
        {
            yourWord.text = "Your Word: " + NameController.word;
            header.text = "Congratulations!";
            if (NameController.word.Length <= 2)
            {
                mainMessage.text = "While this word is valid in the games dictionary, in competitive mode, this spelling round would have earned you " + NameController.practiceWordScore + " points due to the length of the word.";
            }

            else
            {
                mainMessage.text = "Well done, in competitive mode, this spelling round would have earned you " + NameController.practiceWordScore + " points!";
            }
        }

        else
        {
            header.text = "Unlucky!";
            mainMessage.text = "Better luck next time!";
        }
    }

    public void redo()
    {
        SceneManager.LoadScene("PracticeSpelling");
    }

    public void home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
