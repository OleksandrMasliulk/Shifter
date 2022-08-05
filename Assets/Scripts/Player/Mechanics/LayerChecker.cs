using UnityEngine;

public class LayerChecker : MonoBehaviour {
    public bool IsColliding => CheckCollision();

    [SerializeField] private LayerMask _layer;
    [SerializeField] private Vector2 _bounds;

    private bool CheckCollision() {
        Collider2D[] collisions = Physics2D.OverlapBoxAll(transform.position, _bounds, 0, _layer);
        if (collisions.Length > 0)
            return true;
        else 
            return false;
    }

    [SerializeField] private Color _gizmosColor;
    private void OnDrawGizmos() {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireCube(transform.position, _bounds);
    }
}
