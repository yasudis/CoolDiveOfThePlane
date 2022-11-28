using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private DynamicJoystick dynamicJoystick;

    private float _xAxis;
    private float _zAxis;

    [Header("Set Dynamically")]
    public float CamWidth;
    public float CamHeight;
    public float Radius = 1f;

    public ControllerOfPlayer ControllerOfPlayer;


    private void Awake()
    {
        CamHeight = Camera.main.orthographicSize;
        CamWidth = CamHeight * Camera.main.aspect;
        ControllerOfPlayer = FindObjectOfType<ControllerOfPlayer>();
    }
    private void FixedUpdate()
    {
        _xAxis = dynamicJoystick.Horizontal;
        _zAxis = dynamicJoystick.Vertical;
        ControllerOfPlayer.JostikControllOfPlayer(_xAxis, _zAxis);

    }
    void LateUpdate()
    {
        ControllerOfPlayer.ControlPositionOfPlaer(CamWidth, CamHeight, Radius);
    }
   
}
