using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the right tag has enetered the function OnTriggerEnter2D, if yes - destroy the spawned object
        if (other.tag == triggeringTag && enabled)
        {
            Destroy(this.gameObject);
        }
    }
}
