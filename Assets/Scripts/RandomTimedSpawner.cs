using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class RandomTimedSpawner : MonoBehaviour
{
    [SerializeField] MoveSpawner prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance;
    private bool spawnerEnables = true;

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    // Function to disable spawner after game over
    public void disableSpawner()
    {
        spawnerEnables = !spawnerEnables;
    }

    private IEnumerator SpawnRoutine()
    {
        // Loop while not game over
        while (spawnerEnables)
        {
            // Randomly choose between min time and max time for difference between spawns
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);

            // Define the position of the spawned object by adding to the x position a random number between min and max distance
            Vector3 positionOfSpawnedObject = new Vector3(
                    transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                    transform.position.y,
                    transform.position.z);
            // Create the new object with the object the position and no rotation
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            // Used for speed+direction of the created object- must have MoveSpawner to be used
            newObject.GetComponent<MoveSpawner>().SetVelocity(velocityOfSpawnedObject);
            }
        }
    }

