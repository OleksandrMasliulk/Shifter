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
        GameController.OnCameraZoomedIn += StartCountdown;

        DisplayTimer(timeRemaining);
    }

    public void StartCountdown()
    {
        isCounting = true;
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

    private void DisplayTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliSeconds = (time % 1) * 1000;

        indicator.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    private void OnDisable()
    {
        GameController.OnCameraZoomedIn -= StartCountdown;
    }
}
