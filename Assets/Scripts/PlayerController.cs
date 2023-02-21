using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedForward;
    [SerializeField] private float speedSides;

    private Vector2 previousMousePos;

    private void FixedUpdate()
    {
        MovePlayerForward();
        MovePlayerSides();
    }
    private void MovePlayerForward()
    {
        transform.Translate(speedForward * Time.fixedDeltaTime * Vector3.forward);
    }
    private void MovePlayerSides()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position += (Input.mousePosition.x - previousMousePos.x) * Time.fixedDeltaTime * Vector3.right * speedSides;
        }
        previousMousePos = Input.mousePosition;
    }
}
