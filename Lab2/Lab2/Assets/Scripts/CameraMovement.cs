using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float distance = 5f;
    public float height = 2f;
    public float sensitivity = 3f;

    private float pitch = 0f;
    private float yaw = 0f;

    void Update(){
        if (target == null || target2 == null) return;

        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -15f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 offset = rotation * new Vector3(0, height, -distance);
        transform.position = target.position + offset;

        transform.LookAt(target.position + Vector3.up * 1.5f);

        target.rotation = Quaternion.Euler(0, yaw, 0);

        target2.rotation = Quaternion.Euler(pitch, target.rotation.eulerAngles.y, 0);
    }
}
