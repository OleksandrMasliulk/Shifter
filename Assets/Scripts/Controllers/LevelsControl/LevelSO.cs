using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "New Level", menuName = "Levels/New Level")]
public class LevelSO : ScriptableObject {
    [Header("General settings")]
    [SerializeField] private AssetReference _sceneReference;
    public AssetReference SceneReference => _sceneReference;
    [SerializeField] private int _index;
    public int Index => _index;
    [SerializeField] private AssetReference _nextLevel;
    public AssetReference NextLevel => _nextLevel;

    [Header("Progression settings")]
    [SerializeField] private bool _isDone;
    public bool IsDone => _isDone;
    [SerializeField] private List<AssetReference> _levelsDoneRequired;

     public async Task<bool> CheckIfUnlocked() {
        if (_levelsDoneRequired.Count == 0)
            return true;

        List<LevelSO> levels = new List<LevelSO>();
        List<Task> loadTasks = new List<Task>();
        foreach(AssetReference reference in _levelsDoneRequired) {
            var op = reference.LoadAssetAsync<LevelSO>();
            loadTasks.Add(op.Task);
            op.Completed += (op) => levels.Add(op.Result);
        }
        await Task.WhenAll(loadTasks);

        foreach (LevelSO level in levels)
            if (!level.IsDone)
                return false;

        return true;
    }
}
