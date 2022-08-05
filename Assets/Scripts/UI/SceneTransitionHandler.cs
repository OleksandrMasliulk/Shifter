using UnityEngine;
using System.Threading.Tasks;

public class SceneTransitionHandler : MonoBehaviour
{
    [SerializeField] private string _transitionInClipName;
    [SerializeField] private string _transitionOutClipName;

    [SerializeField] private Animation _animation;

    public async Task TransitionIn() {
        Task task = _animation.AnimationAsTask(_transitionInClipName);
        await task;
    }

    public async Task TransitionOut() {
        Task task = _animation.AnimationAsTask(_transitionOutClipName);
        await task;
    }
}
