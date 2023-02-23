using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float speedForward;
    [SerializeField] private float speedSides;
    [SerializeField] private SphereCollider coinCollector;
    public bool canMove;
    
    private PlayerAnimation playerAnimation;
    private float currentSpeedForward;
    private Vector2 previousMousePos;

    private void OnValidate()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    private void Start()
    {
        canMove = false;
        ResetSpeed();
        playerAnimation.PlayAnimation(PlayerAnimation.AnimationTypes.IDLE);
    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            MovePlayerForward();
            MovePlayerSides();
        }
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
    public void ChangeCoinCollector(float newRadius)
    {
        coinCollector.radius += newRadius;
    }
    #endregion
}
