using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameters))]
public class Player : MonoBehaviour
{
    public delegate void PlayerDied();
    public static event PlayerDied OnPlayerDied;

    private PlayerParameters parameters;

    private Dictionary<float, Vector3> pointsInTime;

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();
        pointsInTime = new Dictionary<float, Vector3>();

        Timer.OnTimeIsOut += Die;
        Stabilizer.OnPlayerEnter += SetUnactive;
    }

    private void SetUnactive()
    {
        parameters.SetIsAlive(false);
    }

    public void Die()
    {
        Debug.LogWarning("!!!Player's dread!!!");
        parameters.SetIsAlive(false);

        OnPlayerDied?.Invoke();
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

    private void OnDisable()
    {
        Timer.OnTimeIsOut -= Die;
        Stabilizer.OnPlayerEnter -= SetUnactive;
    }
}
