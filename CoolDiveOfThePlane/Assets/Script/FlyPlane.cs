using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlane : MonoBehaviour
{
    [SerializeField]
    private float _massOfPlane;

    [SerializeField]
    private float _totalWeightOfOil;
    
    [SerializeField]
    private float _totalWeightOfRemote;

    [SerializeField]
    private float _totalWorkFactor;

    [SerializeField]
    private float _healthOfPlane;

    public float EngineWorkFactor;

    public void MoveOfPlane()
    {
        EngineWorkFactor = (_totalWeightOfOil + _totalWeightOfRemote) / _massOfPlane;
    }
    public void WeightOfOil(float weightOfOil)
    {
        _totalWeightOfOil = _totalWeightOfOil + weightOfOil;
    }
    public void WeightOfRemote(float weightOfRemote)
    {
        _totalWeightOfRemote = _totalWeightOfRemote + weightOfRemote;
    }
    public void MassOfPlane()
    {
       // _massOfPlane = _totalWeightOfOil + _totalWeightOfRemote;
    }

    public void OilManadger()
    {
        _totalWeightOfOil = _totalWeightOfOil-EngineWorkFactor* _totalWorkFactor;
    }
    
    public void RemoteManadger()
    {
        
    }

}
