using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * A simple interface for instructions.
 * All classes that implements Instruction needs to have the Completed property.
 */
public interface Instruction
{
    bool Completed {
        get;
    }
}
