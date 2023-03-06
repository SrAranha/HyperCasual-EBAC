using UnityEngine;

public class PowerUp_Base : Collectable_Base
{
    [Header("PowerUp")]
    public float duration;
    protected override void Collect()
    {
        base.Collect();

        PowerUpStart();
    }
    protected virtual void PowerUpStart()
    {
        Debug.Log("Starting PowerUp");
        Invoke(nameof(PowerUpEnd), duration);
    }
    protected virtual void PowerUpEnd()
    {
        Debug.Log("Ending PowerUp");
    }
}
