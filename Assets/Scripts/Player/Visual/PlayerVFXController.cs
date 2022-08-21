using UnityEngine;
using Zenject;

public class PlayerVFXController : MonoBehaviour {
    [SerializeField] private ParticleSystem _stepParticles;
    [SerializeField] private ParticleSystem _jumpParticles;
    [SerializeField] private ParticleSystem _wallSlideParticles;      
    [SerializeField] private ParticleSystem _wallJumpParticles;

    [SerializeField] private PostFXSO _blinkPostFX;

    private PlayerBlinkController _blinkController;
    private PostFXHandler _postFXHandler;

    [Inject]
    public void Construct(PostFXHandler postFXHandler, PlayerBlinkController blinkController) {
        _postFXHandler = postFXHandler;
        _blinkController = blinkController;
    }

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

    private void PlayBlinkPostFX() {
        _blinkPostFX.Trigger();
    }

    private void OnEnable() {
        _blinkController.OnBlink += PlayBlinkPostFX;
    }

    private void OnDisable() {
        _blinkController.OnBlink -= PlayBlinkPostFX;
    }
}
