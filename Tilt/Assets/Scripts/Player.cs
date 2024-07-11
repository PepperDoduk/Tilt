using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;
    public float gravityMagnitude = 9.81f;
    public int grav = 1;

    private Rigidbody2D rb;

    public teleport tel1;
    public teleport tel2;

    public Score score;

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
            Gravity();
        }
        Vector3 cameraDownDirection = -mainCamera.transform.up;
        Vector2 gravity = new Vector2(cameraDownDirection.x, cameraDownDirection.y) * gravityMagnitude * grav;
        rb.AddForce(gravity, ForceMode2D.Force);
    }

    public void Gravity()
    {
        grav *= -1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("teleport"))
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Teleport);
            transform.position = new Vector3(transform.position.x + 5, transform.position.y - 5, 0);
        }

        if (other.gameObject.CompareTag("teleport2"))
        {
            transform.position = new Vector3(tel2.ReturnTelXY().x - 0.5f, tel2.ReturnTelXY().y, 0);
        }
        
        if (other.gameObject.CompareTag("teleport3"))
        {
            transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y +3, 0);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin, +50");
            score.AddScore(50);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin, +50");
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Coin);
            score.AddScore(50);
        }
    }
}
