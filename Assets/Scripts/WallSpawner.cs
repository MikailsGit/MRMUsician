using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallPrefab; 
    public float wallSpacing = 0.3f;
    public int squareSize = 20; 
    public float spawnDelay = 0.1f; 

    void Start()
    {
        StartCoroutine(SpawnWalls());
    }

    IEnumerator SpawnWalls()
    {
        Vector3 startPosition = transform.position - new Vector3(squareSize / 2f * wallSpacing, 0, squareSize / 2f * wallSpacing);

        for (int x = 0; x < squareSize; x++)
        {
            for (int z = 0; z < squareSize; z++)
            {
                if (x > 0 && x < squareSize - 1 && z > 0 && z < squareSize - 1)
                {
                    continue;
                }

                Vector3 position = startPosition + new Vector3(x * wallSpacing, 0, z * wallSpacing);

                Quaternion rotation = Quaternion.identity;
                if (x == 0 || x == squareSize - 1)
                {
                    rotation = Quaternion.Euler(0, 90, 0); 
                }

                Instantiate(wallPrefab, position, rotation);

                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}
