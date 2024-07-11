using System.Collections;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    private bool isMovingRight = true;
    private float moveDistance = 0.1f;
    private int steps = 30;
    private float moveSpeed = 0.03f;
    private float initialY; 

    void Start()
    {
        initialY = transform.position.y;
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (true)
        {
            if (isMovingRight)
            {
                for (int i = 0; i < steps; i++)
                {
                    transform.position = new Vector3(transform.position.x + moveDistance, initialY, transform.position.z);
                    yield return new WaitForSeconds(moveSpeed);
                }
            }
            else
            {
                for (int i = 0; i < steps; i++)
                {
                    transform.position = new Vector3(transform.position.x - moveDistance, initialY, transform.position.z);
                    yield return new WaitForSeconds(moveSpeed);
                }
            }
            isMovingRight = !isMovingRight;
        }
    }
}
