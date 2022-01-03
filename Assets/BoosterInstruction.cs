using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoosterInstruction : MonoBehaviour, Instruction
{
    // Text strings to mark the instructions for each type of booster.
    [SerializeField] private string goodBoosterText;
    [SerializeField] private string badBoosterText;

    // The object that is the parent of the spawners objects - needs to be initialized in editor:
    [SerializeField] private GameObject[] spawners;

    // spawnerIndex can be 0 or 1 because there are 2 spawners.
    private int spawnerIndex = 0;

    // This bool is initialized on true to mark the first stage.
    private bool isGood = true;

    // Player mover object to check if speed has changed (booster was caught):
    private Mover playerMover;
    private float initialSpeed; // DEFAULT VALUE

    // The 'completed' property from the Instruction interface:
    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }

    void Start()
    {
        // Initialize fields:
        playerMover = GameObject.FindGameObjectWithTag("Player").GetComponent<Mover>();
        initialSpeed = playerMover.getSpeed();

        // Start with the first stage text instruction:
        GetComponent<TextMeshPro>().text = goodBoosterText;

        // Enable the first spawner:
        spawners[spawnerIndex].SetActive(true);
        
    }

    void Update()
    {
        // First stage:
        if (isGood)
        {
            if (playerMover.getSpeed() > initialSpeed)
            {
                spawners[spawnerIndex++].SetActive(false);
                spawners[spawnerIndex].SetActive(true);
                isGood = false;
                GetComponent<TextMeshPro>().text = badBoosterText;
            }
        }
        // Second stage - catching the slow/bad booster:
        else if (playerMover.getSpeed() < initialSpeed)
        {
            // Update the text instruction:
            // If done successfuly - the booster spawners are disabled and instruction is completed.
            spawners[spawnerIndex].SetActive(false);
            completed = true;
        }
    }
}
