using UnityEngine;

[CreateAssetMenu(fileName = "ingredientData", menuName = "CreateIngredientData")]
public class IngredientData : ScriptableObject
{
    [SerializeField] private Color color;
    [SerializeField] private Ingredient ingredientTemplate;

    private Vector3 position;

    public Color GetColor()
    {
        Color ingredientColor = new Color(color.r, color.g, color.b,255);
        return ingredientColor;
    }

    public Ingredient GetIngredientTemplate()
    {
        return ingredientTemplate;
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 GetPosition()
    {
        return position;
    }
}