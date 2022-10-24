using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Items
{
    public int Point;

    public override void GetReward(Transform tr)
    {
        GameManager.instance.MiniGames[0].SetPoint(Point);
    }

}
