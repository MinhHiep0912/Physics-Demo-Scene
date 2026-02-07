using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Di chuyển WASD
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0, v);
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
    }
}