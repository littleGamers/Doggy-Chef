using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTrigger : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;


    private void OnTriggerEnter2D(Collider2D other)
    {
        EndGameOnCall gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EndGameOnCall>();
        LivesManager livesManager = GameObject.FindGameObjectWithTag("LivesLeft").GetComponent<LivesManager>();

        if (gameManager)
        {
            int livesLeft = livesManager.getLives();
            Debug.Log("Lives left: " + livesLeft);
            // Get HitPoints object to check if reached end of life - for game over
            if (other.tag == triggeringTag && enabled && livesLeft <= 1)
            {
                gameManager.endGame();   
            }
        }
    }
    
}
