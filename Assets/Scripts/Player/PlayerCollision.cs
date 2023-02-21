using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Lose Game")]
    public GameObject loseScreen;
    public string obstacleTag;
    [Header("Win Game")]
    public GameObject winScreen;
    public string finishLineTag;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colidiu com " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            LoseGame();
        }
        if (collision.gameObject.CompareTag(finishLineTag))
        {
            WinGame();
        }
    }
    private void StopTime()
    {
        Time.timeScale = 0f;
    }
    private void LoseGame()
    {
        StopTime();
        loseScreen.SetActive(true);
    }
    private void WinGame()
    {
        StopTime();
        winScreen.SetActive(true);
    }
}
