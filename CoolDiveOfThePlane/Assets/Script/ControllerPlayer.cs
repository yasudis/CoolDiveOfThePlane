using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public Rigidbody rb;
    private float angle;
    public GameObject player;
    public GameObject playerFlyer;
    private float _rollMult = -45;
    private float _pitchMult = -30;

    private FlyPlane _flyPlane;

    private void Start()
    {
        _flyPlane = FindObjectOfType<FlyPlane>();
    }
    public void ControledJostikPlayer(float xAxis, float zAxis)
    {
        // Извлечь информацию из класса Input      
        angle = angle + xAxis * 5;
        if (xAxis != 0)
        {
            player.transform.Translate(xAxis * 1, 0, 0);
            // Повернуть корабль, чтобы придать ощущение динамизма // с
            playerFlyer.transform.rotation = Quaternion.Euler(zAxis * _pitchMult, 0, xAxis * _rollMult);
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
    public void ControledPositionPlaer(float camWidth, float camHeight, float radius)

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
    public void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;
        if (collideWith.tag == "BoxOfEvent")
        {
            BoxEvent boxEvent = collideWith.GetComponent<BoxEvent>();
            Dictionary<string, float> dataBox = boxEvent.GetDataBox();
            _flyPlane.PutDataOnFlyPlane(dataBox);
            Destroy(collideWith);
        }
    }
}