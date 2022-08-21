using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using System.Collections;
using UnityEngine.Rendering;

public static class Extensions {
    public static async Task AnimationAsTask(this Animation anim, string animName)  {
        anim.Play(animName);
        float animDuration = anim.GetClip(animName).length;
        int delay = (int)(animDuration * 1000);
        await Task.Delay(delay);    
    }

    public static async Task<T> LoadAssetAsyncSafe<T>(this AssetReference reference) {
        T returnAsset = default(T);

        if (reference.IsValid()) {
            if (!reference.OperationHandle.IsDone) {
                reference.OperationHandle.Completed += (op) => {
                    returnAsset = (T)op.Result;
                };
                await reference.OperationHandle.Task;
            }
            else
                returnAsset = (T)reference.OperationHandle.Result;
        }
        else {
            var op = reference.LoadAssetAsync<T>();
            op.Completed += (op) => {
                returnAsset = op.Result;
            };
            await op.Task;
        }

        return returnAsset;
    } 
}
