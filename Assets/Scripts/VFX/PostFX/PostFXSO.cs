using UnityEngine;
using UnityEngine.Rendering;

public abstract class PostFXSO : ScriptableObject {
    [SerializeField] protected VolumeProfile _profile;
    
    public abstract void Trigger();
}
