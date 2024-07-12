using UnityEngine;
using DG.Tweening;

public class ChickenBounceEffect : MonoBehaviour
{
    void Start()
    {
        DoEffect();
    }

    void DoEffect()
    {
        Vector3 originalScale = transform.localScale;

        transform.DOScale(new Vector3(originalScale.x, 1.05f * originalScale.y, originalScale.z), 0.5f)
                 .SetLoops(-1, LoopType.Yoyo)
                 .SetEase(Ease.InOutSine);
    }

}