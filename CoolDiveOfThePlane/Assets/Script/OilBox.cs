using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBox : BoxOfEvent
{
    // Start is called before the first frame update
    void Start()
    {
        SetOilGetIt(new OilGetIt());
        GetOilForPlaye();
    }
}
