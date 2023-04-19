using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBox : BoxEvent
{
    void Start()
    {
        SetRemoteGetIt(new RemoteGetIt());
        GetRemotePlayer();
    }
}