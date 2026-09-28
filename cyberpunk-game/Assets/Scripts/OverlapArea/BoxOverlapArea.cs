using UnityEngine;

/// <summary>
/// Box-shaped overlap detection area
/// </summary>
public class BoxOverlapArea : OverlapArea
{
    [SerializeField] private Vector2 size = Vector2.one;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Color gizmosColor = Color.red;

    public override bool OverlapOne()
    {
        return Physics2D.OverlapBox(transform.position, size, 0f, layer);
    }

    public override Collider2D[] OverlapAll()
    {
        return Physics2D.OverlapBoxAll(transform.position, size, 0f, layer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmosColor;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, size);
    }
}