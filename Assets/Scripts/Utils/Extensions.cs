using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

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

    public static string GetBindingControlPath(this InputAction action, string controlScheme) {
        var bindingIndex = action.GetBindingIndex(group: controlScheme);
        var displayString = action.GetBindingDisplayString(bindingIndex, out var device, out var controlPath);
        
        if (device.Contains("X"))
            device = "XInputController";
        else if (device.Contains("DualShock"))
            device = "DualShockGamepad";

        return controlPath;
    } 
}
