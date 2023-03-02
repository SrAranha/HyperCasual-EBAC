using UnityEngine;

public class PlayerCollision : Singleton<PlayerCollision>
{
    [Header("ReduceTimeScale")]
    public SO_TimeScale timeScale;
    [Header("Lose Game")]
    public GameObject loseScreen;
    public string obstacleTag;
    [Header("Win Game")]
    public GameObject winScreen;
    public string finishLineTag;
    [Header("PowerUp")]
    public bool invencible;

    private PlayerAnimation playerAnimation;
    private void OnValidate()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            Physics.IgnoreCollision(collision.collider, this.gameObject.GetComponent<BoxCollider>(), invencible);
            if (!invencible)
            {
                LoseGame();
            }
        }
        if (collision.gameObject.CompareTag(finishLineTag))
        {
            WinGame();
        }
    }
    private void LoseGame()
    {
        playerAnimation.PlayAnimation(PlayerAnimation.AnimationTypes.DEATH);
        loseScreen.SetActive(true);
        StartingGame.ReduceTimeScale(timeScale.timeScale);
    }
    private void WinGame()
    {
        playerAnimation.PlayAnimation(PlayerAnimation.AnimationTypes.IDLE);
        winScreen.SetActive(true);
        StartingGame.ReduceTimeScale(timeScale.timeScale);
    }
}
