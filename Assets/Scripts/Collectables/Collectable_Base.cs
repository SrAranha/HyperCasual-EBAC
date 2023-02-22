using UnityEngine;

public class Collectable_Base : MonoBehaviour
{
    [Header("Collectable Base")]
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        gameObject.SetActive(false);
    }
}
