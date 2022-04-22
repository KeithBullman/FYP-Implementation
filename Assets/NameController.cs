using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameController : MonoBehaviour
{
    //store username for main menu
    public static string usernamee;

    //store score as you progress through rounds for sending to database if playing competitive mode
    public static int roundCounter;
    public static int currentScore;

    //store word and score for practice spelling mode
    public static string word;
    public static int practiceWordScore;

    //store number, target number and score for practice math mode
    public static int practiceMathResult;
    public static int practiceMathTarget;
    public static int practiceMathScore;
}
