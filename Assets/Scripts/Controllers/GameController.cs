using UnityEngine;
using System.IO;
using System;

public class GameController : MonoBehaviour {
    public event Action OnPlayerWin;
    public enum GameState {
        Initialization,
        PlayerWin,
        PlayerLose
    }

    private GameState _gameState;

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
       // _timeController.Initialize(_allocatedTime);
    }

    private void Lose() => SetState(GameState.PlayerLose);

    private void OnLose() => Restart();

    public void Restart() {
    }

    public void Win() => SetState(GameState.PlayerWin);

    private void OnWin() => OnPlayerWin?.Invoke();

    private void OnEnable() => PlayerController.OnPlayerDied += Lose;

    private void OnDisable() => PlayerController.OnPlayerDied -= Lose;
}
