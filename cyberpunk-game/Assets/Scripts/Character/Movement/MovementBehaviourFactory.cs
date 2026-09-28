public static class MovementBehaviourFactory
{
    public static IMovementBehaviour GenerateBehaviour(MovementBehaviour behaviour)
    {
        IMovementBehaviour result = null;

        switch (behaviour)
        {
            case MovementBehaviour.Sidescroller:
                result = new SidescrollerMovement();
                break;
            case MovementBehaviour.TopDown:
                result = new TopDownMovement();
                break;
        }

        return result;
    }
}