using UnityEngine;

public class GeneralTargetProvider : TargetProvider
{
    [SerializeField] private TargetSensor targetSensor;

    public override Transform Target => targetSensor.Target;
}