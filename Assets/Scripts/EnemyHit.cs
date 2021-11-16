using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Get HitPoints object to decrement the number of hits when got hit and destroy game object (enemy- BadIngredients)
        if (other.tag == triggeringTag && enabled)
        {
            GameObject newLivesObject = GameObject.FindGameObjectWithTag("Lives");
            if (newLivesObject)
            {
                HitPoints numberOfHits = newLivesObject.GetComponent<HitPoints>();
                Destroy(other.gameObject);
                numberOfHits.decrementHit();
            }
        }
    }
}
