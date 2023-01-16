using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BoxOfEvent : MonoBehaviour
{
    protected IOilGetIt _oilGEtIt;
    protected IRemoteGetIt _remoteGetIt;
    private Dictionary<string, float> _dataOfBox;
    private void Awake()
    {
        _dataOfBox = new Dictionary<string, float>
        {
            {"oil", 0},
            {"remote", 0},
            {"health", 0},
            {"workFactor", 0}
        };
    }
    public void SetOilGetIt(IOilGetIt oilGetIt)
    {
        _oilGEtIt = oilGetIt;
    }
    public void SetRemoteGetIt(IRemoteGetIt remoteGetIt)
    {
        _remoteGetIt = remoteGetIt;
    }
    protected void GetOilForPlayer()
    {
        _oilGEtIt.GetOilForPlayer(_dataOfBox);
    }
    protected void GetRemoteForPlayer()
    {
        _remoteGetIt.GetRemoteForPlayer();
    }
    public Dictionary<string, float> GetDataBox()
    {
        return _dataOfBox;
    }
}
