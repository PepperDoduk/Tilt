using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;
    public float gravityMagnitude = 9.81f;
    public int grav = 1;

    private Rigidbody2D rb;

    public teleport tel1;
    public teleport tel2;

    void Start()
    {

        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not assigned and there is no Camera with tag 'MainCamera' in the scene.");
            return;
        }

        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            grav *= -1;
        }
        Vector3 cameraDownDirection = -mainCamera.transform.up;
        Vector2 gravity = new Vector2(cameraDownDirection.x, cameraDownDirection.y) * gravityMagnitude * grav;
        rb.AddForce(gravity, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("teleport"))
        {
            transform.position = new Vector3(transform.position.x + 5, transform.position.y - 5, 0);
        }

        if (other.gameObject.CompareTag("teleport2"))
        {
            transform.position = new Vector3(tel2.ReturnTelXY().x - 0.5f, tel2.ReturnTelXY().y, 0);
        }
    }
}
