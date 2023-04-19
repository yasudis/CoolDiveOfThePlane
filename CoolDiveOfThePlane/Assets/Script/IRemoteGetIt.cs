using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRemoteGetIt
{
    public Dictionary<string, float> GetRemotePlayer(Dictionary<string, float> dataREmote)
    {
        return dataREmote;
    }
}
