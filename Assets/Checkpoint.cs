using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{

    public GameObject continueButton;
    public GameObject submitButton;
    public GameObject homeButton;

    public Text message;
    public Text pointsAcquired;
    public Text currentScore;
    public Text nextRound;

    PlayfabManager playfabManager;

    // Start is called before the first frame update
    void Start()
    {

        currentScore.text = "Current Score: " + NameController.currentScore.ToString();
        pointsAcquired.text = "Points Acquired This Round: " + NameController.pointsAcquired.ToString();

        getNextRound();

        if (NameController.successfulRound)
        {
            message.text = "Good work so far! You can rest here as long as you like, if you wish to move onto the next round, click 'Continue', otherwise you can also leave competitive mode.";
        }
        else
        {
            if(NameController.roundCounter < 6)
            {
                message.text = "Better luck in the next round! You can rest here as long as you like, if you wish to move onto the next round, click 'Continue', otherwise you can also leave competitive mode.";
            }
        }


        if(NameController.roundCounter < 6)
        {
            continueButton.SetActive(true);
        }

        else
        {
            message.text = "Well done! You have just completed a full session, hopefully you have strengthened your critical thinking abilities from this experience. Thanks for playing! :))";
            submitButton.SetActive(true);
        }

        homeButton.SetActive(true);

    }

    public void getNextRound()
    {
        switch (NameController.roundCounter + 1)
        {
            case 2:
                nextRound.text = "Checkpoint (Next Round: Math)";
                break;

            case 3:
                nextRound.text = "Checkpoint (Next Round: Spelling)";
                break;

            case 4:
                nextRound.text = "Checkpoint (Next Round: Spelling)";
                break;

            case 5:
                nextRound.text = "Checkpoint (Next Round: Math)";
                break;

            case 6:
                nextRound.text = "Checkpoint (Next Round: Spelling)";
                break;
        }
    }

    public void Continue()
    {
        NameController.roundCounter += 1;

        switch (NameController.roundCounter)
        {
            case 2:
                SceneManager.LoadScene("Math");
                break;

            case 3:
                SceneManager.LoadScene("Spelling");
                break;

            case 4:
                SceneManager.LoadScene("Spelling");
                break;

            case 5:
                SceneManager.LoadScene("Math");
                break;

            case 6:
                SceneManager.LoadScene("Spelling");
                break;

        }

    }

    public void GoLeaderboard()
    {
        playfabManager = new PlayfabManager();
        playfabManager.SendLeaderboard(NameController.currentScore);
        SceneManager.LoadScene("Leaderboard");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
