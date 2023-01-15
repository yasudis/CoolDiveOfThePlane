using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BoxOfEvent : MonoBehaviour
{
    public FlyPlane FlyPlane;

    protected IOilGetIt _oilGEtIt;
    protected IRemoteGetIt _remoteGetIt;
   
   public void SetOilGetIt(IOilGetIt oilGetIt)
    {
        _oilGEtIt = oilGetIt;
    }
    public void SetRemoteGetIt(IRemoteGetIt remoteGetIt)
    {
        _remoteGetIt = remoteGetIt;
    }
    protected void GetOilForPlaye()
    {
        _oilGEtIt.GetOilForPlayer();
    }
    protected void GetRemoteForPlayer()
    {
        _remoteGetIt.GetRemoteForPlayer();
    }
}
