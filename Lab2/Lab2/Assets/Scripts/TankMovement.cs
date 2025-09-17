using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform;
    private Rigidbody rb;

    public GameObject shellPrefab;
    public Transform firePoint;
    public float shellSpeed = 20f;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        // Отримуємо введення
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Напрямок камери
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 movement = (camForward * vertical + camRight * horizontal);

        if (movement.magnitude > 0.01f)
        {
            movement = movement.normalized * speed * Time.fixedDeltaTime;

            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, toRotation, 0.2f));

            rb.MovePosition(rb.position + movement);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject shell = Instantiate(shellPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = shell.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * shellSpeed;

        Destroy(shell, 5f);
    }
}
