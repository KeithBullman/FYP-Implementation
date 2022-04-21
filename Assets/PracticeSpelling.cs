using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System.Threading;

public class PracticeSpelling : MonoBehaviour
{
    public Text letter1;
    public Text letter2;
    public Text letter3;
    public Text letter4;
    public Text letter5;
    public Text letter6;
    public Text letter7;
    public Text letter8;
    public Text letter9;

    public Text input;
    public Text tmp;
    public Text userInput;

    int letterCount = 0;
    string remainingWord;
    string allTogether;

    public GameObject clock;
    public GameObject consonantButton;
    public GameObject vowelButton;
    public GameObject userDisplay;

    PlayfabManager playfabManager;
    public Timer timer;
    TestDB testDb;

    //other way of changing text
    // public GameObject changingTextTwo;
    //use in textChange method to update gameObject text to be new string
    //changingTextTwo.GetComponent<Text>().text = "" + randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        NameController.practiceWordScore = 0;
        NameController.word = "";
        timer = FindObjectOfType(typeof(Timer)) as Timer;
        playfabManager = new PlayfabManager();
        testDb = new TestDB();

        // GameObject playfab = new GameObject("PlayfabManager");
        // playfabManager = playfab.AddComponent<PlayfabManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (letterCount >= 9)
        {
            checkInput();

            float result = timer.GetTime();

            if (result == 0)
            {
                fixFormat();
                if (testDb.ReadDB(userInput.text) == true)
                {
                    NameController.word = userInput.text;
                    getScore();
                    Debug.Log("WORD EXISTS");
                }
                else
                {
                    Debug.Log("NO WORD");
                }
                SceneManager.LoadScene("PracticeSpellingResult");
            }
        }
    }

    // public void TextChange(){

    //     int randomNumber = Random.Range(0, 10);

    //     if(randomNumber >= 5){
    //         letter1.text="hi";
    //     }
    //     else{
    //         letter.text="no";
    //     }
    // }

    public void getConsonant()
    {
        string consonants = "BCDFGHJKLMNPQRSTVWXYZ";
        int randomNumber = Random.Range(0, 20);
        char selected = consonants[randomNumber];
        allTogether += selected;

        switch (letterCount)
        {
            case 0:
                letter1.text += selected;
                break;
            case 1:
                letter2.text += selected;
                break;
            case 2:
                letter3.text += selected;
                break;
            case 3:
                letter4.text += selected;
                break;
            case 4:
                letter5.text += selected;
                break;
            case 5:
                letter6.text += selected;
                break;
            case 6:
                letter7.text += selected;
                break;
            case 7:
                letter8.text += selected;
                break;
            case 8:
                letter9.text += selected;
                printAll();
                timer.TimerTrigger();
                changePriority();
                break;
        }
        letterCount++;
    }

    public void getVowel()
    {
        string consonants = "AEIOU";
        int randomNumber = Random.Range(0, 4);
        char selected = consonants[randomNumber];
        allTogether += selected;

        switch (letterCount)
        {
            case 0:
                letter1.text += selected;
                break;
            case 1:
                letter2.text += selected;
                break;
            case 2:
                letter3.text += selected;
                break;
            case 3:
                letter4.text += selected;
                break;
            case 4:
                letter5.text += selected;
                break;
            case 5:
                letter6.text += selected;
                break;
            case 6:
                letter7.text += selected;
                break;
            case 7:
                letter8.text += selected;
                break;
            case 8:
                letter9.text += selected;
                printAll();
                timer.TimerTrigger();
                changePriority();
                break;
        }
        letterCount++;
    }

    public void printAll()
    {
        tmp.text = allTogether;
    }

    public void setInputDisplay()
    {
        input.text = "Your Word";
    }

    public void checkInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                enterLetter(keysPressed);
            }
        }
    }

    public void enterLetter(string letter)
    {

        if (letter == "\b")
        {
            if (userInput.text.Length >= 1)
            {
                allTogether += userInput.text[userInput.text.Length - 1];
                userInput.text = userInput.text.Remove(userInput.text.Length - 1);

            }
        }

        else if (allTogether.Contains(letter.ToUpper()))
        {
            userInput.text += letter.ToUpper();
            var regex = new Regex(Regex.Escape(letter.ToUpper()));
            allTogether = regex.Replace(allTogether, "", 1);

        }
        printAll();
    }

    public void fixFormat()
    {
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        TextInfo textInfo = cultureInfo.TextInfo;
        userInput.text = userInput.text.ToLower();
        userInput.text = textInfo.ToTitleCase(userInput.text);
    }

    public void changePriority()
    {
        setInputDisplay();
        consonantButton.SetActive(false);
        vowelButton.SetActive(false);
        userDisplay.SetActive(true);
        clock.SetActive(true);
        letter1.text = "";
        letter2.text = "";
        letter3.text = "";
        letter4.text = "";
        letter5.text = "";
        letter6.text = "";
        letter7.text = "";
        letter8.text = "";
        letter9.text = "";
    }

    public void getScore()
    {
        switch (userInput.text.Length)
        {
            case 1:
                NameController.practiceWordScore = 0;
                break;

            case 2:
                NameController.practiceWordScore = 0;
                break;

            case 3:
                NameController.practiceWordScore = 1;
                break;

            case 4:
                NameController.practiceWordScore = 2;
                break;

            case 5:
                NameController.practiceWordScore = 3;
                break;

            case 6:
                NameController.practiceWordScore = 4;
                break;

            case 7:
                NameController.practiceWordScore = 5;
                break;

            case 8:
                NameController.practiceWordScore = 6;
                break;

            case 9:
                NameController.practiceWordScore = 10;
                break;
        }
    }

}
