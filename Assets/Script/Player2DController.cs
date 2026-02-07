using UnityEngine;

public class Player2DController : MonoBehaviour
{
    // Khai báo biến
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded = false;

    void Start()
    {
        // Lấy Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // === DI CHUYỂN TRÁI/PHẢI ===
        float moveInput = Input.GetAxis("Horizontal"); // A/D hoặc Left/Right
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // === NHẢY ===
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("Nhảy!");
        }

        // === NHẤN XUỐNG ĐỂ RƠI QUA PLATFORM ===
        // Tính năng này tùy chọn, có thể bỏ qua
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Có thể code thêm để vô hiệu hóa Platform tạm thời
            Debug.Log("Nhấn xuống");
        }
    }

    // Phát hiện chạm đất
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            Debug.Log("Chạm đất!");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
            Debug.Log("Rời đất!");
        }
    }

    // Hiển thị hướng dẫn
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 30), "A/D: Di chuyển trái/phải");
        GUI.Label(new Rect(10, 40, 300, 30), "Space: Nhảy");
        GUI.Label(new Rect(10, 70, 300, 30), "Đứng trên mặt đất: " + isGrounded);
    }
}