using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{


    bool up, down, left, right = false;

    Vector2 forceVector = Vector2.up * 1.25f; //value is for tuning

    float torque = 0.75f;

    float maxVelocity = 12f;
    //float maxAngularVelocity = 10f;

    int sign = 1;

    Rigidbody2D myRigidbody;

    int keyTimerLeft = 0;
    int keyTimerRight = 0;
    int keyTimerMax = 100;

    public Transform cameraTransform; 
    float cameraBack = -15f;

    public Transform paddle;
    Vector3 rotationLeft = new Vector3(0, 0, 0.5f);
    Vector3 rotationRight = new Vector3(0, 0, -0.5f);

    int rotationcounter = 0;
    int countermax = 125;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //only check key once
        up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        if(down) {
            sign = -1;
        } else {
            sign = 1;
        }

        //increment timer while the key is being held down, reset to 0 if lifted
        //keyTimerLeft = left ? keyTimerLeft + 1 : 0;
        //keyTimerRight = left ? keyTimerRight + 1 : 0;

        //print("velocity mag: " + myRigidbody.velocity.magnitude);
        //print("angular velocity: " + myRigidbody.angularVelocity);
        //print("angle: " + myRigidbody.rotation);
        //TODO rotate the vector youre doing
        //myRigidbody.GetRelativeVector(positionLeft)
        //(Vector3)myRigidbody.GetRelativeVector(positionLeft)
        //get relative vector
        //rotateVector2(forceVector, myRigidbody.rotation)
        //apply the force in the right direction 
        //forceToApply = rotateVector2(forceVector, myRigidbody.rotation);
        //forceToApply = forceVector;
        //print(forceToApply.x);
        //force to apply in the right direction (the direction the rigidbody is facing)
        //float x = Mathf.Cos(myRigidbody.rotation + 90) * forceMagnitude;
        //float y = Mathf.Sin(myRigidbody.rotation + 90) * forceMagnitude;
        //print(x + "  " + y);
        //forceToApply = new Vector2(x, y);
        //forceToApply = rotateVector2(forceVector, myRigidbody.rotation);

        if(myRigidbody.velocity.magnitude < maxVelocity) {
            if(left && keyTimerLeft < keyTimerMax) {
                //myRigidbody.AddForceAtPosition(forceToApply * sign, transform.position + positionLeft, ForceMode2D.Force);
                //if(myRigidbody.angularVelocity < maxAngularVelocity) {
                    //myRigidbody.AddForceAtPosition(transform.position + (forceVector * -sign), positionLeft, ForceMode2D.Force);
                //}
                //myRigidbody.angularVelocity = Mathf.Clamp(myRigidbody.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
                myRigidbody.AddRelativeForce(forceVector * sign);
                myRigidbody.AddTorque(torque);
            } else if(right && keyTimerRight < keyTimerMax) {
                //myRigidbody.AddForceAtPosition(forceToApply * sign, transform.position + positionRight, ForceMode2D.Force);
                //if(myRigidbody.angularVelocity > -maxAngularVelocity) {
                    //myRigidbody.AddForceAtPosition(transform.position + (forceVector * -sign), positionRight, ForceMode2D.Force);
                //}
                //myRigidbody.angularVelocity = Mathf.Clamp(myRigidbody.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
                myRigidbody.AddRelativeForce(forceVector * sign);
                myRigidbody.AddTorque(-torque);
            }
        }

        //update camera 
        cameraTransform.position = transform.position + new Vector3(0f, 0f, cameraBack);

        //move paddle
        if(left) {
            if(rotationcounter < countermax) {
                paddle.Rotate(rotationLeft * sign, Space.Self);
                rotationcounter++;
            }
        } else if(right) {
            if(rotationcounter > -countermax) {
                paddle.Rotate(rotationRight * sign, Space.Self);
                rotationcounter--;
            }
        } else {
            if(rotationcounter > 0) {
                paddle.Rotate(rotationRight * sign, Space.Self);
                rotationcounter--;
            } else if(rotationcounter < 0) {
                paddle.Rotate(rotationLeft * sign, Space.Self);
                rotationcounter++;
            }
        }

    }
}
