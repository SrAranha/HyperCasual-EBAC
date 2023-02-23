using UnityEngine;

public class StartingGame : MonoBehaviour
{
    public SO_TimeScale timeScale;
    private void Awake()
    {
        ReduceTimeScale(timeScale.timeScale);
    }
    public static void ReduceTimeScale(float value)
    {
        Time.timeScale = value;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        PlayerController.instance.canMove = true;
        PlayerAnimation.instance.PlayAnimation(PlayerAnimation.AnimationTypes.RUN);
    }
}
