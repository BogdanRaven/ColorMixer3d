using UnityEngine;

namespace StateMachine
{
    public class GameplayStateBase : MonoBehaviour
    {
        protected GameplayStateMachine machine;


        public virtual void Enter(GameplayStateMachine machineInstance)
        {
            this.machine = machineInstance;
            Debug.Log("Enter gameplay state: " + name);
        }

        public virtual void Exit(GameplayStateMachine machineInstance)
        {
            this.machine = machineInstance;
            Debug.Log("Exit gameplay state: " + name);
        }

        public virtual void UpdateLogic(GameplayStateMachine machineInstance)
        {
            this.machine = machineInstance;
            Debug.Log("Update logic state: " + name);
        }

        public virtual bool CanExit() => true;

        public virtual void EscapeKeyPressed()
        {
        }
    }
}