using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DuplicateNotification : MonoBehaviour
{
    [SerializeField] private int timeToShow;
    public void show()
    {
        StartCoroutine(duplicateNotification());
    }

    IEnumerator duplicateNotification()
    {
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSecondsRealtime(timeToShow);
        GetComponent<Renderer>().enabled = false;
    }
}
