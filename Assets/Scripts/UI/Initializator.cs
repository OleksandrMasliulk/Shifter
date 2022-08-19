using UnityEngine;
using Zenject;
using UnityEngine.Localization.Settings;
using System.Threading.Tasks;

public class Initializator : MonoBehaviour {
    private LevelController _levelLoader;

    [Inject]
    public void Construct(LevelController levelLoader) {
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
