using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Items
{
    public override void GetReward(Transform tr)
    {
        MainSystem.instance.setPoint(30);
    }

    
}
