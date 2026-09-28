using UnityEngine;

public abstract class Follower : MonoBehaviour
{
    public abstract void Follow(Vector2 newTargetPosition, float stopDistance);
    public abstract void StopFollow();
}