using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; 

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

    public Text input;
    public Text userInput;
    public Text assignedNumber;

    public GameObject bigButton;
    public GameObject smallButton;
    public GameObject addButton;
    public GameObject subtractButton;
    public GameObject multiplyButton;
    public GameObject divideButton;
    public GameObject openBracketButton;
    public GameObject closeBracketButton;

    List<string> lastNumberUsed = new List<string> { };
    List<int> lastDictionaryLocationUsed = new List<int> { };

    List<string> numberInput = new List<string> {"1", "2", "3", "4", "5", "6"};
    Dictionary<int, string> numbers = new Dictionary<int, string>();

    int numberCount = 0;

    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType(typeof(Timer)) as Timer; 
    }

    // Update is called once per frame
    void Update()
    {
        if(numberCount >= 6)
        {
            checkInput();
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

        Debug.Log(test - 5);

    }

    public void swapButtonActivity()
    {
        input.text = "INPUT: ______________";
        smallButton.SetActive(false);
        bigButton.SetActive(false);
        addButton.SetActive(true);
        subtractButton.SetActive(true);
        multiplyButton.SetActive(true);
        divideButton.SetActive(true);
        openBracketButton.SetActive(true);
        closeBracketButton.SetActive(true);
    }

    public void add()
    {
        userInput.text += "+";
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

            case "1":
                if (numbers[1] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    userInput.text += numbers[1];
                    lastNumberUsed.Add(numbers[1]);
                    lastDictionaryLocationUsed.Add(1);
                    numbers[1] = "";
                    displayAvailableNumbers();
                }
                break;

            case "2":
                if (numbers[2] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    userInput.text += numbers[2];
                    lastNumberUsed.Add(numbers[2]);
                    lastDictionaryLocationUsed.Add(2);
                    numbers[2] = "";
                    displayAvailableNumbers();
                }
                break;

            case "3":
                if (numbers[3] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    userInput.text += numbers[3];
                    lastNumberUsed.Add(numbers[3]);
                    lastDictionaryLocationUsed.Add(3);
                    numbers[3] = "";
                    displayAvailableNumbers();
                }
                break;

            case "4":
                if (numbers[4] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    userInput.text += numbers[4];
                    lastNumberUsed.Add(numbers[4]);
                    lastDictionaryLocationUsed.Add(4);
                    numbers[4] = "";
                    displayAvailableNumbers();
                }
                break;

            case "5":
                if (numbers[5] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    userInput.text += numbers[5];
                    lastNumberUsed.Add(numbers[5]);
                    lastDictionaryLocationUsed.Add(5);
                    numbers[5] = "";
                    displayAvailableNumbers();
                }
                break;

            case "6":
                if (numbers[6] == "")
                {
                    Debug.Log("noway");
                }
                else
                {
                    userInput.text += numbers[6];
                    lastNumberUsed.Add(numbers[6]);
                    lastDictionaryLocationUsed.Add(6);
                    numbers[6] = "";
                    displayAvailableNumbers();
                }
                break;

            case "\b":

                //userInput.text = userInput.text.Remove(userInput.text.Length - (lastNumberUsed[lastNumberUsed.Count - 1]).Length);
                //numbers[lastDictionaryLocationUsed[lastDictionaryLocationUsed.Count - 1]] = lastNumberUsed[lastNumberUsed.Count - 1];
                //displayAvailableNumbers();

                Debug.Log("LASTNUM: " + lastNumberUsed[lastNumberUsed.Count-1]);
                Debug.Log("LASTDICLOC: " + lastDictionaryLocationUsed[lastDictionaryLocationUsed.Count - 1]);
                Debug.Log("LASTNUMLENGTH: " + ((lastNumberUsed[lastNumberUsed.Count - 1]).Length));

                userInput.text = userInput.text.Remove(userInput.text.Length - (lastNumberUsed[lastNumberUsed.Count - 1]).Length);

                numbers[lastDictionaryLocationUsed[lastDictionaryLocationUsed.Count - 1]] = lastNumberUsed[lastNumberUsed.Count - 1];

                lastNumberUsed.Remove(lastNumberUsed[lastNumberUsed.Count-1]);
                lastDictionaryLocationUsed.Remove(lastDictionaryLocationUsed[lastDictionaryLocationUsed.Count - 1]);

                displayAvailableNumbers();

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

}
