using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBox : BoxOfEvent
{
    
    void Start()
    {
        SetRemoteGetIt(new RemoteGetIt());
        GetRemoteForPlayer();
    }
}
