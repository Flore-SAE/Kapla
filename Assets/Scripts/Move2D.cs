using UnityEngine;

public class Move2D : MonoBehaviour
{
    private Vector2 nextDestination;
    private bool shouldMove;

    public void TeleportTo(Vector2 newPosition)
    {
        nextDestination = newPosition;
        shouldMove = true;
    }

    private void Update()
    {
        if (!shouldMove) return;
        transform.position = nextDestination;
        shouldMove = false;
    }
}
