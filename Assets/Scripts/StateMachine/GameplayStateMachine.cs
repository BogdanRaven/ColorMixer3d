using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace StateMachine
{
    public class GameplayStateMachine : MonoBehaviour
    {
        [SerializeField] private GameplayStateBase startState;
        [SerializeField] [ReadOnly] private List<GameplayStateBase> _states;

        private bool canTransition = true;

        public void StartGameplay()
        {
            _states = new List<GameplayStateBase>();
            AddState(startState);
        }

        public void SwitchLastStateTo(GameplayStateBase state)
        {
            if (!_states.Any() && !canTransition)
                return;

            CloseLastState();
            AddState(state);
        }

        public void AddState(GameplayStateBase state)
        {
            if (!canTransition)
                return;

            _states.Add(state);
            state.Enter(this);
        }

        public void CloseLastState()
        {
            if (!_states.Any())
                return;

            if (!LastState.CanExit() || !canTransition)
                return;

            LastState.Exit(this);
            _states.Remove(LastState);
        }

        public void ReactToCloseAction()
        {
            if (!_states.Any())
                return;

            LastState.EscapeKeyPressed();
        }

        public void CloseStateByInterface<T>(bool forceClose)
        {
            for (int i = 0; i < _states.Count; i++)
            {
                if (_states[i] is T)
                {
                    if (_states[i].CanExit() == false && forceClose == false)
                    {
                        continue;
                    }

                    _states[i].Exit(this);
                    _states.RemoveAt(i);
                }
            }
        }

        public void UpdateCurrentState()
        {
            if (!_states.Any())
                return;
            LastState.UpdateLogic(this);
        }

        private GameplayStateBase LastState => _states[_states.Count - 1];

        public void CanTransition()
        {
            canTransition = true;
        }

        public void NotCanTransition()
        {
            canTransition = false;
        }

        public GameplayStateBase GetCurrentState()
        {
            return LastState;
        }
    }
}