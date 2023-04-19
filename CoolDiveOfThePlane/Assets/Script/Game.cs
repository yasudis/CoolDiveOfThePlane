using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private DynamicJoystick dynamicJoystick;
    [SerializeField] private float _timeToDoItForFlyPlane = 1f;

    private float _xAxis;
    private float _zAxis;

    [Header("Set Dynamically")]
    [SerializeField] private float CamWidth;
    [SerializeField] private float CamHeight;
    [SerializeField] private float Radius = 1f;

    public ControllerPlayer ControllerPlayer;
    private FlyPlane FlyPlane;

    public GameObject[] BoxEvents;
    public GameObject[] Clouds;
    private GameObject[] _boxEvetNow;

    private bool isPaused = false;
    private bool _onEnablePauseButton = false;
    public GameObject menuPanel;

    private void Awake()
    {
        CamHeight = Camera.main.orthographicSize;
        CamWidth = CamHeight * Camera.main.aspect;
        ControllerPlayer = FindObjectOfType<ControllerPlayer>();
        FlyPlane = FindObjectOfType<FlyPlane>();

    }
    private void FixedUpdate()
    {
        _xAxis = dynamicJoystick.Horizontal;
        _zAxis = dynamicJoystick.Vertical;
        ControllerPlayer.ControledJostikPlayer(_xAxis, _zAxis);
        if (_timeToDoItForFlyPlane <= 0)
        {
            _timeToDoItForFlyPlane = 1f;
            Debug.Log("Time-work");
            FlyPlane.DoItPlane();
            InstatiateBoxEvent();
            InstatiateClouds();
        }
        else
        {
            _timeToDoItForFlyPlane -= Time.deltaTime;
        }
    }
    private void LateUpdate()
    {
        ControllerPlayer.ControledPositionPlaer(CamWidth, CamHeight, Radius);
    }
    private void InstatiateBoxEvent()
    {
        float spawnAcisX = Random.Range(-CamWidth, CamWidth);
        float spawnAcisZ = CamHeight + 2;
        int numberNumberBoxEvents = Random.Range(0, BoxEvents.Length);
        Vector3 spawnPos = new Vector3(spawnAcisX, -10, spawnAcisZ);
        Instantiate(BoxEvents[numberNumberBoxEvents], spawnPos, Quaternion.identity);
    }
    private void InstatiateClouds()
    {
        if (GameObject.FindGameObjectsWithTag("Cloud").Length < 15)
        {
            float spawnAcisX = Random.Range(-CamWidth, CamWidth);
            float spawnAcisZ = CamHeight * 5;
            // float spawnAcisY = Random.Range(-20, 40);
            int numberOfNumberClouds = Random.Range(0, Clouds.Length);
            Vector3 spawnPos = new Vector3(spawnAcisX, -30, spawnAcisZ);
            Instantiate(Clouds[numberOfNumberClouds], spawnPos, Quaternion.identity);
        }
    }
    public void OnGUI()
    {
        if ((isPaused) || (_onEnablePauseButton))
        {
            Time.timeScale = 0;
            menuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            menuPanel.SetActive(false);
        }
    }
    public void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !(hasFocus);
    }
    public void OnEnablePauseButton()
    {
        if (_onEnablePauseButton)
            _onEnablePauseButton = false;
        else
            _onEnablePauseButton = true;
    }
    public void StartedNewGame()
    {
        Awake();
        menuPanel.SetActive(false);
        Time.timeScale = 1;
        OnEnablePauseButton();
        FlyPlane.StartedGame();
        CLearBoxEvent();
    }
    private void CLearBoxEvent()
    {
        _boxEvetNow = GameObject.FindGameObjectsWithTag("BoxOfEvent");
        for (int i = 0; i < _boxEvetNow.Length; ++i)
        {
            Destroy(_boxEvetNow[i]);
        }
    }
}