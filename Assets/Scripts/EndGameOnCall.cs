using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * This script is used to end a game and decide the reason for ending.
 * Every reason leads to a different outcome.
 */
public class EndGameOnCall : MonoBehaviour
{
    private LivesManager livesManager;
    private IngredientsManager ingredientManager;

    // When set to true - enables reset with LCTRL:
    private bool resetListener = false;

    void Start()
    {
        livesManager = GetComponent<LivesManager>();
        ingredientManager = GetComponent<IngredientsManager>();
    }

    public void endGame()
    {
        int livesLeft = livesManager.getLives();
        // If the player have lost all his lives:
        if (livesLeft <= 1)
        {
            Debug.Log("Game over!");
            suspendAndReset("Game Over!.\nPress LCTRL To Try Again :)");
        }
        else
        {
            // If the player finished without catching all the ingredients for the recipe:
            if (!ingredientManager.isRecipeFull())
            {
                Debug.Log("Recipe is not complete!");
                suspendAndReset("Oops! Recipe is not complete.\nPress LCTRL To Try Again :)");
            }
            // If the user finished after all the ingredients for the recipe were catched:
            else
            {
                // Don't destroy the dish image, for the WinScene screen:
                GameObject dishImage = GameObject.FindGameObjectWithTag("DishImage");
                dishImage.transform.parent = null;
                DontDestroyOnLoad(dishImage);

                // Load the WinScene screen:
                SceneManager.LoadScene("WinScene");
            }
        }
    }

    private void suspendAndReset(string message)
    {
        // Turn on gameOver text and set a format:
        GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOverText");
        gameOverText.GetComponent<TextMeshPro>().text = message;
        gameOverText.GetComponent<TextMeshPro>().fontSize = 17;
        gameOverText.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Center;
        gameOverText.GetComponent<MeshRenderer>().enabled = true;

        // Turn off all instructions:
        GameObject instructions = GameObject.FindGameObjectWithTag("Instructions");
        if (instructions)
            instructions.SetActive(false);

        // Disable player movement:
        GameObject.FindGameObjectWithTag("Player").GetComponent<Mover>().enabled = false;

        // Get the spawners parent object:
        GameObject spawners = GameObject.FindGameObjectWithTag("Spawners");
        // Disable spawners
        foreach (RandomTimedSpawner spawner in spawners.GetComponentsInChildren<RandomTimedSpawner>())
        {
            spawner.disableSpawner();
        }

        // Enable reset on LCTRL:
        resetListener = true;
    }

    private void Update()
    {
        // If triggered by flag - enable reset with LCTRL key:
        if (resetListener && Input.GetKeyDown(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
