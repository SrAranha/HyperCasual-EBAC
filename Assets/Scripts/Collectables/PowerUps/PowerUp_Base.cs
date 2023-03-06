using UnityEngine;
using DG.Tweening;

public class PowerUp_Base : Collectable_Base
{
    [Header("Get PowerUp Animation")]
    public Vector3 scale = new(1.2f, 1.2f, 1.2f);
    public float animDuration = 1f;
    public Ease ease = Ease.OutBounce;
    [Header("PowerUp")]
    public float powerupDuration;
    protected override void Collect()
    {
        base.Collect();

        PlayerController.instance.transform.DOScale(scale, animDuration/2).SetEase(ease)
            .OnComplete(() => 
            PlayerController.instance.transform.DOScale(Vector3.one, animDuration/2).SetEase(ease));

        PowerUpStart();
    }
    protected virtual void PowerUpStart()
    {
        Debug.Log("Starting PowerUp");
        Invoke(nameof(PowerUpEnd), powerupDuration);
    }
    protected virtual void PowerUpEnd()
    {
        Debug.Log("Ending PowerUp");
    }
}
