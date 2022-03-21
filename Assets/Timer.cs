using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeValue = 30;
    public Text timeText;
    
    public bool timerStarted = false;
    
    public void TimerTrigger(){
        
        timerStarted = true;

    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(timerStarted){
            if(timeValue > 0){
                timeValue -= Time.deltaTime;
            }
            else{
            timeValue = 0;
            }
            DisplayTime(timeValue);
        }


    }

    void DisplayTime(float timeToDisplay){

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}", seconds);

    }

}
