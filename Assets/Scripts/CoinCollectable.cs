using UnityEngine;

public class CoinCollectable : MonoBehaviour
{
    public int value;

    private string playerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Collect();
        }
    }
    private void Collect()
    {
        gameObject.SetActive(false);
    }
}
