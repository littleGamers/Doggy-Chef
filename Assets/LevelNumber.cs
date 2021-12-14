using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script is used to set the level number text with the correct level.
// Developer should update the level number in Unity Editor.

public class LevelNumber : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    void Start()
    {
        GetComponent<TextMeshPro>().text = "Level " + levelNumber;
    }

    public int getLevelNumber()
    {
        return levelNumber;
    }
}
