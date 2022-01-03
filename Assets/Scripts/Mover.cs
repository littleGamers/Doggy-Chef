using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed;
    Bounds playerBounds;
    private float boundsOffset;

    // Start is called before the first frame update
    void Start()
    {
        boundsOffset = GetComponent<Collider2D>().bounds.size.x / 2;

        playerBounds = new Bounds();
        Bounds backgroundBounds = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().bounds;
        GameObject leftBoundObject = GameObject.FindGameObjectWithTag("LeftBound");
        playerBounds.SetMinMax(new Vector3(leftBoundObject.transform.position.x + boundsOffset, transform.position.y, transform.position.z),
                                new Vector3(backgroundBounds.max.x - boundsOffset, transform.position.y, transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal used to get the correct direction on the x-axis - right:1, left:-1 
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

        // Check if the new position located on the background bounds, if yes then change current position to the new position 
        if (playerBounds.Contains(newPosition))
        {
            transform.position = newPosition;
        }
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
}
