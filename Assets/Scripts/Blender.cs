using System;
using DG.Tweening;
using UnityEngine;

public class Blender : MonoBehaviour
{
    [SerializeField] private GameObject cap;
    [SerializeField] private Transform capStartPosition;
    [SerializeField] private Transform capEndPosition;

    [SerializeField] private float durationOpenCloseCap;
    [SerializeField] private float durationShakeBlender;
    
    public void PlayAnimationOpenCap()
    {
        cap.transform.DOKill();
        cap.transform.DOMove(capEndPosition.position, durationOpenCloseCap).SetEase(Ease.OutQuad);
    }

    public void PlayAnimationCloseCap()
    {
        cap.transform.DOKill();
        cap.transform.DOMove(capStartPosition.position, durationOpenCloseCap).SetEase(Ease.OutQuad);
    }

    public void PlayAnimationShake()
    {
        gameObject.transform.DOKill();
        gameObject.transform.DOShakeRotation(durationShakeBlender, 10, 5, 50);
    }

    public void PlayAnimationLongShake(float duration, Action onComplete = null)
    {
        gameObject.transform.DOKill();
        gameObject.transform.eulerAngles= Vector3.zero;
        gameObject.transform.DOShakeRotation(duration, 10, 5, 50).OnComplete((() =>
        {
            onComplete?.Invoke();
        }));
    }
}
