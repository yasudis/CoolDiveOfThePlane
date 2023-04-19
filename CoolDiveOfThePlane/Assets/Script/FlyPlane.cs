using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyPlane : MonoBehaviour
{
    [SerializeField] private float _massPlane;
    [SerializeField] private float _massPlaneMax;
    [SerializeField] private float _totalWeightOil;
    [SerializeField] private float _totalWeightRemote;
    [SerializeField] private float _totalWorkFactor;
    [SerializeField] private float _healthPlane;
    [SerializeField] private float _engineWorkFactor;
    [SerializeField] private GameObject Player;
    public Slider OilPlaer;
    public Slider RemotePlayer;
    public Slider HealthPlayer;

    private Dictionary<string, float> _dataPlayer;

    private void Awake()
    {
        _dataPlayer = null;
        _dataPlayer = new Dictionary<string, float>
        {
            {"oil", _totalWeightOil},
            {"remote", _totalWeightRemote},
            {"health", _healthPlane},
            {"workFactor", _totalWorkFactor}
        };
    }
    private void MovePlane()
    {
        _engineWorkFactor = (_dataPlayer["oil"] + _dataPlayer["workFactor"]) / _massPlane;
    }
    private void ManageredtOil()
    {
        _dataPlayer["oil"] = _dataPlayer["oil"] - _engineWorkFactor * _dataPlayer["workFactor"];
        MovePlane();
        ShowStatusdOil();
    }
    private void ManageredRemote()
    {
        if (_dataPlayer["remote"] > (_healthPlane - _dataPlayer["health"]))
        {
            _dataPlayer["remote"] -= (_healthPlane - _dataPlayer["health"]);
            _dataPlayer["health"] += (_healthPlane - _dataPlayer["health"]);
        }
        else
        {
            _dataPlayer["health"] += _dataPlayer["remote"];
            _dataPlayer["remote"] -= _dataPlayer["remote"];
        }
        MovePlane();
        ShowStatusRemote();
    }    private void ManageredHealth()
    {
        _dataPlayer["health"] = _dataPlayer["health"] - (_engineWorkFactor * _dataPlayer["workFactor"]);
        ShowStatusHealth();
    }
    private void ShowStatusdOil()
    {
        OilPlaer.value = _dataPlayer["oil"];
        if (_dataPlayer["oil"] <= 0)
        {
            Debug.Log("Oil is over");
        }
    }
    private void ShowStatusRemote()
    {
        RemotePlayer.value = _dataPlayer["remote"];
    }
    private void ShowStatusHealth()
    {
        HealthPlayer.value = _dataPlayer["health"];
    }
    public Dictionary<string, float> PutDataOnFlyPlane(Dictionary<string, float> dataBox)
    {
        if (EnablePutDataFLyPlay())
        {
            foreach (var data in dataBox)
            {
                _dataPlayer[data.Key] += data.Value;
            }
        }
        return _dataPlayer;
    }
    private bool EnablePutDataFLyPlay()
    {
        if (_dataPlayer["oil"] + _dataPlayer["remote"] < _massPlaneMax)
            return true;
        else return false;
    }
    public void DoItPlane()
    {
        ManageredtOil();
        ManageredRemote();
        ManageredHealth();
        Debug.Log($" oil {_dataPlayer["oil"]}, remote {_dataPlayer["remote"]}, health {_dataPlayer["health"]}");
    }
    public void StartedGame() => Awake();
}