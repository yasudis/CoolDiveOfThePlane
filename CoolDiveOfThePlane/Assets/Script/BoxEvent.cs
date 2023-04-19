using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BoxEvent : MonoBehaviour
{
    protected IOilGetIt _oilGEtIt;
    protected IRemoteGetIt _remoteGetIt;
    private Dictionary<string, float> _dataBox;
    private void Awake()
    {
        _dataBox = new Dictionary<string, float>
        {
            {"oil", 0},
            {"remote", 0},
            {"health", 0},
            {"workFactor", 0}
        };
    }
    private void Update()
    {
        this.transform.Translate(0, 0, -10f * Time.deltaTime);
        if (this.transform.position.z <= -Camera.main.orthographicSize)
        {
            DestroyBoxEvent();
        }
    }
    public void SetOilGetIt(IOilGetIt oilGetIt)
    {
        _oilGEtIt = oilGetIt;
    }
    public void SetRemoteGetIt(IRemoteGetIt remoteGetIt)
    {
        _remoteGetIt = remoteGetIt;
    }
    protected void GetOilPlayer()
    {
        _oilGEtIt.GetOilPlayer(_dataBox);
    }
    protected void GetRemotePlayer()
    {
        _remoteGetIt.GetRemotePlayer(_dataBox);
    }
    public Dictionary<string, float> GetDataBox()
    {
        return _dataBox;
    }
    private void DestroyBoxEvent()
    {
        Destroy(this.gameObject);
    }
}