using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBox : BoxOfEvent
{
    void Start()
    {
        SetOilGetIt(new OilGetIt());
        GetOilForPlayer();
    }
}