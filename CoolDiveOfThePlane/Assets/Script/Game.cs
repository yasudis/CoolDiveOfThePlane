using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private DynamicJoystick dynamicJoystick;
    [SerializeField] private float _timeToDoItForFlyPlane=10f;

    private float _xAxis;
    private float _zAxis;
 
    [Header("Set Dynamically")]
    [SerializeField] private  float CamWidth;
    [SerializeField] private float CamHeight;
    [SerializeField] private float Radius = 1f;

    public ControllerOfPlayer ControllerOfPlayer;
    public FlyPlane FlyPlane;
    private void Awake()
    {
        CamHeight = Camera.main.orthographicSize;
        CamWidth = CamHeight * Camera.main.aspect;
        ControllerOfPlayer = FindObjectOfType<ControllerOfPlayer>();
        FlyPlane = FindObjectOfType<FlyPlane>();  
    }
    private void FixedUpdate()
    {
        _xAxis = dynamicJoystick.Horizontal;
        _zAxis = dynamicJoystick.Vertical;
        ControllerOfPlayer.ControledJostikOfPlayer(_xAxis, _zAxis);
        if (_timeToDoItForFlyPlane <= 0)
        {
            _timeToDoItForFlyPlane = 1f;
            Debug.Log("Time-work");
            FlyPlane.DoItOfPlane();
        }
        else
        {
            _timeToDoItForFlyPlane -= Time.deltaTime;
        }
    }
   private void LateUpdate()
    {
        ControllerOfPlayer.ControledPositionOfPlaer(CamWidth, CamHeight, Radius);
    }
   
}
