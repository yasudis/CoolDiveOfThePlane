using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBox : BoxEvent
{
    void Start()
    {
        SetOilGetIt(new OilGetIt());
        GetOilPlayer();
    }
}