using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Data;
using UnityEngine.SceneManagement;

public class Math : MonoBehaviour
{

    public Text number1;
    public Text number2;
    public Text number3;
    public Text number4;
    public Text number5;
    public Text number6;

    public Text availableNumber1;
    public Text availableNumber2;
    public Text availableNumber3;
    public Text availableNumber4;
    public Text availableNumber5;
    public Text availableNumber6;
    public GameObject availableNumbers;

    public Text input;
    public Text userInput;
    public Text assignedNumber;

    public Text score;
    public Text currentRound;

    public bool numRequired = true;

    public GameObject bigButton;
    public GameObject smallButton;
    public GameObject addButton;
    public GameObject subtractButton;
    public GameObject multiplyButton;
    public GameObject divideButton;
    public GameObject clock;
    public GameObject userInputGUI;
    public GameObject assignedNumberGUI;
    public GameObject numbersBox;

    List<string> lastNumberUsed = new List<string> { };
    List<int> lastDictionaryLocationUsed = new List<int> { };

    List<string> numberInput = new List<string> {"a", "b", "c", "d", "e", "f"};
    List<string> operators = new List<string> { "+", "-", "*", "/" };

    Dictionary<int, string> numbers = new Dictionary<int, string>();

    int numberCount = 0;

    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        NameController.yourNumber = 0;
        NameController.targetNumber = 0;

        timer = FindObjectOfType(typeof(Timer)) as Timer;
        score.text = "Score: " + NameController.currentScore.ToString();
        currentRound.text = "Round #: " + NameController.roundCounter.ToString() + "/6";
    }

    // Update is called once per frame
    void Update()
    {
        if(numberCount >= 6)
        {
            checkInput();

            float result = timer.GetTime();

            if (result == 0)
            {
                calculate();
                SceneManager.LoadScene("Checkpoint");
            }

        }
    }

    public void getSmall(){

        int randomNumber = Random.Range(1, 10);
        numbers.Add(numberCount+1, randomNumber.ToString());

        switch (numberCount){
                case 0:
                    number1.text += randomNumber;
                    break;
                case 1:
                    number2.text += randomNumber;
                    break;
                case 2:
                    number3.text += randomNumber;
                    break;
                case 3:
                    number4.text += randomNumber;
                    break;
                case 4:
                    number5.text += randomNumber;
                    break;
                case 5:
                    number6.text += randomNumber;
                    getAssignedNumber();
                    timer.TimerTrigger();
                    swapButtonActivity();
                    displayAvailableNumbers();
                    break;
            }
            numberCount++;
        }

    public void getBig(){

        //int randomNumber = Random.Range(11, 100);

        List<int> list = new List<int> { 25, 50, 75, 100 };
        int random = Random.Range(0, 4);
        int randomNumber = list[random];

        numbers.Add(numberCount+1, randomNumber.ToString());

        switch (numberCount){
            case 0:
                number1.text += randomNumber;
                break;
            case 1:
                number2.text += randomNumber;
                break;
            case 2:
                number3.text += randomNumber;
                break;
            case 3:
                number4.text += randomNumber;
                break;
            case 4:
                number5.text += randomNumber;
                break;
            case 5:
                number6.text += randomNumber;
                getAssignedNumber();
                timer.TimerTrigger();
                swapButtonActivity();
                displayAvailableNumbers();
                break;
        }
        numberCount++;
    }

    public void getAssignedNumber(){

        int randomNumber = Random.Range(100, 999);

        assignedNumber.text += randomNumber.ToString();

        int test = System.Convert.ToInt32(assignedNumber.text);

    }

    public void swapButtonActivity()
    {
        input.text = "Your Equation";
        clock.SetActive(true);
        smallButton.SetActive(false);
        bigButton.SetActive(false);
        addButton.SetActive(true);
        subtractButton.SetActive(true);
        multiplyButton.SetActive(true);
        divideButton.SetActive(true);
        userInputGUI.SetActive(true);
        assignedNumberGUI.SetActive(true);
        availableNumbers.SetActive(true);
        numbersBox.SetActive(true);

        number1.text = "";
        number2.text = "";
        number3.text = "";
        number4.text = "";
        number5.text = "";
        number6.text = "";
    }

    public void add()
    {
        if (!numRequired)
        {
            userInput.text += "+";
            numRequired = true;
        }
    }

    public void subtract()
    {
        if (!numRequired)
        {
            userInput.text += "-";
            numRequired = true;
        }
    }
    public void multiply()
    {
        if (!numRequired)
        {
            userInput.text += "*";
            numRequired = true;
        }
    }
    public void divide()
    {
        if (!numRequired)
        {
            userInput.text += "/";
            numRequired = true;
        }
    }

    public void checkInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (numberInput.Contains(keysPressed) || keysPressed == "\b")
            {
                enterNumber(keysPressed);
            }
        }
    }

    public void enterNumber(string numberPressed)
    {

        switch (numberPressed)
        {
            case "a":
                if (numbers[1] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    if (numRequired)
                    {
                        userInput.text += numbers[1];
                        lastNumberUsed.Add(numbers[1]);
                        lastDictionaryLocationUsed.Add(1);
                        numbers[1] = "";
                        displayAvailableNumbers();
                        numRequired = false;
                    }
                }
                break;

            case "b":
                if (numbers[2] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    if (numRequired)
                    {
                        userInput.text += numbers[2];
                        lastNumberUsed.Add(numbers[2]);
                        lastDictionaryLocationUsed.Add(2);
                        numbers[2] = "";
                        displayAvailableNumbers();
                        numRequired = false;
                    }
                }
                break;

            case "c":
                if (numbers[3] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    if (numRequired)
                    {
                        userInput.text += numbers[3];
                        lastNumberUsed.Add(numbers[3]);
                        lastDictionaryLocationUsed.Add(3);
                        numbers[3] = "";
                        displayAvailableNumbers();
                        numRequired = false;
                    }
                }
                break;

            case "d":
                if (numbers[4] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    if (numRequired)
                    {
                        userInput.text += numbers[4];
                        lastNumberUsed.Add(numbers[4]);
                        lastDictionaryLocationUsed.Add(4);
                        numbers[4] = "";
                        displayAvailableNumbers();
                        numRequired = false;
                    }
                }
                break;

            case "e":
                if (numbers[5] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    if (numRequired)
                    {
                        userInput.text += numbers[5];
                        lastNumberUsed.Add(numbers[5]);
                        lastDictionaryLocationUsed.Add(5);
                        numbers[5] = "";
                        displayAvailableNumbers();
                        numRequired = false;
                    }
                }
                break;

            case "f":
                if (numbers[6] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    if (numRequired)
                    {
                        userInput.text += numbers[6];
                        lastNumberUsed.Add(numbers[6]);
                        lastDictionaryLocationUsed.Add(6);
                        numbers[6] = "";
                        displayAvailableNumbers();
                        numRequired = false;
                    }
                }
                break;


            case "\b":

                if (numRequired)
                {
                    userInput.text = userInput.text.Remove(userInput.text.Length - 1);
                    numRequired = false;
                }
                else
                {

                    //userInput.text = userInput.text.Remove(userInput.text.Length - (lastNumberUsed[lastNumberUsed.Count - 1]).Length);
                    //numbers[lastDictionaryLocationUsed[lastDictionaryLocationUsed.Count - 1]] = lastNumberUsed[lastNumberUsed.Count - 1];
                    //displayAvailableNumbers();

                    Debug.Log("LASTNUM: " + lastNumberUsed[lastNumberUsed.Count - 1]);
                    Debug.Log("LASTDICLOC: " + lastDictionaryLocationUsed[lastDictionaryLocationUsed.Count - 1]);
                    Debug.Log("LASTNUMLENGTH: " + ((lastNumberUsed[lastNumberUsed.Count - 1]).Length));

                    userInput.text = userInput.text.Remove(userInput.text.Length - (lastNumberUsed[lastNumberUsed.Count - 1]).Length);

                    numbers[lastDictionaryLocationUsed[lastDictionaryLocationUsed.Count - 1]] = lastNumberUsed[lastNumberUsed.Count - 1];

                    lastNumberUsed.Remove(lastNumberUsed[lastNumberUsed.Count - 1]);
                    lastDictionaryLocationUsed.Remove(lastDictionaryLocationUsed[lastDictionaryLocationUsed.Count - 1]);

                    displayAvailableNumbers();
                    numRequired = true;
                }

                    break;
                
        }

    }

    public void displayAvailableNumbers()
    {
        int counter = 1;

        foreach(var value in numbers)
        {
            switch (counter)
            {
                case 1:
                    availableNumber1.text = value.Value;
                    break;
                case 2:
                    availableNumber2.text = value.Value;
                    break;
                case 3:
                    availableNumber3.text = value.Value;
                    break;
                case 4:
                    availableNumber4.text = value.Value;
                    break;
                case 5:
                    availableNumber5.text = value.Value;
                    break;
                case 6:
                    availableNumber6.text = value.Value;
                    break;
            }
            counter++;
        }
    }

    public void calculate()
    {

        int temptarget = System.Convert.ToInt32(assignedNumber.text);
        NameController.targetNumber = temptarget;

        if (userInput.text == "")
        {
            Debug.Log("ANSWER: " + 0);
            NameController.currentScore += 0;
            NameController.pointsAcquired = 0;
            NameController.successfulRound = false;
        }

        else
        {
            char lastChar = userInput.text[userInput.text.Length - 1];

            if (operators.Contains(lastChar.ToString()))
            {
                userInput.text = userInput.text.Remove(userInput.text.Length - 1);
            }

            //int howManyOpen = (userInput.text).Count(f => (f == '('));
            //int howManyClosed = (userInput.text).Count(f => (f == ')'));

            //Debug.Log("OPEN: " + howManyOpen);
            //Debug.Log("CLOSED: " + howManyClosed);

            Debug.Log("EQUATION: " + userInput.text);
            DataTable dt = new DataTable();
            var v = dt.Compute(userInput.text, "");
            Debug.Log("ANSWER: " + v);

            int tempresult = System.Convert.ToInt32(v);
            NameController.practiceMathResult = tempresult;
            NameController.yourNumber = tempresult;

            int difference = temptarget - tempresult;

            int convertedDifference = System.Math.Abs(difference);

            Debug.Log("TARGET: " + temptarget);

            Debug.Log(convertedDifference);

            switch (convertedDifference)
            {

                case int n when convertedDifference == 0:
                    NameController.currentScore += 10;
                    NameController.pointsAcquired = 10;
                    NameController.successfulRound = true;
                    break;

                case int n when convertedDifference <= 5:
                    NameController.currentScore += 5;
                    NameController.pointsAcquired = 5;
                    NameController.successfulRound = true;
                    break;

                case int n when convertedDifference <= 10:
                    NameController.currentScore += 4;
                    NameController.pointsAcquired = 4;
                    NameController.successfulRound = true;
                    break;

                case int n when convertedDifference <= 15:
                    NameController.currentScore += 3;
                    NameController.pointsAcquired = 3;
                    NameController.successfulRound = true;
                    break;

                case int n when convertedDifference <= 20:
                    NameController.currentScore += 2;
                    NameController.pointsAcquired = 2;
                    NameController.successfulRound = true;
                    break;

                case int n when convertedDifference > 20:
                    NameController.currentScore += 0;
                    NameController.pointsAcquired = 0;
                    NameController.successfulRound = false;
                    break;
            }

        }
    }

}
