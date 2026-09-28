using UnityEngine;

/// <summary>
/// Circular overlap detection area
/// </summary>
public class CircleOverlapArea : OverlapArea
{
    [SerializeField] private float radius = 1f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Color gizmosColor = Color.red;

    public LayerMask Layer => layer;

    public override bool OverlapOne()
    {
        return Physics2D.OverlapCircle(transform.position, radius, layer);
    }

    public override Collider2D[] OverlapAll()
    {
        return Physics2D.OverlapCircleAll(transform.position, radius, layer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}