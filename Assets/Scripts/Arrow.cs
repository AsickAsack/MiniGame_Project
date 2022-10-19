using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Items
{
    public override void GetReward(Transform tr)
    {
        if(tr.GetComponent<Player>().Shield.gameObject.activeSelf)
            tr.GetComponent<Player>().Shield.gameObject.SetActive(false);
        else
            tr.gameObject.SetActive(false);
    }
}
