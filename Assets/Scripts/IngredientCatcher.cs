using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used on the player to handle caught ingredients.
 * Each ingredient should be destroyed and sent to the IngredientsManager for further handling.
 */

public class IngredientCatcher : MonoBehaviour
{
    [Tooltip("Every object tagged with this tags will trigger the destruction of this object")]
    [SerializeField] string goodIngredientTag;
    [SerializeField] string badIngredientTag;
    IngredientsManager ingredientManager;

    private void Start()
    {
        ingredientManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<IngredientsManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If ingredient has collided - destroy and send to ingredientManager:
        if ((other.tag == goodIngredientTag || other.tag == badIngredientTag) && enabled)
        {
            Sprite ingredient = other.GetComponent<SpriteRenderer>().sprite;
            ingredientManager.addIngredient(ingredient.name);

            Destroy(other.gameObject);
        }
    }
}
