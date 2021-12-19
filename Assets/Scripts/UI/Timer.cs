using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 
    public delegate void TimeIsOut();
    public static event TimeIsOut OnTimeIsOut;

    public Text indicator;

    [SerializeField] private float timeRemaining;
    private bool isCounting;

    private void Start()
    {
        PlayerMovement.OnStartMoving += StartCountdown;
        Stabilizer.OnPlayerEnter += StopCountdown;

        DisplayTimer(timeRemaining);
    }

    public void StartCountdown()
    {
        isCounting = true;
        PlayerMovement.OnStartMoving -= StartCountdown;
    }

    public void StopCountdown()
    {
        isCounting = false;
    }

    private void Update()
    {
        if (isCounting)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0f;
                isCounting = false;

                TimeRanOut();
            }

            DisplayTimer(timeRemaining);
        }
    }

    private void TimeRanOut()
    {
        Debug.LogWarning("!!! TIME IS OUT !!!");
        OnTimeIsOut?.Invoke();
    }

    private string FormatTime() 
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        float milliSeconds = (timeRemaining % 1) * 1000;

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    private void DisplayTimer(float time)
    {
        indicator.text = FormatTime();
    }

    public string GetTimeAsString()
    {
        return FormatTime();
    }

    private void OnDisable()
    {
        PlayerMovement.OnStartMoving -= StartCountdown;
        Stabilizer.OnPlayerEnter -= StopCountdown;
    }
}
