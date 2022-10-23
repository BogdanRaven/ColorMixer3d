using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IngredientsAnimationsController : MonoBehaviour
{
    [SerializeField] private Blender _blender;
    
    [SerializeField] private float jumpDuration;
    [SerializeField] private int jumpPower;
    [SerializeField] private Transform endPosition;

    [SerializeField] private List<Ingredient> _ingredientsInAnimations;

    public void JumpMoveTo(Ingredient ingredient, Action onComplete = null)
    {
        JumpMoveTo(ingredient, endPosition,jumpPower,1,jumpDuration,0,onComplete);
    }
    
    public void JumpMoveTo(Ingredient ingredient,Transform endPosition,int jumpPower, int numJumps, float duration, float delay, Action onComplete = null)
    {
        _blender.PlayAnimationOpenCap();
        _ingredientsInAnimations.Add(ingredient);
        ingredient.gameObject.transform.DOJump(endPosition.position, jumpPower, numJumps, duration).SetDelay(delay).OnComplete((() =>
        {
            _ingredientsInAnimations.Remove(ingredient);
            _blender.PlayAnimationShake();
            _blender.PlayAnimationCloseCap();
            onComplete?.Invoke();
        }));
    }
}
