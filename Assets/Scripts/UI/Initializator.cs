using UnityEngine;
using Zenject;
using UnityEngine.Localization.Settings;
using System.Threading.Tasks;

public class Initializator : MonoBehaviour {
    private LevelLoader _levelLoader;

    [Inject]
    public void Construct(LevelLoader levelLoader) {
        _levelLoader = levelLoader;
    }  

    private void Start() {
        InitializationSequence();
    }

    private async void InitializationSequence() {
        await InitializeLocales();

        _levelLoader.LoadMainMenu();
    }

    private async Task InitializeLocales() {
        var op = LocalizationSettings.InitializationOperation;
        await op.Task;
    }
}
