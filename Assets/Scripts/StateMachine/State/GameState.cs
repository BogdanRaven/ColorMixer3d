using System.Collections.Generic;
using System.Linq;
using StateMachine;
using UnityEngine;
using UnityEngine.UI;

public class GameState : StateBase
{
    [SerializeField] private MenuState _menuState;
    
    [SerializeField] private GameplayStateMachine _gameplayStateMachine;
    [SerializeField] private StartState _startState;
    [SerializeField] private StartMixState _startMixState;

    [SerializeField] private LevelsMap _levelsMap;

    [SerializeField] private IngredientsObjectPool _ingredientsObjectPool;
    [SerializeField] private IngredientsAnimationsController _ingredientsAnimationsController;

    [SerializeField] private Image targetColorIcon;
    [SerializeField] private GameObject cloudTask;

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Button mixButton;

    private StateMachine.StateMachine _stateMachine;

    private List<IngredientData> _ingredientsDataInBlender;
    public override void Enter(StateMachine.StateMachine machineInstance)
    {
        base.Enter(machineInstance);
        _stateMachine = machineInstance;
        
        _menuState.DisableMenuPanel();
        
        _ingredientsDataInBlender = new List<IngredientData>();

        targetColorIcon.color = _levelsMap.GetCurrentLevel().TargetColor;
        cloudTask.gameObject.SetActive(true);
        
        _startState.SetLevelData(_levelsMap.GetCurrentLevel());
        _gameplayStateMachine.AddState(_startState);
        
        mixButton.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(true);
    }

    public override void Exit(StateMachine.StateMachine machineInstance)
    {
        base.Exit(machineInstance);
        
        _menuState.EnableMenuPanel();
        _ingredientsObjectPool.AllRelease();
        
        cloudTask.gameObject.SetActive(false);
        mixButton.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(false);
    }

    public override void EscapeKeyPressed()
    {
        base.EscapeKeyPressed();
        _stateMachine.CloseLastState();
    }

    public Ingredient SpawnIngredient(IngredientData ingredientData)
    {
        var ingredient = _ingredientsObjectPool.Get(ingredientData);

        ingredient.gameObject.transform.position = ingredientData.GetPosition();
        
        ingredient.onMouseDown = (() =>
        {
            _ingredientsAnimationsController.JumpMoveTo(ingredient, (() =>
            {
                SpawnIngredient(ingredientData);
                AddIngredientsDataInBlender(ingredient.GetIngredientData());
                mixButton.gameObject.SetActive(true);
            }));
            Debug.Log("onClick" +ingredient.name);
        });

        return ingredient;
    }
    
    public void AddIngredientsDataInBlender(IngredientData ingredient)
    {
        _ingredientsDataInBlender.Add(ingredient);
    }

    public Color GetMixedColor()
    {
        ColorMixer _colorMixer = new ColorMixer();
        List<Color> colors= new List<Color>();

        foreach (var ingredientData in _ingredientsDataInBlender)
        {
            colors.Add(ingredientData.GetColor());
        }

        return _colorMixer.GetMixedColor(colors);
    }

    public void StartMix()
    {
        _gameplayStateMachine.AddState(_startMixState);
    }
}
