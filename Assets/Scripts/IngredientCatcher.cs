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
    [SerializeField] string goodBoosterTag;
    [SerializeField] string badBoosterTag;

    [SerializeField] float boosterDuration;
    IngredientsManager ingredientManager;

    private void Start()
    {
        ingredientManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<IngredientsManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Caught: " + other.tag);
        // If ingredient has collided - destroy and send to ingredientManager:
        if ((other.tag == goodIngredientTag || other.tag == badIngredientTag) && enabled)
        {
            Sprite ingredient = other.GetComponent<SpriteRenderer>().sprite;
            ingredientManager.addIngredient(ingredient.name);

            Destroy(other.gameObject);
        }
        else if (other.tag == goodBoosterTag && enabled)
        {
            Destroy(other.gameObject);
            StartCoroutine(goodBoosterRoutine());
        }
        else if (other.tag == badBoosterTag && enabled)
        {
            Destroy(other.gameObject);
            StartCoroutine(badBoosterRoutine());
        }
    }
    
    private IEnumerator goodBoosterRoutine()
    {
        Mover playerMover = GetComponent<Mover>();
        playerMover.setSpeed(playerMover.getSpeed() * 2);
        Debug.Log("good - Before: " + playerMover.getSpeed());
        yield return new WaitForSecondsRealtime(boosterDuration);
        playerMover.setSpeed(playerMover.getSpeed() / 2);
        Debug.Log("good - After: " + playerMover.getSpeed());
    }
    private IEnumerator badBoosterRoutine()
    {
        Mover playerMover = GetComponent<Mover>();
        playerMover.setSpeed(playerMover.getSpeed() / 2);
        Debug.Log("bad - Before: " + playerMover.getSpeed());
        yield return new WaitForSecondsRealtime(boosterDuration);
        playerMover.setSpeed(playerMover.getSpeed() * 2);
        Debug.Log("bad - After: " + playerMover.getSpeed());
    }
}
