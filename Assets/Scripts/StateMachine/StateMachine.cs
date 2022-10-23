using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private StateBase startState;
        [SerializeField] [ReadOnly] private List<StateBase> _states;

        private bool canTransition = true;

        private void Start()
        {
            _states = new List<StateBase>();
            AddState(startState);
        }

        public void SwitchLastStateTo(StateBase state)
        {
            if (!_states.Any() && !canTransition)
                return;

            CloseLastState();
            AddState(state);
        }

        public void AddState(StateBase state)
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

        private StateBase LastState => _states[_states.Count - 1];

        public void CanTransition()
        {
            canTransition = true;
        }

        public void NotCanTransition()
        {
            canTransition = false;
        }

        public bool GetStatusTransition()
        {
            return canTransition;
        }

        public void CloseAlliMenuPanel()
        {
            CloseStateByInterface<IMenuPanel>(false);
        }

        public void CloseStatesForState(StateBase stateBase)
        {
            var cloneStates = _states;
            for (int i = cloneStates.Count - 1; i >= 0; i--)
            {
                if (cloneStates[i] == stateBase)
                {
                    break;
                }

                CloseLastState();
            }
        }
    }
}