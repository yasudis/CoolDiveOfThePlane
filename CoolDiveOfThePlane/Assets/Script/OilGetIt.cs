using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilGetIt : IOilGetIt
{
    public Dictionary<string, float> GetOilPlayer(Dictionary<string, float> dataOil)
    {
        if (dataOil.ContainsKey("oil"))
        {
            dataOil["oil"] += Random.Range(1, 10);
        }
        return dataOil;
    }
}

