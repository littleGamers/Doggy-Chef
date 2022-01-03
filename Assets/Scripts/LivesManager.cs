using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script manages the live of the player and increase/decrease life as necessary.
 */

public class LivesManager : MonoBehaviour
{
    [Tooltip("Initial lives to start with.")]
    [SerializeField] int lives;
    private GameObject livesLeftObject;
    
    void Start()
    {
        livesLeftObject = GameObject.FindGameObjectWithTag("LivesLeft");

    }
  
    // Function to decrement by one the hit points
    public void decrementLife()
    {
        if (lives-- > 0)
        {
            Destroy(livesLeftObject.transform.GetChild(0).gameObject);
        }
    }

    public int getLives()
    {
        return lives;
    }
}
