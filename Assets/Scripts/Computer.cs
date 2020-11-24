using System;
using Characters;
using Pathfinding;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [HideInInspector] public bool timerIsRunning = true;

    private float _timeRemaining = 60f;

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
        if (timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;

                StopTimerEvent?.Invoke(timerIsRunning);
                IsEmptyEvent?.Invoke(false);
            }
            else
            {
                _timeRemaining = 0;
                timerIsRunning = false;

                StopTimerEvent?.Invoke(timerIsRunning);
                IsEmptyEvent?.Invoke(true);
            }
        }
    }
}