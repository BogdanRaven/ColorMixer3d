using System;
using System.Collections;
using System.Collections.Generic;
using StateMachine;
using TMPro;
using UnityEngine;

public class LevelCompleteState : StateBase
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private MenuState _menuState;
    [SerializeField] private LevelsMap _levelsMap;
    
    [SerializeField] private GameObject levelCompletePanel;

    [SerializeField] private TMP_Text percentTxt;
    
    private float percent;
    
    public override void Enter(StateMachine.StateMachine machineInstance)
    {
        base.Enter(machineInstance);

        UpdatePercentTxt();
        levelCompletePanel.gameObject.SetActive(true);
    }

    public void UpdatePercentTxt()
    {
        ColorMixer _colorMixer = new ColorMixer();
        var percent = Math.Round(_colorMixer.GetSimilarityPercentageColor(_gameState.GetMixedColor(),
            _levelsMap.GetCurrentLevel().TargetColor),0);
        percentTxt.text = percent + "%";

    }

    public override void Exit(StateMachine.StateMachine machineInstance)
    {
        base.Exit(machineInstance);
        
        levelCompletePanel.gameObject.SetActive(false);
    }

    public void OpenNextLevel()
    {
        _levelsMap.OpenNextLevel();
        
        machine.CloseStatesForState(_menuState);
        
        machine.AddState(_gameState);
    }
}
