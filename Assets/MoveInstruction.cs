using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is the script for the first instruction - moving.
 */

public class MoveInstruction : MonoBehaviour, Instruction
{
    // The completed property frot the Instruction interface:
    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }

    // Indicatores for left and right movement:
    private bool movedLeft = false;
    private bool movedRight = false;

    private void Update()
    {
        // Complete when players tried both LEFT and RIGHT arrows:
        if (movedLeft && movedRight)
            completed = true;
        else
        {
            // Update the fields when player completed a move in a direction:
            if (Input.GetKeyDown(KeyCode.RightArrow))
                movedRight = true;
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                movedLeft = true;
        }
    }
}
