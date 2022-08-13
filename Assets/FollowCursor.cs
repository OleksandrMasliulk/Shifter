using UnityEngine;

public class FollowCursor : MonoBehaviour {
    [SerializeField] private Vector2 _offset;

    private void Update() {
        Vector2 mousePos = Input.mousePosition;
        transform.position = mousePos + _offset;
    }
}
