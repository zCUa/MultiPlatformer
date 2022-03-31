using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlades : MonoBehaviour
{
    public float startX;
    public float endX;
    public float startY;
    public float endY;

    public float speed;

    private float newX;
    private float newY;

    Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetNewPosition(endX, endY);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the position if it hasn't reached the target else update the target when it reaches.
        if((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        } else {
            // Nested for local variables to be updated
            if(newX == endX && newY == endY) {
                newX = startX;
                newY = startY;
            } else {
                newX = endX;
                newY = endY;
            }
            
            targetPosition = GetNewPosition(newX, newY);
        }
    }

    // Function updates the position of the saw blade
    Vector2 GetNewPosition(float updateX, float updateY) 
    {
        return new Vector2(updateX, updateY);
    }

}
