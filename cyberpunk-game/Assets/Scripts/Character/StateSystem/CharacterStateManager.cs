using System;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public event Action OnStateUpdated;

    [SerializeField] private CharacterState currentState = CharacterState.Normal;

    public CharacterState CurrentState
    {
        get => currentState;
        set
        {
            if (currentState != value)
            {
                currentState = value;
                OnStateUpdated?.Invoke();
            }
        }
    }

    public bool IsState(CharacterState state)
    {
        return currentState == state;
    }

    public bool IsStateIn(params CharacterState[] states)
    {
        bool result = false;

        for (int i = 0; i < states.Length && !result; i++)
        {
            if (currentState == states[i])
            {
                result = true;
            }
        }
        return result;
    }
}