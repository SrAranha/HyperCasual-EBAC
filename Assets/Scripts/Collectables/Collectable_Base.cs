using System.Collections;
using UnityEngine;

public class Collectable_Base : MonoBehaviour
{
    [Header("Collectable Base")]
    public string playerTag = "Player";
    public float timeToHide;

    public ParticleSystem _particle;
    public MeshRenderer _meshRenderer;
    public Collider _collider;

    private void OnValidate()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        _particle = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        StartCoroutine(HideCollectable(timeToHide));
        _particle.Play();
    }
    IEnumerator HideCollectable(float time)
    {
        DisableCollectable();
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
    private void DisableCollectable()
    {
        _meshRenderer.enabled = false;
        _collider.enabled = false;
    }
}
