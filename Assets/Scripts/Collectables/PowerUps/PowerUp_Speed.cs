using UnityEngine;

public class PowerUp_Speed : PowerUp_Base
{
    public float newSpeed;

    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerController.instance.SpeedUp(newSpeed, powerupDuration);
    }
}
