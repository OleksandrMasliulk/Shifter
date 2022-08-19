using UnityEngine;
using System;
using Zenject;
using System.Threading.Tasks;

public class GameController : MonoBehaviour {
    public event Action OnPlayerWin;
    public enum GameState {
        Initialization,
        PlayerWin,
        PlayerLose
    }

    private GameState _gameState;

    private WinPanel _winPanel;
    private PlayerDataHandler _playerDataHandler;
    private LevelController _levelController;
    private InputController _inputController;
    private TimerController _timeController;

    [Inject]
    public void Construct(WinPanel winPanel, PlayerDataHandler playerDataHandler,
         LevelController levelController, InputController inputController,
         TimerController timerController) {
        _winPanel = winPanel;
        _playerDataHandler = playerDataHandler;
        _levelController = levelController;
        _inputController = inputController;
        _timeController = timerController;
    }

    private void Start() => SetState(GameState.Initialization);

    private void SetState(GameState state) {
        _gameState = state;
        switch(_gameState) {
            case GameState.Initialization:
                Initialize();
                break;
            case GameState.PlayerWin:
                OnWin();
                break;
            case GameState.PlayerLose:
                OnLose();
                break;
        }
    }

    private void Initialize() {
        _inputController.SwitchInputMode(InputController.InputMode.Player);
       // _timeController.Initialize(_allocatedTime); 
    }

    private void Lose() => SetState(GameState.PlayerLose);

    private void OnLose() => Restart();

    public void Restart() {
        _levelController.RestartCurrentLevel();
    }

    public void Win() => SetState(GameState.PlayerWin);

    private async void OnWin() {
        OnPlayerWin?.Invoke();

        _timeController.StopCountdown();
        _winPanel.InitPanel();
        _winPanel.ShowPanel(1.5f);
        _inputController.SwitchInputMode(InputController.InputMode.UI);
        await Task.Delay(1500);
        _playerDataHandler.HandleBestTime(_timeController.TimePassed);
    }

    private void OnEnable() => PlayerController.OnPlayerDied += Lose;

    private void OnDisable() => PlayerController.OnPlayerDied -= Lose;
}
