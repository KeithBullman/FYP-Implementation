using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameController : MonoBehaviour
{
    //store username for main menu
    public static string usernamee;
    public static int userHighScore;

    //store score as you progress through rounds for sending to database if playing competitive mode

    public static int yourNumber;
    public static int targetNumber;
    
    public static int roundCounter;
    public static int currentScore;
    public static int pointsAcquired;
    public static bool successfulRound;

    //store word and score for practice spelling mode
    public static string word;
    public static int practiceWordScore;

    //store number, target number and score for practice math mode
    public static int practiceMathResult;
    public static int practiceMathTarget;
    public static int practiceMathScore;
}
