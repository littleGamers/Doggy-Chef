using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is being used in the RecipeBook screen and controls the book itself.
 * You can flip pages for the next or previous levels.
 * The levels are the books children in the hierarchy.
 */

public class RecipeManager : MonoBehaviour
{
    private int levelIndex = 0;
    private int maxLevel;

    private void Start()
    {
        // maxLevel is the number of pages in the book:
        maxLevel = transform.childCount-1;
    }
    
    // Flip to next page:
    public void levelUp()
    {
        if (levelIndex < maxLevel)
        {
            GameObject currentLevel = transform.GetChild(levelIndex++).gameObject;
            currentLevel.SetActive(false);
            GameObject nextLevel = transform.GetChild(levelIndex).gameObject;
            nextLevel.SetActive(true);
        }
    }

    // Flip to previous page:
    public void levelDown()
    {
        if (levelIndex > 0)
        {
            GameObject currentLevel = transform.GetChild(levelIndex--).gameObject;
            currentLevel.SetActive(false);
            GameObject nextLevel = transform.GetChild(levelIndex).gameObject;
            nextLevel.SetActive(true);
        }
    }

    public int getLevelIndex()
    {
        return levelIndex;
    }

    public bool isFirstLevel()
    {
        return levelIndex == 0;
    }

    public bool isLastLevel()
    {
        return levelIndex == maxLevel;
    }
}
