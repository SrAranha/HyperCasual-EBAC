using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float speedForward;
    [SerializeField] private float speedSides;

    private float currentSpeedForward;
    private Vector2 previousMousePos;
    private void Start()
    {
        ResetSpeed();
    }

    private void FixedUpdate()
    {
        MovePlayerForward();
        MovePlayerSides();
    }
    private void MovePlayerForward()
    {
        transform.Translate(currentSpeedForward * Time.fixedDeltaTime * Vector3.forward);
    }
    private void MovePlayerSides()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position += (Input.mousePosition.x - previousMousePos.x) * speedSides * Time.fixedDeltaTime * Vector3.right;
        }
        previousMousePos = Input.mousePosition;
    }

    #region POWERUPS
    private void ResetSpeed()
    {
        currentSpeedForward = speedForward;
    }
    public void SpeedUp(float newSpeed, float duration)
    {
        currentSpeedForward = newSpeed;
        Invoke(nameof(ResetSpeed), duration);
    }
    public void ChangeHeight(float newHeight)
    {
        var pos = transform.position;
        pos.y += newHeight;
        transform.position = pos;
    }
    #endregion
}
