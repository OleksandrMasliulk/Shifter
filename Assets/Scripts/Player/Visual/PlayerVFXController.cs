using UnityEngine;

public class PlayerVFXController : MonoBehaviour {
    [SerializeField] private ParticleSystem _stepParticles;
    [SerializeField] private ParticleSystem _jumpParticles;

    public void PlayJumpParticles() {
        _jumpParticles.Play();
    }

    private void PlayStepParticles() {
        if (_stepParticles.isPlaying)
            return;

        _stepParticles.Play();
    } 

    private void StopStepParticles() {
        if (_stepParticles.isStopped)
            return;

        _stepParticles.Stop();
    } 
}
