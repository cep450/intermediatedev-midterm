using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
/*
    public float farthestDistance = 0f;

    float accelerationConst = 0.01f;
    float acceleration = 0f;
    float maxVelocity = 0.5f;
    float accelerationDecay = 0.01f;
    

    float angleToAdd = 0.05f;
    float maxAngleToAdd = 1f;

    float velocity = 0f;
    Vector2 directionVector = Vector2.zero;
    Vector2 movementVector = Vector2.zero;


    bool up, down, left, right = false;

    // Update is called once per frame
    void Update()
    {

        //only check key once
        up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);


        //forwards or backwards?
        if(down) {
            acceleration = -accelerationConst;
        } else if(up) {
            acceleration = accelerationConst;
        }

        //set velocity, but don't go faster than the max speed
        velocity = Mathf.Clamp(velocity + acceleration, maxVelocity, -maxVelocity);
        //TODO acceleration decay

        //left or right?

        //create the movement vector accordingly
        movementVector = Vector2.up * velocity;

        //finally, apply the movement
        transform.Translate(movementVector.x, movementVector.y, 0f);

        //and don't forget to rotate the sprite


        //finally, update the farthest y pos we've gotten
        farthestDistance = Mathf.Max(transform.position.y, farthestDistance);

    }
    */
}
