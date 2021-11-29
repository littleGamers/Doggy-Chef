using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * A script for the WinScene screen.
 * Takes the dish from the previous level (after a win) and place it the plate at the center of the screen.
 */

public class PlaceDishOnPlate : MonoBehaviour
{
    // The scale of the dish image will be upscaled by dishUpscaleRatio.
    [SerializeField] private float dishUpscaleRatio;
    void Start()
    {
        GameObject dish = GameObject.FindGameObjectWithTag("DishImage");
        if (dish)
        {
            // Place dish on the plate and upscale it:
            dish.transform.position = this.transform.position;
            dish.transform.localScale *= dishUpscaleRatio;

            // Makes the object destroyable again when moving to next scene:
            SceneManager.MoveGameObjectToScene(dish, SceneManager.GetActiveScene());
        }
    }

}
