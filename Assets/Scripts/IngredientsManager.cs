using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

/*
 * This script is used by the GameManager object.
 */
public class IngredientsManager : MonoBehaviour
{
    // Drag & Drop images of ingredients to those lists.
    // goodIngredients is for the ingredients that belong to the recipe:
    [SerializeField] List<Sprite> goodIngredients;
    [SerializeField] List<Sprite> badIngredients;
    [SerializeField] List<Sprite> goodBooster;
    [SerializeField] List<Sprite> badBooster;

    // recipeIngredients holds our data in this format -  <ingredient, is caught?>
    private Dictionary<string, bool> recipeIngredients;
    List<string> ingredientsCaught;
    private int ingredientsLeft;
    private string badIngredientCaught = "";

    private TextMeshPro ingredientsCaughtText;
    private TextMeshPro ingredientsLeftText;

    void Start()
    {
        // Add ingredients from the arrays to the dictionary:
        recipeIngredients = new Dictionary<string, bool>();
        foreach (Sprite ingredient in goodIngredients)
        {
            recipeIngredients.Add(ingredient.name, false);
        }
        ingredientsLeft = goodIngredients.Count;
        ingredientsCaught = new List<string>();

        ingredientsCaughtText = GameObject.FindGameObjectWithTag("IngredientsCaught").GetComponent<TextMeshPro>();
        ingredientsLeftText = GameObject.FindGameObjectWithTag("IngredientsLeft").GetComponent<TextMeshPro>();
        ingredientsLeftText.text = ingredientsLeft.ToString();
    }

    public int getIngredientsCounter()
    {
        return ingredientsLeft;
    }

    // This function handles caught ingredients:
    public void addIngredient(string ingredient)
    {
        if (!ingredientsCaught.Contains(ingredient) && ingredientsLeft > 0)
        {
                ingredientsCaught.Add(ingredient);
                ingredientsLeft--;

                // Add ingredient to the list on the screen:
                ingredientsCaughtText.text += ingredient + "\n";

                // Update Ingredients Left on the screen:
                ingredientsLeftText.text = ingredientsLeft.ToString();

                if (isBadIngredient(ingredient))
                {
                    badIngredientCaught = ingredient;
                }
        }
        else
        {
            // Print duplicate ingredient
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

    public string getBadIngredientCaught()
    {
        return badIngredientCaught;
    }

    private bool isBadIngredient(string ingredient)
    {
        foreach (Sprite ingredientSprite in badIngredients)
        {
            if (ingredientSprite.name == ingredient)
                return true;
        }
        return false;
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
        if (ingredientsLeft <= 0)
        {
            GetComponent<EndGameOnCall>().endGame();
        }
    }
}
