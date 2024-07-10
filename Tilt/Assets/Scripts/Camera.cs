using UnityEngine;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float smoothing = 0.2f;
    public Vector2 min;
    public Vector2 max;

    private bool playerDead = false;
    private bool freeCameraMode = false;

    void Start()
    {
    }

    void Update()
    {

        Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);

        targetPos.x = Mathf.Clamp(targetPos.x, min.x, max.x);
        targetPos.y = Mathf.Clamp(targetPos.y, min.y, max.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, 120 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, -120 * Time.deltaTime);
        }
    }
}
