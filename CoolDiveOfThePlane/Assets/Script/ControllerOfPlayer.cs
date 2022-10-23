using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOfPlayer : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    // private float speedOfAngleTurel;
    public Rigidbody rb;
    private float angle;
    public GameObject player;
    public GameObject playerFlyer;

    public float rollMult = -45;
    public float pitchMult = -30;
    public float radius = 1f;
    [Header("Set Dynamically")]
    public float camWidth;
    public float camHeight;
    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }



    public void FixedUpdate()
    {

        // Извлечь информацию из класса Input
        float xAxis = dynamicJoystick.Horizontal;
        float zAxis = dynamicJoystick.Vertical;
        angle = angle + dynamicJoystick.Horizontal * 5;

        if (dynamicJoystick.Horizontal != 0)
        {
            //playerFlyer.transform.Rotate(0, 0, dynamicJoystick.Horizontal * 5);
            player.transform.Translate(dynamicJoystick.Horizontal * 1, 0, 0);
            // Повернуть корабль, чтобы придать ощущение динамизма // с
            playerFlyer.transform.rotation = Quaternion.Euler(zAxis * pitchMult, 0, xAxis * rollMult);
        }
        else
        {
           playerFlyer.transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        if (Mathf.Abs(angle) > 360)
        {
            angle = 0;
        }
        // Vector3 input = new Vector3(_fixedJoystick.Horizontal, _fixedJoystick.Vertical);
        // Vector3 velocity = input.normalized * speed;
        //transform.position += velocity * Time.deltaTime;
    }
    void LateUpdate()
    { // d
        Vector3 pos = player.transform.position;
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
        }
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
        }
        if (pos.z > camHeight - radius)
        {
            pos.z = camHeight - radius;
        }
        if (pos.z < -camHeight + radius)
        {
            pos.z = -camHeight * radius;
        }
        transform.position = pos;

    }
}
