using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Khai báo biến
    private CharacterController controller;

    public float speed = 5f;           // Tốc độ di chuyển
    public float gravity = -9.81f;     // Trọng lực
    public float jumpHeight = 1.5f;    // Độ cao nhảy

    private Vector3 velocity;          // Vận tốc hiện tại

    void Start()
    {
        // Lấy component Character Controller
        controller = GetComponent<CharacterController>();

        if (controller == null)
        {
            Debug.LogError("Không tìm thấy Character Controller!");
        }
    }

    void Update()
    {
        // === DI CHUYỂN WASD ===
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S

        // Tính hướng di chuyển (theo hướng nhìn của Player)
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Di chuyển (dùng Move, không dùng AddForce)
        controller.Move(move * speed * Time.deltaTime);

        // === NHẢY ===
        // Kiểm tra đứng trên mặt đất
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset vận tốc rơi
        }

        // Nhấn Space để nhảy
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Nhảy!");
        }

        // === TRỌNG LỰC ===
        // Tăng vận tốc rơi theo thời gian
        velocity.y += gravity * Time.deltaTime;

        // Áp dụng trọng lực
        controller.Move(velocity * Time.deltaTime);

        // === THÔNG TIN DEBUG ===
        // Hiển thị trạng thái
        if (controller.isGrounded)
        {
            Debug.DrawRay(transform.position, Vector3.down * 1.5f, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * 1.5f, Color.red);
        }
    }

    // Hiển thị thông tin trên màn hình
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 30), "Đứng trên mặt đất: " + controller.isGrounded);
        GUI.Label(new Rect(10, 40, 300, 30), "Vận tốc Y: " + velocity.y.ToString("F2"));
        GUI.Label(new Rect(10, 70, 300, 30), "WASD: Di chuyển | Space: Nhảy");
    }
}