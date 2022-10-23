using StateMachine;
using UnityEngine;

public class MenuState : StateBase
{
    [SerializeField] private GameObject menu;

    public override void Enter(StateMachine.StateMachine machineInstance)
    {
        base.Enter(machineInstance);
        
        EnableMenuPanel();
    }

    public override void Exit(StateMachine.StateMachine machineInstance)
    {
        base.Exit(machineInstance);
        
        DisableMenuPanel();
    }

    public override bool CanExit()
    {
        return false;
    }

    public override void EscapeKeyPressed()
    {
        base.EscapeKeyPressed();
    }

    public void EnableMenuPanel()
    {
        menu.gameObject.SetActive(true);
    }

    public void DisableMenuPanel()
    {
        menu.gameObject.SetActive(false);
    }
}
