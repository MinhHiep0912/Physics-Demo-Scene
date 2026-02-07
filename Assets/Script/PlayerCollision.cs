using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Xử lý va chạm vật lý
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Va chạm với: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Chạm Enemy!");
        }
    }

    // Xử lý trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger với: " + other.gameObject.name);

        if (other.CompareTag("Coin"))
        {
            Debug.Log("Nhặt được Coin!");
            Destroy(other.gameObject);
        }
    }
}