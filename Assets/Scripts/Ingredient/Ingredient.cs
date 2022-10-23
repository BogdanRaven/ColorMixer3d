using System;
using DG.Tweening;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public  Action onMouseDown;

    private IngredientData _ingredientData;

    public void InitIngredient(IngredientData ingredientData)
    {
        _ingredientData = ingredientData;
    }

    private void OnMouseDown()
    {
        onMouseDown?.Invoke();
    }

    public IngredientData GetIngredientData()
    {
        return _ingredientData;
    }

   
}