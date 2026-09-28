using UnityEngine;

public abstract class OverlapArea : MonoBehaviour
{
    /// <summary>
    /// Detects if any collider overlaps with this area
    /// </summary>
    /// <returns>True if at least one collider is detected</returns>
    public abstract bool OverlapOne();

    /// <summary>
    /// Detects all colliders that overlap with this area
    /// </summary>
    /// <returns>Array of all detected colliders</returns>
    public abstract Collider2D[] OverlapAll();
}
