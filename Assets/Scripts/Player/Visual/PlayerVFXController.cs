using UnityEngine;
using Zenject;

public class PlayerVFXController : MonoBehaviour {
    [Header("Movement Particles")]
    [SerializeField] private ParticleSystem _stepParticles;
    [SerializeField] private ParticleSystem _jumpParticles;
    [SerializeField] private ParticleSystem _wallSlideParticles;      
    [SerializeField] private ParticleSystem _wallJumpParticles;

    [Header("Time Unstability Particles")]
    [SerializeField] private ParticleSystem _blinkStartParticles;
    [SerializeField] private ParticleSystem _blinkEndParticles;
    [SerializeField] private ParticleSystem _desyncParticles;
    [SerializeField] private ParticleSystem _collapseParticles;

    [SerializeField] private PostFXSO _blinkPostFX;

    private PlayerBlinkController _blinkController;

    [Inject]
    public void Construct(PlayerBlinkController blinkController) {
        _blinkController = blinkController;
    }

    public void PlayJumpParticles() {
        _jumpParticles.Play();
    }

    public void PlayWallJumpParticles() {
        _wallJumpParticles.Play();
    }

    private void PlayBlinkStartParticles() {
        _blinkStartParticles.Play();
    }

    private void PlayBlinkEndParticles() {
        _blinkEndParticles.Play();
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

    private void StopDesyncParticles() {
        _desyncParticles.Stop();
    }

    private void PlayCollapseParticles() {
        _collapseParticles.Play();
    }

    private void PlayBlinkPostFX() {
        _blinkPostFX.Trigger();
    }

    private void OnEnable() {
        _blinkController.OnAfterBlink += PlayBlinkPostFX;
        _blinkController.OnBeforeBlink += PlayBlinkStartParticles;
        _blinkController.OnAfterBlink += PlayBlinkEndParticles;
    }

    private void OnDisable() {
        _blinkController.OnAfterBlink -= PlayBlinkPostFX;
        _blinkController.OnBeforeBlink -= PlayBlinkStartParticles;
        _blinkController.OnAfterBlink -= PlayBlinkEndParticles;
    }
}
