using System;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine<T1, T2> where T1 : MonoBehaviour where T2 : ScriptableObject
    {
        public Action OnStateChanged;
        public State<T1, T2> CurrentState { get; private set; }
        public State<T1, T2> PreviousState { get; private set; }

        public void Initialize(State<T1, T2> startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
            OnStateChanged?.Invoke();
        }

        public void ChangeState(State<T1, T2> newState)
        {
            PreviousState = CurrentState;
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
            OnStateChanged?.Invoke();
            Debug.Log(nameof(CurrentState));
        }
    }
}
