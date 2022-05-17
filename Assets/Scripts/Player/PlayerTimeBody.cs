using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerTimeBody : MonoBehaviour
{
    private Dictionary<float, Vector3> pointsInTime;

    private void Awake()
    {
        pointsInTime = new Dictionary<float, Vector3>();
    }

    private void FixedUpdate()
    {
        RecordPosition();
    }

    private void RecordPosition()
    {
        pointsInTime.Add(Time.fixedTime, transform.position);
    }

    public Vector3 GetPointInTime(float time)
    {
        if (pointsInTime.ContainsKey(time))
        {
            return pointsInTime[time];
        }
        else
        {
            return Vector3.zero;
        }
    }

}
