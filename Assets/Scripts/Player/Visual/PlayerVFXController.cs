using UnityEngine;

public class PlayerVFXController : MonoBehaviour {
    [SerializeField] private ParticleSystem _stepParticles;
    [SerializeField] private ParticleSystem _jumpParticles;
    [SerializeField] private ParticleSystem _wallSlideParticles;      
    [SerializeField] private ParticleSystem _wallJumpParticles;

    public void PlayJumpParticles() {
        _jumpParticles.Play();
    }

    public void PlayWallJumpParticles() {
        _wallJumpParticles.Play();
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

    private void PlayWallSlideParticles() {
        if (_wallSlideParticles.isPlaying)
            return;

        _wallSlideParticles.Play();
    } 

    private void StopWallSlideParticles() {
        if (_wallSlideParticles.isStopped)
            return;

        _wallSlideParticles.Stop();
    }
}
