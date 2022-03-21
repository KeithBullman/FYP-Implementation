using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Math : MonoBehaviour
{

    public Text number1;
    public Text number2;
    public Text number3;
    public Text number4;
    public Text number5;
    public Text number6;

    public Text assignedNumber;

    int numberCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getSmall(){

            int test = 5;
            string randomNumber = test.ToString();
            
            switch(numberCount){
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
                    break;
            }
            numberCount++;
        }

        public void getBig(){

            int randomNumber = Random.Range(11, 100);
            
            switch(numberCount){
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
                    break;
            }
            numberCount++;
        }

        public void getAssignedNumber(){

            int randomNumber = Random.Range(100, 999);

            assignedNumber.text += randomNumber.ToString();

        }

}
