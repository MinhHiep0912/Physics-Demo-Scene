using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Player
    public Vector3 offset = new Vector3(0, 5, -10); // Khoảng cách camera
    public float smoothSpeed = 0.125f;  // Độ mượt

    void LateUpdate()
    {
        if (target == null) return;

        // Vị trí mong muốn
        Vector3 desiredPosition = target.position + offset;

        // Di chuyển mượt
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Nhìn vào Player
        transform.LookAt(target);
    }
}