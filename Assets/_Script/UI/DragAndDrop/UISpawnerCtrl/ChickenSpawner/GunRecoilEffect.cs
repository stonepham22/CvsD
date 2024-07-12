using UnityEngine;
using DG.Tweening;

public class GunRecoilEffect : MonoBehaviour, IObserverListener
{
    [SerializeField] private float _recoilDistance = 5f;
    [SerializeField] private float _recoilSpeed = 0.2f;

    public void NotifyEvent(EventType type, object data)
    {
        if (data is not ChickenShootingData chickenShootingData) return;
        if (chickenShootingData.bulletSpawnPos != transform.parent.position) return;
        Recoil();
    }

    void OnEnable()
    {
        ObserverManager.Instance.RegistEvent(EventType.ChickenShooting, this);
    }

    void Recoil()
    {
        Vector3 originalPosition = transform.localPosition;
        Vector3 recoilPosition = originalPosition - transform.right * _recoilDistance;

        transform.DOLocalMove(recoilPosition, _recoilSpeed).SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                transform.DOLocalMove(originalPosition, _recoilSpeed).SetEase(Ease.InSine);
            });

    }
}