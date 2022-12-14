using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Items
{
    public override void GetReward(Transform tr)
    {
        if (tr.GetComponent<Player>().Shield.gameObject.activeSelf)
            tr.GetComponent<Player>().Shield.gameObject.SetActive(false);
        else
        { 
            GameManager.instance.MiniGames[0].GameOver();
            tr.GetComponent<Player>().moveSystem.ChangeState(false);
            tr.GetComponent<Player>().StopAllCoroutines();
        }
    }

}
