using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * A simple script that creates buttons from objects to load scenes.
 */

public class MouseSceneLoader : MonoBehaviour
{
    [Tooltip("The scene that will be loaded when button is pressed.")]
    [SerializeField] private string sceneToLoad;
   
    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void setSceneToLoad(string scene)
    {
        sceneToLoad = scene;
    }
}
