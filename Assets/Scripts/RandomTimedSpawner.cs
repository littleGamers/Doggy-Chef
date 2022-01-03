using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class RandomTimedSpawner : MonoBehaviour
{
    [SerializeField] MoveSpawner prefabToSpawn;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns;
    private Vector3 velocityOfSpawnedObject;

    private bool spawnerEnables = true;
    private float leftBoundX, rightBoundX;
    private List<Sprite> ingredientsToSpawn;
    [Tooltip("Set the size of the ingredient")] [SerializeField] Vector3 sizeOfIngredient; // Can be used for different levels.

    void Start()
    {
        Bounds leftBoundObject = GameObject.FindGameObjectWithTag("LeftBound").GetComponent<Collider2D>().bounds;
        Bounds backgroundBounds = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().bounds;

        float boundsOffset = leftBoundObject.size.x;

        leftBoundX = leftBoundObject.center.x + boundsOffset;
        rightBoundX = backgroundBounds.max.x - boundsOffset;

        IngredientsManager ingredientsManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<IngredientsManager>();

        switch (gameObject.tag)
        {
            case "GoodIngredientsSpawner":
                ingredientsToSpawn = ingredientsManager.getGoodIngredients();
                break;
            case "BadIngredientsSpawner":
                ingredientsToSpawn = ingredientsManager.getBadIngredients();
                break;
            case "GoodBooster":
                ingredientsToSpawn = ingredientsManager.getGoodBooster();
                break;
            case "BadBooster":
                ingredientsToSpawn = ingredientsManager.getBadBooster();
                break;
        }

        /*
         *                           ### Velocity Calculation: ###
         * Our formula uses the player's velocity and the level difficulty to calculate the velocity
         * of the spawned object.
         * 
         *                              ### The Formula: ###
         *                   -1 * (PlayerSpeed/2.5) * difficultyMultiplier
         *                   
         *                              ### Explanation: ###
         * -1 -> Because we want the ingredient to move downwards the Y axis.
         * 
         * (PlayerSpeed/2.5) -> The distance from the spawner to the player on the Y axis is 7.
         *                      The distance between the bounds of the player's movement on the X axis is 17.5.
         *                      So the ratio between the distances is 17.5/7 = 2.5.
         *                      The base ingredient speed should be (PlayerSpeed/2.5) so that the player
         *                      will be able to reach an ingredient on the other side of the screen.
         *                      
         * difficultyMultiplier -> Start from 1 to infinity.
         *                         For each level we add (0.3 * levelNumber),
         *                         since 0.3 is a reasonable upgrade for each level according to testing.
         *                         For example: Level 0 -> 1.0, Level 1 -> 1.3, ...
         */
        LevelNumber currentLevel = GameObject.FindGameObjectWithTag("LevelNumber").GetComponent<LevelNumber>();
        float difficultyMultiplier = 1f + (0.3f * currentLevel.getLevelNumber());

        Mover playerMover = GameObject.FindGameObjectWithTag("Player").GetComponent<Mover>();

        velocityOfSpawnedObject = new Vector3(0,-1f * (playerMover.getSpeed() / 2.5f) * difficultyMultiplier, 0);

        startSpawning();
    }

    public void startSpawning()
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
                    Random.Range(leftBoundX, rightBoundX),
                    transform.position.y,
                    transform.position.z);
            // Create the new object with the object the position and no rotation
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.transform.localScale = sizeOfIngredient;
            newObject.GetComponent<SpriteRenderer>().sprite = ingredientsToSpawn[Random.Range(0, ingredientsToSpawn.Count)];

            // Used for speed+direction of the created object- must have MoveSpawner to be used
            newObject.GetComponent<MoveSpawner>().SetVelocity(velocityOfSpawnedObject);
            }
        }
    }

