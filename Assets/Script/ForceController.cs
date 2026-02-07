using UnityEngine;

public class ForceController : MonoBehaviour
{
    // Khai báo biến
    private Rigidbody rb;
    public float jumpForce = 10f;
    public float moveForce = 5f;

    void Start()
    {
        // Lấy component Rigidbody
        rb = GetComponent<Rigidbody>();

        // Kiểm tra có Rigidbody không
        if (rb == null)
        {
            Debug.LogError("Không tìm thấy Rigidbody!");
        }
    }

    void Update()
    {
        // Nhấn SPACE để nhảy
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Nhảy!");
        }

        // Di chuyển bằng WASD
        float horizontal = Input.GetAxis("Horizontal"); // A/D hoặc Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S hoặc Up/Down

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rb.AddForce(movement * moveForce);
    }

    // Phát hiện va chạm
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Va chạm với: " + collision.gameObject.name);
    }
}