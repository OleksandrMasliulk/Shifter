using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static string FloatToTime(float timeInSecs)
    {
        float minutes = Mathf.FloorToInt(timeInSecs / 60);
        float seconds = Mathf.FloorToInt(timeInSecs % 60);
        float milliSeconds = (timeInSecs % 1) * 1000;

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
