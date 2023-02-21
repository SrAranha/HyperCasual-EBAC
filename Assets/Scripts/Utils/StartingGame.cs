using UnityEngine;

public class StartingGame : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
