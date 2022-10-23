using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "levelData", menuName = "CreateLevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<IngredientData> ingredientsData;
    [SerializeField] private Color targetColor;

    public void SelectTargetColor()
    {
        var color = new Color(0, 0, 0, 0);

        foreach (var ingredient in ingredientsData)
        {
            color += ingredient.GetColor();
        }

        color = color / ingredientsData.Count;

        targetColor = new Color(color.r, color.g, color.b, color.a * ingredientsData.Count);
    }

    public IEnumerable<IngredientData> GetIngredients()
    {
        var ingredients = ingredientsData;

        return ingredients;
    }

    public Color TargetColor
    {
        get { return targetColor; }
        private set { }
    }
}