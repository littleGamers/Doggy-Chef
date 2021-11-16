using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed;
    Bounds backgroundBounds;

    // Start is called before the first frame update
    void Start()
    {
        // Get the background bounds of the object using sprite renderer bounds
        backgroundBounds = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal used to get the correct direction on the x-axis - right:1, left:-1 
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

        // Check if the new position located on the background bounds, if yes then change current position to the new position 
        if (backgroundBounds.Contains(newPosition))
        {
            transform.position = newPosition;
        }
    }
}
