using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 
    public static Timer Instance { get; private set; }

    public delegate void TimeIsOut();
    public static event TimeIsOut OnTimeIsOut;

    public Text indicator;

    private float timeRemaining;
    private bool isCounting;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Init(float timeForLevel)
    {
        timeRemaining = timeForLevel;

        PlayerMovement.OnStartMoving += StartCountdown;
        GameController.OnPlayerWin += StopCountdown;

        UpdateTimer(timeRemaining);
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

            UpdateTimer(timeRemaining);
        }
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

    private void TimeRanOut()
    {
        Debug.LogWarning("!!! TIME IS OUT !!!");
        OnTimeIsOut?.Invoke();
    }

    private void UpdateTimer(float time)
    {
        indicator.text = Utils.FloatToTime(time);
    }

    public float GetTime()
    {
        return timeRemaining;
    }

    private void OnDisable()
    {
        GameController.OnPlayerWin -= StopCountdown;
    }
}
