using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyPlane : MonoBehaviour
{
    [SerializeField] private float _massOfPlane;
    [SerializeField] private float _massOfPlaneMax;
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
        _engineWorkFactor = (_dataOfPlayer["oil"] + _dataOfPlayer["workFactor"]) / _massOfPlane;
    }
    private void ControledWeightOfOil(float weightOfOil)
    {
        _dataOfPlayer["oil"] = _dataOfPlayer["oil"] + weightOfOil;
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
        _dataOfPlayer["oil"] = _dataOfPlayer["oil"] - _engineWorkFactor* _dataOfPlayer["workFactor"];
        OilOfPlaer.value = _dataOfPlayer["oil"];

        if (_dataOfPlayer["oil"] <= 0)
        {
            Debug.Log("Oil is over");
        }
    }
    private void RemoteManadger()
    {

    }
    public Dictionary<string, float> PutDataOnFlyPlane(Dictionary<string, float> dataBox)
    {
        if (EnableToPutDataOnFLyPlay())
            {
            foreach (var data in dataBox)
            {
                _dataOfPlayer[data.Key] += data.Value;
            }
        }
        return _dataOfPlayer;
    }
    private bool EnableToPutDataOnFLyPlay()
    {
        if (_dataOfPlayer["oil"]+_dataOfPlayer["remote"]< _massOfPlaneMax)
            return true;
        else return false;
        
    }
    public void DoItOfPlane()
    {
        ManageredOil();
        Debug.Log($" oil {_dataOfPlayer["oil"]}, remote {_dataOfPlayer["remote"]}");
    }


}
