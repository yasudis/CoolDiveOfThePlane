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
    private void FixedUpdate()
    {
        this.transform.Translate(0, 0, -0.1f);
    }
}
