using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blanket : Items
{
    public override void GetReward(Transform tr)
    {
        tr.GetComponent<Player>().Shield.gameObject.SetActive(true);
    }
}
