using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ireward
{
    void GetReward(); 
}


public abstract class Items : MonoBehaviour, ireward
{
    public float Speed;
    public float liveTime = 5.0f;
    public abstract void GetReward();

    public void Fire(Transform tr)
    {
        StartCoroutine(GoTarget(tr));
    }

   IEnumerator GoTarget(Transform tr)
    {
        while(liveTime >= 5.0f)
        {
            liveTime -= Time.deltaTime;

            this.transform.position += (tr.position-transform.position).normalized * Time.deltaTime * Speed;
            yield return null;
        }

        Destroy(this.gameObject);
        
    }

   
}
