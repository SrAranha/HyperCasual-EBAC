using System.Collections.Generic;
using UnityEngine;

public class LevelPiece : MonoBehaviour
{
    public Transform endPoint;
    [Header("Objects")]
    public GameObject plane;
    public List<GameObject> obstacles;
    private void OnValidate()
    {
        endPoint = gameObject.transform.Find("End_Point");
    }
    public void SetColor(Color planeColor, Color obstacleColor)
    {
        var _planeRenderer = plane.GetComponent<MeshRenderer>();
        _planeRenderer.material.color = planeColor;
        if (obstacles != null)
        {
            foreach (GameObject obstacle in obstacles)
            {
                var _obstacleRenderer = obstacle.GetComponent<MeshRenderer>();
                _obstacleRenderer.material.color = obstacleColor;
            }
        }
    }
}
