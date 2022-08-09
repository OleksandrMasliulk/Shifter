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

    private void OnEnable() => PlayerController.OnPlayerDied += Lose;

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

    public void Restart() => LevelLoader.Instance.RestartCurrentLevel();

    public void Win() => SetState(GameState.PlayerWin);

    private void OnWin() {
        // InputController.Instance.SwitchInputMode(InputController.InputMode.UI);
        // _winPanel.ShowPanelDelayed(1f);

        // HandleBestLevelTime();
        OnPlayerWin?.Invoke();
    }

    private void HandleBestLevelTime()  {
        // PlayerData data = SaveLoad.Load<PlayerData>(SaveLoad.levelsDataPath);
        // if (data == null)
        //     data = new PlayerData();

        // float time = _timeController.TimeLeft;
        // if (data.LevelsProgression.ContainsKey(LevelLoader.Instance.CurrentLevel.Index)) {
        //     float bestTime = data.GetLevelTime(LevelLoader.Instance.CurrentLevel.Index);
        //     if (bestTime < time) {
        //         data.LevelsProgression[LevelLoader.Instance.CurrentLevel.Index] = new PlayerData.LevelData(true, time);
        //         SaveLoad.Save(data, SaveLoad.levelsDataPath);
        //     }
        // }
        // else {
        //     data.LevelsProgression.Add(LevelLoader.Instance.CurrentLevel.Index, new PlayerData.LevelData(true, time));
        //     SaveLoad.Save(data, SaveLoad.levelsDataPath);
        // }

        // TestJson(data.LevelsProgression[LevelLoader.Instance.CurrentLevel.Index].bestTime);
    }

    // private void TestJson(float time) {
    //     SavePackage package = new SavePackage("PlayerName", LevelLoader.Instance.CurrentLevel.Index, time);
    //     string json = SaveLoad.ToJson<SavePackage>(package);
    //     File.WriteAllText(Application.persistentDataPath + "/TestJson_" + package.levelIndex + ".json", json);
    //     Debug.Log(json);
    // }

    private void OnDisable() => PlayerController.OnPlayerDied -= Lose;
}
