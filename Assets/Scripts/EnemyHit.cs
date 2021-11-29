using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Get gameManager object to decrement the number of hits when got hit and destroy game object (enemy- BadIngredients)
        if (other.tag == triggeringTag && enabled)
        {
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
            if (gameManager)
            {
                LivesManager numberOfHits = gameManager.GetComponent<LivesManager>();
                Destroy(other.gameObject);
                numberOfHits.decrementLife();
            }
        }
    }
}
