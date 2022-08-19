using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string _transitionInClipName;
    [SerializeField] private string _transitionOutClipName;
    [SerializeField] private Animation _animation;

    public float TransitionDuration => _animation.GetClip(_transitionInClipName).length;

    public void TransitionIn() => _animation.Play(_transitionInClipName);

    public void TransitionOut() => _animation.Play(_transitionOutClipName);
}
