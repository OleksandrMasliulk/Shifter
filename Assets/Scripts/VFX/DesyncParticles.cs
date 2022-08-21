using UnityEngine;

public class DesyncParticles : TimeControlledParticles {
    [SerializeField] private float _minEmission;
    [SerializeField] private float _maxEmission;

    private ParticleSystem.EmissionModule emission;

    private void Awake() {
        emission = _ps.emission;
        emission.rateOverTime = _minEmission;
    }
    
    private void Update() {
        emission.rateOverTime = Mathf.Lerp(_minEmission, _maxEmission, _timeController.TimePassed / _timeController.AllocatedTime);
    }
}
