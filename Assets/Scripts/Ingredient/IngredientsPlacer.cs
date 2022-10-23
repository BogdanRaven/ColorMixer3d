using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsPlacer : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private float spaceXBetweenObjects;

    public void SetPositions(List<Ingredient> ingredients)
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            var newPosition = new Vector3(startPoint.localPosition.x -(spaceXBetweenObjects*i), startPoint.localPosition.y,
                startPoint.localPosition.z);
            ingredients[i].GetIngredientData().SetPosition(newPosition);
            ingredients[i].gameObject.transform.localPosition = newPosition;
        }
    }
}
