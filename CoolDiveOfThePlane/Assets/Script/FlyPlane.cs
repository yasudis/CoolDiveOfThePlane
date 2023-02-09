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
    public Slider RemoteOfPlayer;
    public Slider HealthOfPlayer;

    private Dictionary<string, float> _dataOfPlayer;
    

    private void Awake()
    {
        _dataOfPlayer = null;
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
    private void ManageredtOfOil()
    {
        _dataOfPlayer["oil"] = _dataOfPlayer["oil"] - _engineWorkFactor * _dataOfPlayer["workFactor"];
        MoveOfPlane();
        ShowStatusdOil();
    }
    private void ManageredOfRemote()
    {
        if (_dataOfPlayer["remote"]> (_healthOfPlane - _dataOfPlayer["health"]))
        {
            _dataOfPlayer["remote"] -= (_healthOfPlane - _dataOfPlayer["health"]);
            _dataOfPlayer["health"] += (_healthOfPlane - _dataOfPlayer["health"]);            
        }
        else
        {
            _dataOfPlayer["health"] += _dataOfPlayer["remote"];
            _dataOfPlayer["remote"] -= _dataOfPlayer["remote"];
        }
        MoveOfPlane();
        ShowStatusRemote();
    }
    private void ManageredOfHealth()
    {
        _dataOfPlayer["health"] = _dataOfPlayer["health"] - (_engineWorkFactor * _dataOfPlayer["workFactor"]);
        ShowStatusHealth();
    }
    private void ShowStatusdOil()
    {     
        OilOfPlaer.value = _dataOfPlayer["oil"];
        if (_dataOfPlayer["oil"] <= 0)
        {
            Debug.Log("Oil is over");
        }
    }
    private void ShowStatusRemote()
    {
        RemoteOfPlayer.value = _dataOfPlayer["remote"];
    }
    private void ShowStatusHealth()
    {
        HealthOfPlayer.value = _dataOfPlayer["health"];
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
        ManageredtOfOil();
        ManageredOfRemote();
        ManageredOfHealth();
        Debug.Log($" oil {_dataOfPlayer["oil"]}, remote {_dataOfPlayer["remote"]}, health {_dataOfPlayer["health"]}");
    }
    public void StartedGame() => Awake();
}
