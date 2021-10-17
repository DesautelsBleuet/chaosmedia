using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float timer = 300;
    bool timerIsRunning = true;
    public Text timeText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning) //https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                DisplayTime(timer);
            }
            else {
                Debug.Log("The End");
                timer = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
{
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
