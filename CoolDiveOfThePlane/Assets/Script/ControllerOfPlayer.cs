using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOfPlayer : MonoBehaviour
{
    
    // private float speedOfAngleTurel;
    public Rigidbody rb;
    private float angle;
    public GameObject player;
    public GameObject playerFlyer;

    public float _rollMult = -45;
    public float pitchMult = -30;
    
    
        
    public void JostikControllOfPlayer(float xAxis, float zAxis)
    {

        // Извлечь информацию из класса Input
        
        angle = angle + xAxis * 5;

        if (xAxis != 0)
        {
            //playerFlyer.transform.Rotate(0, 0, dynamicJoystick.Horizontal * 5);
            player.transform.Translate(xAxis * 1, 0, 0);
            // Повернуть корабль, чтобы придать ощущение динамизма // с
            playerFlyer.transform.rotation = Quaternion.Euler(zAxis * pitchMult, 0, xAxis * _rollMult);
        }
        else
        {
            playerFlyer.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Mathf.Abs(angle) > 360)
        {
            angle = 0;
        }
    }
    public void ControlPositionOfPlaer(float camWidth, float camHeight, float radius)
        
    { 
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
