using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used to set the desired level in the RecipeBook screen between levels.
 */

public class PlayChosenLevel : MonoBehaviour
{
    private RecipeManager recipeManager;

    [Tooltip("The prefix of the level scene names. For example: Level_")]
    [SerializeField] string levelScenePrefix;
    void Start()
    {
        recipeManager = GameObject.FindGameObjectWithTag("RecipeBook").GetComponent<RecipeManager>();
    }

    void Update()
    {
        string levelToLoad = levelScenePrefix + recipeManager.getLevelIndex();
        GetComponent<MouseSceneLoader>().setSceneToLoad(levelToLoad);
    }
}
