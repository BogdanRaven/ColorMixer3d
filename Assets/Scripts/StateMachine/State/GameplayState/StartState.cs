using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

public class StartState : GameplayStateBase
{
    [SerializeField] private GameState _gameState;
    
    [SerializeField] private IngredientsPlacer _ingredientsPlacer;

    private LevelData _levelData;
    public override void Enter(GameplayStateMachine machineInstance)
    {
        base.Enter(machineInstance);
        
        InitIngredients();
    }

    public override void Exit(GameplayStateMachine machineInstance)
    {
        base.Exit(machineInstance);
    }

    private void InitIngredients()
    {
        List<Ingredient> ingredients = new List<Ingredient>();
        foreach (var ingredientData in _levelData.GetIngredients())
        {
            var ingredient = _gameState.SpawnIngredient(ingredientData);
            
            ingredients.Add(ingredient);
        }
        
        _ingredientsPlacer.SetPositions(ingredients);
    }
    
    public void SetLevelData(LevelData levelData)
    {
        _levelData = levelData;
    }
}
