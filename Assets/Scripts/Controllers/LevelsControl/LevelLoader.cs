using UnityEngine;
using System.Threading.Tasks;

public class LevelLoader : MonoBehaviour {
    
    [SerializeField] private SceneTransitionHandler _transitionHandler;
    [SerializeField] private GameObject _loadingScreen;

    [SerializeField] private LevelSO _mainMenuLevel;
    private LevelSO _currentLevel;
    public LevelSO CurrentLevel => _currentLevel;

    public async void LoadLevel(LevelSO level) {
        await _transitionHandler.TransitionIn();
        _loadingScreen.SetActive(true);

        if (_currentLevel != null)
            await UnloadCurrentScene();

        var op = level.SceneReference.LoadSceneAsync();
        op.Completed += (op) => _currentLevel = level;

        _loadingScreen.SetActive(false);
        await _transitionHandler.TransitionOut();
    }

    private async Task UnloadCurrentScene() {
        var op = _currentLevel.SceneReference.UnLoadScene();
        op.Completed += (op) => {
            _currentLevel.SceneReference.ReleaseAsset();
            _currentLevel = null;
        };

        await op.Task;
    }

    public void RestartCurrentLevel() {
        _currentLevel.SceneReference.LoadSceneAsync();
    }

    public void LoadMainMenu() {
        LoadLevel(_mainMenuLevel);
    }

    private void OnDestroy() {
        _currentLevel.SceneReference.ReleaseAsset();
    }
}
