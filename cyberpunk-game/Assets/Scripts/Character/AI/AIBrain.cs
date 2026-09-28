using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [SerializeField] private AIBehaviour[] behaviours;
    [SerializeField] private float decisionInterval = 0.2f;

    private float decisionTimer;
    private AIBehaviour currentBehaviour;

    private void Update()
    {
        if (decisionTimer <= 0f)
        {
            ExecuteBehaviour();
            decisionTimer = decisionInterval;
        }
        else
        {
            decisionTimer -= Time.deltaTime;
        }
    }

    private void ExecuteBehaviour()
    {
        AIBehaviour selectedBehaviour = null;
        int highestPriority = int.MinValue;

        // Find the executable behaviour with the highest priority
        if (behaviours != null)
        {
            for (int i = 0; i < behaviours.Length; i++)
            {
                AIBehaviour behaviour = behaviours[i];

                if (behaviour != null && behaviour.CanExecute)
                {
                    if (behaviour.Priority > highestPriority)
                    {
                        highestPriority = behaviour.Priority;
                        selectedBehaviour = behaviour;
                    }
                }
            }
        }

        if (selectedBehaviour != null && selectedBehaviour != currentBehaviour)
        {
            if (currentBehaviour != null)
            {
                currentBehaviour.Stop();
            }

            selectedBehaviour.Initialize();
        }

        if (selectedBehaviour != null)
        {
            currentBehaviour = selectedBehaviour;
            selectedBehaviour.Execute();
        }
    }
}