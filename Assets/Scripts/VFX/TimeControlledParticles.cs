using UnityEngine;
using Zenject;

public abstract class TimeControlledParticles : MonoBehaviour{
    [SerializeField] protected ParticleSystem _ps;
    protected TimerController _timeController;

    [Inject]
    public void Construct(TimerController timerController) {
        _timeController = timerController;
    } 
}
