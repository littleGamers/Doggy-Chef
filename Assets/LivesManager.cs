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
    private HitPoints textLives;
    
    void Start()
    {
        textLives = GameObject.FindGameObjectWithTag("Lives").GetComponent<HitPoints>();
    }
    public void incrementLife()
    {
        textLives.SetNumber(++this.lives);
    }

    // Function to decrement by one the hit points
    public void decrementLife()
    {
        if (lives > 0)
            textLives.SetNumber(--this.lives);
    }

    public int getLives()
    {
        return lives;
    }
}
