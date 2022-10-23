using StateMachine;
using UnityEngine;

public class StartMixState : GameplayStateBase
{
    [SerializeField] private StateMachine.StateMachine _stateMachine;
    
    [SerializeField] private GameState _gameState;
    [SerializeField] private LevelCompleteState _levelCompleteState;

    [SerializeField] private Blender _blender;

    private Color mixedColor;
    public override void Enter(GameplayStateMachine machineInstance)
    {
        base.Enter(machineInstance);
        
        _blender.PlayAnimationLongShake(3f);
        mixedColor = _gameState.GetMixedColor();
        _stateMachine.AddState(_levelCompleteState);
    }

    public override void Exit(GameplayStateMachine machineInstance)
    {
        base.Exit(machineInstance);
    }
}
