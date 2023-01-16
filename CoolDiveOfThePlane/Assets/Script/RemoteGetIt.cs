using System.Collections.Generic;
using UnityEngine;

public class RemoteGetIt : IRemoteGetIt
{
    public Dictionary<string, float> GetRemoteForPlayer(Dictionary<string, float> dataOfRemote)
    {
        if (dataOfRemote.ContainsKey("remote"))
        {
            dataOfRemote["remote"] += Random.Range(1, 10);
        }
        return dataOfRemote;
    }
}
