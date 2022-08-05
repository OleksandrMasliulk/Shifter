using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerTimeBody : MonoBehaviour {
    private Dictionary<float, Vector3> _pointsInTime;

    private void Awake() => _pointsInTime = new Dictionary<float, Vector3>();

    private void FixedUpdate() => RecordPosition();

    private void RecordPosition() => _pointsInTime.Add(Time.fixedTime, transform.position);

    public Vector3 GetPointInTime(float time) {
        if (_pointsInTime.ContainsKey(time))
            return _pointsInTime[time];
        else
            return Vector3.zero;
    }
}
