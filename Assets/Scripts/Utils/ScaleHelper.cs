using UnityEngine;
using DG.Tweening;
using System.Collections;

public class ScaleHelper : MonoBehaviour
{
    public KeyCode keyStartScale = KeyCode.K;

    public Vector3 initialScale = Vector3.zero;
    public Vector3 finalScale = Vector3.one;
    public float duration;
    public Ease ease;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        if (transform != null)
        {
            transform.localScale = initialScale;
            transform.DOScale(finalScale, duration).SetEase(ease);
            yield return null;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(keyStartScale))
        {
            StartCoroutine(Scale());
        }
    }
}
