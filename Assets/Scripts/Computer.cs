using UnityEngine;

public class Computer : MonoBehaviour
{
    public float timeRemaining = 10;
    private bool _timerIsRunning = true;

    public delegate void StopTimerAction(bool isStop);

    public delegate void IsEmptyAction(bool isEmpty);

    public event StopTimerAction StopTimerEvent;
    public event IsEmptyAction IsEmptyEvent;

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (_timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                
                StopTimerEvent?.Invoke(_timerIsRunning);
                IsEmptyEvent?.Invoke(false);
            }
            else
            {
                timeRemaining = 0;
                _timerIsRunning = false;
                
                StopTimerEvent?.Invoke(_timerIsRunning);
                IsEmptyEvent?.Invoke(true);
            }
        }
    }
}