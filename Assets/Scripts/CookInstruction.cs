using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This script is used to manage the last instruction - cooking.
 * First stage - Tell the player to catch the last ingredient.
 * Second stage - Tell the player to cook with SPACE.
 */

public class CookInstruction : MonoBehaviour, Instruction
{
    // The text instruction for both stages:
    [SerializeField] private string catchInstruction;
    [SerializeField] private string cookInstruction;

    private IngredientsManager ingredientsManager;

    // The 'completed' property from the Instruction interface:
    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }
    void Start()
    {
        ingredientsManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<IngredientsManager>();
        GetComponent<TextMeshPro>().text = catchInstruction;
    }

    void Update()
    {
        // if the player collected all needed ingredients - tell him to cook and wait for him to press SPACE:
        if (ingredientsManager.isRecipeFull())
        {
            GetComponent<TextMeshPro>().text = cookInstruction;
            if (Input.GetKeyDown(KeyCode.Space))
                completed = true;
        }
    }
}
