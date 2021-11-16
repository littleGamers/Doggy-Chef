using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnTrigger : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;
    [SerializeField] int gameOver;

    private bool resetListener = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject newLivesObject = GameObject.FindGameObjectWithTag("Lives");
        if (newLivesObject)
        {
            HitPoints numberOfHits = newLivesObject.GetComponent<HitPoints>();
            // Get HitPoints object to check if reached end of life - for game over
            if (other.tag == triggeringTag && enabled && numberOfHits.GetNumber() == gameOver)
            {
                Debug.Log("Game over!");
                // Turn on gameOver text and turn off player movement and spawner when game over
                GameObject.FindGameObjectWithTag("GameOverText").GetComponent<MeshRenderer>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Mover>().enabled = false;
                // Make a list of the game objects spawners
                GameObject[] listOfSpawners = GameObject.FindGameObjectsWithTag("Spawner");
                // Loop on each spawner to get his componenet and disable its spawner
                foreach (GameObject spawner in listOfSpawners)
                {
                    spawner.GetComponent<RandomTimedSpawner>().disableSpawner();
                }
                resetListener = true;
            }
        }
    }
    private void Update()
    {
        // If triggered game over and space key input was pressed then reload scene
        if (resetListener && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
