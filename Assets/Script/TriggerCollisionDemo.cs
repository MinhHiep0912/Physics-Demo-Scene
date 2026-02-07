using UnityEngine;

public class TriggerCollisionDemo : MonoBehaviour
{
    // Biến đếm số coin
    private int coinCount = 0;

    // COLLISION - Vật lý thực, chặn di chuyển
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("=== COLLISION ===");
        Debug.Log("Va chạm với: " + collision.gameObject.name);
        Debug.Log("Tag: " + collision.gameObject.tag);
        Debug.Log("IsTrigger: " + collision.collider.isTrigger);
        Debug.Log("Player BỊ CHẶN, không đi xuyên qua được!");
        Debug.Log("================");

        // Xử lý riêng cho Wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log(">>> Chạm tường! Không thể đi qua!");
        }
    }

    // TRIGGER - Không chặn vật lý, chỉ phát hiện
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("=== TRIGGER ===");
        Debug.Log("Trigger với: " + other.gameObject.name);
        Debug.Log("Tag: " + other.gameObject.tag);
        Debug.Log("IsTrigger: " + other.isTrigger);
        Debug.Log("Player ĐI XUYÊN QUA được!");
        Debug.Log("===============");

        // Xử lý riêng cho Coin
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Debug.Log(">>> Nhặt được Coin! Tổng: " + coinCount);

            // Xóa coin
            Destroy(other.gameObject);
        }
    }

    // Hiển thị số coin trên màn hình
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), "Số Coin: " + coinCount);
    }
}