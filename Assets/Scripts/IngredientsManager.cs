using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

/*
 * This script is used by the GameManager object.
 * 
 */
public class IngredientsManager : MonoBehaviour
{
    // Drag & Drop images of ingredients to those lists.
    // goodIngredients is for the ingredients that belong to the recipe:
    [SerializeField] List<Sprite> goodIngredients;
    [SerializeField] List<Sprite> badIngredients;
    [SerializeField] List<Sprite> goodBooster;
    [SerializeField] List<Sprite> badBooster;

    // recipeIngredients holds our data int this format -  <ingredient, is caught?>
    private Dictionary<string, bool> recipeIngredients;
    private int ingredientsCounter = 0;

    void Start()
    {
        // Add ingredients from the arrays to the dictionary:
        recipeIngredients = new Dictionary<string, bool>();
        foreach (Sprite ingredient in goodIngredients)
        {
            recipeIngredients.Add(ingredient.name, false);
        }
    }

    public int getIngredientsCounter()
    {
        return ingredientsCounter;
    }

    // This function handles caught ingredients:
    public void addIngredient(string ingredient)
    {
        // If a bad ingredient was caught:
        if (!recipeIngredients.ContainsKey(ingredient))
        {
            GetComponent<LivesManager>().decrementLife();
        }
        // If a good ingredient was caught and was not already caught before:
        else if (!recipeIngredients[ingredient])
        {
            recipeIngredients[ingredient] = true;

            // Add ingredient to the list on the screen:
            TextMeshPro ingredientsCaughtText = GameObject.FindGameObjectWithTag("IngredientsCaught").GetComponent<TextMeshPro>();
            ingredientsCaughtText.text += ingredient + "\n";

            ingredientsCounter++;
        }
    }
    
    // A simple function to check if all the ingredients on the dictionary were caught or not:
    public bool isRecipeFull()
    {
        foreach (var ingredient in recipeIngredients)
        {
            if (!ingredient.Value)
                return false;
        }
        return true;
    }

    public List<Sprite> getGoodIngredients()
    {
        return goodIngredients;
    }

    public List<Sprite> getBadIngredients()
    {
        return badIngredients;
    }

    public List<Sprite> getGoodBooster()
    {
        return goodBooster;
    }
    
    public List<Sprite> getBadBooster()
    {
        return badBooster;
    }

    // If player thinks all ingredients are caught - end the game and find out with SPACE:
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<EndGameOnCall>().endGame();
        }
    }
}
