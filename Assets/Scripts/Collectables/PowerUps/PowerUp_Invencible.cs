using UnityEngine;

public class PowerUp_Invencible : PowerUp_Base
{
    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerCollision.instance.invencible = true;
    }
    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
        PlayerCollision.instance.invencible = false;
    }
}
