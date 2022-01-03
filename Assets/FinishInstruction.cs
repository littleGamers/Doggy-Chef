using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishInstruction : MonoBehaviour, Instruction
{
    // Text string to mark the last instruction.
    [SerializeField] private string lastInstuction;

    // The 'completed' property from the Instruction interface:
    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }

    void Start()
    {
        GetComponent<TextMeshPro>().text = lastInstuction;
    }
}
