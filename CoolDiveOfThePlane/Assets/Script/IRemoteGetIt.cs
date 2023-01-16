using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRemoteGetIt
{
    public Dictionary<string, float> GetRemoteForPlayer(Dictionary<string, float> dataOfREmote)
    {
        return dataOfREmote;
    }
}
