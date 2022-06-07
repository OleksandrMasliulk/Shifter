using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SceneTransitionHandler : MonoBehaviour
{
    public static SceneTransitionHandler Instance { get; private set; }

    [SerializeField] private string transitionInClipName;
    [SerializeField] private string transitionOutClipName;

    [SerializeField] private Animation anim;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public async Task TransitionIn()
    {
        Task task = anim.AnimationAsTask(transitionInClipName);

        await task;
    }

    public async Task TransitionOut()
    {
        Task task = anim.AnimationAsTask(transitionOutClipName);

        await task;
    }
}
