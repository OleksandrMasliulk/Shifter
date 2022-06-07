using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public static class Extensions
{
    public static async Task AnimationAsTask(this Animation anim, string animationName) 
    {
        anim.Play(animationName);
        float animDuration = anim.GetClip(animationName).length;

        await Task.Delay((int)animDuration * 1000);    }
}
