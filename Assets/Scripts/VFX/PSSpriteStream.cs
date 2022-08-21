using UnityEngine;

public class PSSpriteStream : MonoBehaviour {
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ParticleSystem _ps;

    private void Update() {
        if (_ps.textureSheetAnimation.GetSprite(0) == _renderer.sprite)
            return;

        _ps.textureSheetAnimation.SetSprite(0, _renderer.sprite);
    }
}
