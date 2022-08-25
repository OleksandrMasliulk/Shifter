using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Keybindings", menuName = "Keybindings")]
public class KeybindingsRepositorySO : ScriptableObject {
    [SerializeField] private TMP_SpriteAsset _spriteAsset;
    public TMP_SpriteAsset SpriteAsset => _spriteAsset;
    [SerializeField] private Keybinding[] _bindings;

    public bool TryGetSprite(string path, out string spriteTag, out string key) {
        key = path;
        foreach(Keybinding binding in _bindings) {
            if (binding.keyPath == path) {
                spriteTag = binding.SpriteTag;
                return true;
            }
        }
        spriteTag = null;
        return false;
    }

    [System.Serializable]
    public struct Keybinding {
        public string keyPath;
        [SerializeField] private int overrideSpriteIndex;
        public string SpriteTag => $"<sprite={overrideSpriteIndex}>";
    }
}
