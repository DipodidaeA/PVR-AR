using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (objectToSpawn != null && spawnPoint != null)
            {
                GameObject shell = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

                Rigidbody rb = shell.GetComponent<Rigidbody>();

                Destroy(shell, 30f);
            }
        }
    }
}
