using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTrigger : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;


    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        
        if (gameManager)
        {
            EndGameOnCall gameEnder = gameManager.GetComponent<EndGameOnCall>();
            LivesManager livesManager = gameManager.GetComponent<LivesManager>();

            int livesLeft = livesManager.getLives();
            // Get HitPoints object to check if reached end of life - for game over
            if (other.tag == triggeringTag && enabled && livesLeft <= 0)
            {
                gameEnder.endGame();   
            }
        }
    }
    
}
