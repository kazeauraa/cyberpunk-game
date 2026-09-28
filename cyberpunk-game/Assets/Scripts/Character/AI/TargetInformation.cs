using UnityEngine;

public class TargetInformation : MonoBehaviour
{
    [SerializeField] private float distanceToApproach;

    public float DistanceToApproach
    {
        get
        {
            return distanceToApproach;
        }
    }
}