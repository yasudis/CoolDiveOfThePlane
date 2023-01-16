using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilGetIt : IOilGetIt
{
    public Dictionary<string, float> GetOilForPlayer(Dictionary<string, float> dataOfOil)
    {
        if (dataOfOil.ContainsKey("oil"))
        {
            dataOfOil["oil"] += Random.Range(1, 10);
            Debug.Log($"Oil Work its { dataOfOil["oil"]}");
        }
        return dataOfOil;   
    }
}

