using UnityEngine;
using System;
using Zenject;

public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDied;

    private TimerController _timeController;

    [Inject]
    public void Construct(TimerController timeController) {
        _timeController = timeController;
    }

    public void Die() {
        Debug.LogWarning("!!!Player's dead!!!");
    
        OnPlayerDied?.Invoke();
    }

    private void OnEnable() => _timeController.OnTimeIsOut += Die;

    private void OnDisable() => _timeController.OnTimeIsOut -= Die;
}
