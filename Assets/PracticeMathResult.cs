using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PracticeMathResult : MonoBehaviour
{
    public Text header;
    public Text yourResult;
    public Text targetNumber;
    public Text differenceNumber;
    public Text mainMessage;


    // Start is called before the first frame update
    void Start()
    {
        yourResult.text = "Your Result:" + NameController.practiceMathResult.ToString();
        targetNumber.text = "Target: " + NameController.practiceMathTarget.ToString();
        
        int difference = NameController.practiceMathTarget - NameController.practiceMathResult;
        int convertedDifference = System.Math.Abs(difference);
        differenceNumber.text = "Difference: " + convertedDifference.ToString();


        if(NameController.practiceMathScore > 0)
        {
            header.text = "Congratulations!";
            mainMessage.text = "Well done, in competitive mode, this mathematics round would have earned you " + NameController.practiceMathScore + " points!";
        }

        else
        {
            header.text = "Unlucky!";
            mainMessage.text = "Better luck next time!";
        }
    }

    public void redo()
    {
        SceneManager.LoadScene("PracticeMath");
    }

    public void home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
