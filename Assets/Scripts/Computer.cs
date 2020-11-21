using UnityEngine;

public class Computer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning;
    public bool isEmpty = true;

    public delegate void StopTimerAction(bool isStop);

    public event StopTimerAction stopTimerEvent;

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                stopTimerEvent?.Invoke(timerIsRunning);
            }
        }
    }
}