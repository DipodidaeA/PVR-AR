using UnityEngine;

public class BoxShootTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TankAmmo"))
        {
            Destroy(gameObject);
        }
    }
}
