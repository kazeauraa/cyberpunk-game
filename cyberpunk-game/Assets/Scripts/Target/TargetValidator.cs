using UnityEngine;

public class TargetValidator : MonoBehaviour
{
    [SerializeField] private bool valid = true;

    public bool Valid
    {
        get
        {
            return valid;
        }
        set
        {
            valid = value;
        }
    }
}