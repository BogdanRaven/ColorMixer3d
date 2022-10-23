using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientsObjectPool : MonoBehaviour
{
    private List<Ingredient> available = new List<Ingredient>();
    private List<Ingredient> inUse = new List<Ingredient>();

    public Ingredient Get(IngredientData ingredientData)
    {
        Ingredient ingredient = null;
        if (available.Count(ing => ing.GetIngredientData() == ingredientData) == 0)
        {
            ingredient = Instantiate(ingredientData.GetIngredientTemplate());
           
            ingredient.InitIngredient(ingredientData);
        }
        else
        {
            ingredient = available.FirstOrDefault(ing => ing.GetIngredientData() == ingredientData);
            ingredient.gameObject.SetActive(true);
            available.Remove(ingredient);
        }

        inUse.Add(ingredient);
        return ingredient;
    }

    public void Release(Ingredient ingredient)
    {
        if (inUse.Remove(ingredient) == false)
        {
            return;
        }

        available.Add(ingredient);
        ingredient.gameObject.SetActive(false);
    }

    public void AllRelease()
    {
        List<Ingredient> inUseClone= new List<Ingredient>();
        
        foreach (var ingredient in inUse)
        {
            inUseClone.Add(ingredient);
        }

        foreach (var ingredient in inUseClone)
        {
            Release(ingredient);
        }
    }
}