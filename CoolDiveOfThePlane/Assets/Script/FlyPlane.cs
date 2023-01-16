using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyPlane :MonoBehaviour
{
    [SerializeField] private float _massOfPlane;
    [SerializeField] private float _totalWeightOfOil;
    [SerializeField] private float _totalWeightOfRemote;
    [SerializeField] private float _totalWorkFactor;
    [SerializeField] private float _healthOfPlane;
    [SerializeField] private float _engineWorkFactor;
    [SerializeField] private GameObject Player;
    public Slider OilOfPlaer;

    private Dictionary<string, float> _dataOfPlayer;
    

    private void Awake()
    {
        _dataOfPlayer = new Dictionary<string, float>
        {
            {"oil", _totalWeightOfOil},
            {"remote", _totalWeightOfRemote},
            {"health", _healthOfPlane},
            {"workFactor", _totalWorkFactor}
        };
    }

    private void MoveOfPlane()
    {
        _engineWorkFactor = (_totalWeightOfOil + _totalWeightOfRemote) / _massOfPlane;
    }
    private void ControledWeightOfOil(float weightOfOil)
    {
        _totalWeightOfOil = _totalWeightOfOil + weightOfOil;
        MoveOfPlane();
    }
    private void ControledWeightOfRemote(float weightOfRemote)
    {
        _totalWeightOfRemote = _totalWeightOfRemote + weightOfRemote;
        MoveOfPlane();
    }
    private void ManageredMassOfPlane()
    {
       // _massOfPlane = _totalWeightOfOil + _totalWeightOfRemote;
    }
    private void ManageredOil()
    {
        _totalWeightOfOil = _totalWeightOfOil-_engineWorkFactor* _totalWorkFactor;
        OilOfPlaer.value = _totalWeightOfOil;

        if (_totalWeightOfOil <= 0)
        {
            Debug.Log("Oil is over");
        }
    }
    private void RemoteManadger()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {      
        GameObject collideWith = collision.gameObject;
        Debug.Log($"Colid{ collideWith.tag}");
        if (collideWith.tag == "BoxOfEvent")
        {
            BoxOfEvent boxOfEvent = collideWith.GetComponent<BoxOfEvent>();
            Dictionary<string, float> dataBox = boxOfEvent.GetDataBox();
            PutDataOnFlyPlane(dataBox);
            Debug.Log($"Player have oil is {_dataOfPlayer["oil"]}");
        }
    }
    private Dictionary<string, float> PutDataOnFlyPlane(Dictionary<string, float> dataBox)
    {
        foreach (var data in dataBox)
        {
            _dataOfPlayer[data.Key] += data.Value;
        }
        return _dataOfPlayer;
    }
    public void DoItOfPlane()
    {
        ManageredOil();
    }
    

}
