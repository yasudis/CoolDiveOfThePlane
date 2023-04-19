using System.Collections.Generic;
using UnityEngine;

public class RemoteGetIt : IRemoteGetIt
{
    public Dictionary<string, float> GetRemotePlayer(Dictionary<string, float> dataRemote)
    {
        if (dataRemote.ContainsKey("remote"))
        {
            dataRemote["remote"] += Random.Range(1, 10);
        }
        return dataRemote;
    }
}
