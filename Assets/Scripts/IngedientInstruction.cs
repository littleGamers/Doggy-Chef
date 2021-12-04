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
    [SerializeField] private string badIngredientsText;

    // The object that is the parent of the spawners objects:
    private GameObject spawners;

    // spawnerIndex can be 0 or 1 because there are 2 spawners.
    private int spawnerIndex = 0;

    // This bool is initialized on true to mark the first stage.
    private bool isMatch = true;

    // Game manager to get the initial lives and recipe book:
    private GameObject gameManager;
    private int initialLives;

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
        initialLives = gameManager.GetComponent<LivesManager>().getLives();

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
            // Check if a good ingredient was caught with the IngredientsManager:
            int ingredientsCaught = gameManager.GetComponent<IngredientsManager>().getIngredientsCounter();
            if (ingredientsCaught > 0)
            {
                // Mark first stage as finished:
                isMatch = false;

                // Disable good spawner and enable bad spawner for second stage:
                GameObject goodSpawner = spawners.transform.GetChild(spawnerIndex).gameObject;
                goodSpawner.SetActive(false);

                GameObject badSpawner = spawners.transform.GetChild(++spawnerIndex).gameObject;
                badSpawner.SetActive(true);

                // Update the text instruction:
                GetComponent<TextMeshPro>().text = badIngredientsText;

                // Update the lives text instruction:
                GameObject livesText = transform.GetChild(0).gameObject;
                livesText.SetActive(true);

            }
        }
        // Second stage:
        // The player should get a bad ingredient for learning purposes.
        else if (gameManager.GetComponent<LivesManager>().getLives() < initialLives)
        {
            GameObject goodSpawner = spawners.transform.GetChild(--spawnerIndex).gameObject;

            // If done successfuly - the good spawner is enabled again and the game continues.
            goodSpawner.SetActive(true);
            goodSpawner.GetComponent<RandomTimedSpawner>().startSpawning();
            completed = true;
        }
    }
}
