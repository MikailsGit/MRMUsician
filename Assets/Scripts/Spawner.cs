using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; 
    public float spawnInterval = 1.0f;
    public float destroyDelay = 2.0f;

    public float force = 10f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 2f, spawnInterval);
    }

    void SpawnObject()
    {
        GameObject obj = Instantiate(prefabToSpawn, transform.position, transform.rotation);
    
        obj.transform.Rotate(0, 90, 0, Space.Self);
        
        obj.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);

        Destroy(obj, destroyDelay);
    }
}
