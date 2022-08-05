using UnityEngine;
using System.Threading.Tasks;

public class LevelLoader : MonoBehaviour {
    public static LevelLoader Instance { get; private set; }
    
    [SerializeField] private SceneTransitionHandler _transitionHandler;
    [SerializeField] private GameObject _loadingScreen;

    [SerializeField] private LevelSO _mainMenuLevel;
    private LevelSO _currentLevel;
    public LevelSO CurrentLevel => _currentLevel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

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
            _currentLevel = null;
            _currentLevel.SceneReference.ReleaseAsset();
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
        Instance = null;
        _currentLevel.SceneReference.ReleaseAsset();
    }
}
