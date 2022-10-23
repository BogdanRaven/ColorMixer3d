using UnityEngine;
using UnityEngine.Events;

namespace StateMachine
{
    public class PhysicalClicksCatcher : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;
      //  [SerializeField] private GameplayStateMachine _gameplayStateMachine;
        public UnityEvent<KeysPressed> onKeyPressed;
        private const string escape = "escape";

        public bool canEscape;

        private void Update()
        {
            if (Input.GetKeyUp(escape)&&canEscape)
            {
                onKeyPressed?.Invoke(KeysPressed.escape);
                _stateMachine.ReactToCloseAction();
   //             _gameplayStateMachine.ReactToCloseAction();

                Debug.Log("Escape");
            }
        }
    }

    public enum KeysPressed
    {
        escape,
    }
}