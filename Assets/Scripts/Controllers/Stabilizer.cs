using UnityEngine;
using Zenject;

public class Stabilizer : MonoBehaviour {
    private GameController _gameController;

    [Inject]
    public void Construct(GameController gameController) {
        _gameController = gameController;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player)) {
            _gameController.Win();
        }
    }
}
