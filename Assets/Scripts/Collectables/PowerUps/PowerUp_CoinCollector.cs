using UnityEngine;

public class PowerUp_CoinCollector : PowerUp_Base
{
    public float radius;

    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerController.instance.ChangeCoinCollector(radius);
    }
    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
        PlayerController.instance.ChangeCoinCollector(-radius);
    }
}
