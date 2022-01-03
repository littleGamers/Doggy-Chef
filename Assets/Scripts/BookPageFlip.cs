using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is being used on the arrow object from the RecipeBook scene.
 * It make the arrow clickable and allows to flip pages on the recipe book.
 * You can also use the keyboard arrows to flip pages.
 */

public class BookPageFlip : MonoBehaviour
{
    // Check box to mark the 'RIGHT' arrow. Uncheck for the 'LEFT' arrow.
    [Tooltip ("Check this box for the \"next level\" arrow.")]
    [SerializeField] private bool isNext;
    private RecipeManager recipeManager;

    private void Start()
    {
        recipeManager = GameObject.FindGameObjectWithTag("RecipeBook").GetComponent<RecipeManager>();
    }

    private void OnMouseUpAsButton()
    {
        // If the right arrow was pressed with the mouse - flip to the next level page. 
        if (isNext)
        {
            recipeManager.levelUp();
        }
        else
        {
            recipeManager.levelDown();
        }
    }

    private void Update()
    {
        // If the RIGHT arrow was pressed on the keyboard - flip to the next level page. 
        if (Input.GetKeyDown(KeyCode.RightArrow) && isNext)
        {
            recipeManager.levelUp();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isNext)
        {
            recipeManager.levelDown();
        }
        // If we are at the first level in the book and in right arrow OR are at the last level in the book and in left arrow,
        // disable sprite renderer of arrow.
        else if (isNext && recipeManager.isLastLevel() || !isNext && recipeManager.isFirstLevel())
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        // When none of the conditions are true, enable sprite renderer of arrow.
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
