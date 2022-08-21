using UnityEngine.Rendering;

public abstract class PostFXEffect {
    public abstract void Initialize(PostFXHandler postFXHandler, Volume volume);
    public abstract void Trigger();
}
