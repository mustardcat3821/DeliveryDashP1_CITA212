using UnityEngine;
using TMPro;

public class timerLoop : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 60f;
    [SerializeField] public bool timerIsRunning = false;
    [SerializeField] public bool isCountingDown = true;
    [SerializeField] private TextMeshProUGUI TimerText;



    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (!timerIsRunning)
        {
            return;
        }

        if (isCountingDown)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                TimerDone();
            }
        }

        else
        {
            timeRemaining += Time.deltaTime;
        }

        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        TimerText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
    }

    void TimerDone()
    {
        TimerText.text = "Time Left: 00:00";
        Debug.Log("Timer has finished!");
    }

}