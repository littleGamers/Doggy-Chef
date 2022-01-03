using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarInstruction : MonoBehaviour, Instruction
{
    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            completed = true;
        }
    }
}
