using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used to control the instructions on the screen and mark them after comletion.
 * The script is used by the empty object that has children of type "Instruction".
 */

public class InstructionManager : MonoBehaviour
{
    // Start with the first instruction child:
    private int index;
    LivesManager livesManager;
    private int initialLives = 3; // DEFAULT VALUE

    private void Start()
    {
        livesManager = GameObject.FindGameObjectWithTag("LivesLeft").GetComponent<LivesManager>();

        // If this is the second chance - jump to the ingredients instruction index,
        // If this is the first chance - start from the first instruction.
        index = (livesManager.getLives() < initialLives) ? 3 : 0;
    }
    void Update()
    {
        // If finished instructions - do nothing:
        if (index >= transform.childCount)
        {
            return;
        }
        // Get the current innstruction by index and set it to true:
        GameObject currentInstruction = transform.GetChild(index).gameObject;
        currentInstruction.SetActive(true);

        // If the current instruction is marked 'Completed' - turn it off and move to the next instruction.
        if (currentInstruction.GetComponent<Instruction>().Completed)
        {
            currentInstruction.SetActive(false);
            index++;
        }
    }
}
