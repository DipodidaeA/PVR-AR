using UnityEngine;

public class AmmoShootTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShootTarget"))
        {
            Destroy(gameObject);
        }
    }
}
