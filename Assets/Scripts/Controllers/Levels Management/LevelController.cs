using UnityEngine;
using System.Collections;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using Zenject;

public class LevelController : MonoBehaviour {
    private InputController _inputController;

    [SerializeField] private SceneTransition _transition;
    [SerializeField] private GameObject _loadingScreen;

    [SerializeField] private LevelSO _mainMenuLevel;
    
    private LevelSO _currentLevel;
    public LevelSO CurrentLevel => _currentLevel;
    
    private LevelSO _levelRequested;
    private bool _useTransition;
    private bool _showLoadingScreen;
    private bool _isLoading;

    private AsyncOperationHandle<SceneInstance> _loadingOperationHandle;

    [Inject]
    public void Construct(InputController inputController) {
        _inputController = inputController;
    }

    public void LoadLevel(LevelSO level, bool useTransition, bool showLoadingScreen) {
        if (_isLoading)
            return;

        _inputController.DisableAllInput();
        _levelRequested = level;
        _isLoading = true;
        _useTransition = useTransition;
        _showLoadingScreen = showLoadingScreen;

        StartCoroutine(UnloadPreviousScene());
    }

    private IEnumerator UnloadPreviousScene() {
        if (_useTransition) {
            _transition.TransitionIn();
            yield return new WaitForSeconds(_transition.TransitionDuration);
        }

        if (_currentLevel != null)
            if (_currentLevel.SceneReference.OperationHandle.IsValid()) {
                _currentLevel.SceneReference.UnLoadScene();
                _currentLevel.SceneReference.ReleaseAsset();
            }

        LoadNewScene();
    } 

    private void LoadNewScene() {
        if (_showLoadingScreen)
            _loadingScreen.SetActive(true);

        _loadingOperationHandle = _levelRequested.SceneReference.LoadSceneAsync();
        _loadingOperationHandle.Completed += OnNewSceneLoaded;
    }

    private void OnNewSceneLoaded(AsyncOperationHandle<SceneInstance> op) {
        _currentLevel = _levelRequested;
        _isLoading = false;

        if (_showLoadingScreen)
            _loadingScreen.SetActive(false);
        if (_useTransition)
            _transition.TransitionOut();
    }

    public void RestartCurrentLevel() {
        LoadLevel(_currentLevel, false, false);
    }

    public void LoadMainMenu() {
        LoadLevel(_mainMenuLevel, true, true);
    }

    private void OnDestroy() {
        if (_currentLevel == null)
            return;

        _currentLevel.SceneReference.ReleaseAsset();
    }
}
