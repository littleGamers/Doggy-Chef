using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This instruction is used to teach the player the meaning of catching good or bad ingredients.
 * First stage is teaching good ingredient catching.
 * Seconds stage is teaching bad ingredient catching
 */
public class IngedientInstruction : MonoBehaviour, Instruction
{
    // Text strings to mark the instructions for each type of ingredient.
    [SerializeField] private string goodIngredientsText;
    [SerializeField] private string badIngredientsFirstChanceText;

    // The object that is the parent of the spawners objects:
    private GameObject spawners;

    // spawnerIndex can be 0 or 1 because there are 2 spawners.
    private int spawnerIndex = 0;

    // This bool is initialized on true to mark the first stage.
    private bool isMatch = true;

    // Game manager to get the initial lives and recipe book:
    private GameObject gameManager;
    private GameObject livesLeftObject;
    private int initialLives = 3; // DEFAULT VALUE

    // The 'completed' property from the Instruction interface:
    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }

    void Start()
    {
        // Initialize fields:
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        livesLeftObject = GameObject.FindGameObjectWithTag("LivesLeft");

        // Start with the first stage text instruction:
        GetComponent<TextMeshPro>().text = goodIngredientsText;

        // Enable the first spawner:
        spawners = GameObject.FindGameObjectWithTag("Spawners");
        spawners.transform.GetChild(spawnerIndex).gameObject.SetActive(true);
    }

    void Update()
    {
        // First stage:
        if (isMatch)
        {
            // Check if a good ingredient (out of 2 possible in the tutorial) was caught with the IngredientsManager:
            int ingredientsLeft = gameManager.GetComponent<IngredientsManager>().getIngredientsCounter();
            if (ingredientsLeft < 2)
            {
                // Mark first stage as finished:
                isMatch = false;

                // Disable good spawner and enable bad spawner for second stage:
                GameObject goodSpawner = spawners.transform.GetChild(spawnerIndex).gameObject;
                goodSpawner.SetActive(false);

                GameObject badSpawner = spawners.transform.GetChild(++spawnerIndex).gameObject;
                badSpawner.SetActive(true);

                // Update the text instruction:
                GetComponent<TextMeshPro>().text = badIngredientsFirstChanceText;
            }
        }
        // Second stage:
        // The player should get a bad ingredient for learning purposes.

        else if (livesLeftObject.GetComponent<LivesManager>().getLives() < initialLives)
        {
            GameObject goodSpawner = spawners.transform.GetChild(--spawnerIndex).gameObject;

            // If done successfuly - the good spawner is enabled again and the game continues.
            goodSpawner.SetActive(true);
            goodSpawner.GetComponent<RandomTimedSpawner>().startSpawning();
            completed = true;
        }
    }
}
