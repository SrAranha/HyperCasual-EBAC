using UnityEngine;

public class PowerUp_Height : PowerUp_Base
{
    public float newHeight;

    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerController.instance.ChangeHeight(newHeight);
    }
    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
        PlayerController.instance.ChangeHeight(-newHeight);
    }
}
