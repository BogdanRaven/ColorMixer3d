using UnityEngine;

namespace StateMachine
{
    public class StateBase : MonoBehaviour
    {
        protected StateMachine machine;


        public virtual void Enter(StateMachine machineInstance)
        {
            this.machine = machineInstance;
            Debug.Log("Enter state: " + name);
        }

        public virtual void Exit(StateMachine machineInstance)
        {
            this.machine = machineInstance;
            Debug.Log("Exit state: " + name);
        }

        public virtual bool CanExit() => true;

        public virtual void EscapeKeyPressed()
        {
        }
    }
}