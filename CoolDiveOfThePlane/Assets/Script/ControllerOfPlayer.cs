using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOfPlayer : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
   // private float speedOfAngleTurel;
   // public Rigidbody rb;
    private float angle;
    public GameObject player;
 

    public void FixedUpdate()
    {
        angle = angle + dynamicJoystick.Horizontal*5;

        if (dynamicJoystick.Horizontal != 0)
        {
           player.transform.Rotate(0,0, dynamicJoystick.Horizontal * 5);
           player.transform.Translate(dynamicJoystick.Horizontal*1, 0, 0);


        }
        if (Mathf.Abs(angle) > 360)
        {
            angle = 0;
        }
        // Vector3 input = new Vector3(_fixedJoystick.Horizontal, _fixedJoystick.Vertical);
        // Vector3 velocity = input.normalized * speed;
        //transform.position += velocity * Time.deltaTime;
    }
}
