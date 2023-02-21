using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ChangeToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}