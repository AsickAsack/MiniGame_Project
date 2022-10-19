using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : MonoBehaviour
{
    public float Speed;
    public float liveTime = 5.0f;
    public abstract void GetReward(Transform tr);

    public void Fire(Transform tr)
    {
        StartCoroutine(GoTarget((tr.position-this.transform.position).normalized));
    }

   IEnumerator GoTarget(Vector3 dir)
    {
        while(liveTime > 0.0f)
        {
            liveTime -= Time.deltaTime;

            this.transform.position += dir * Time.deltaTime * Speed;
            yield return null;
        }

        Destroy(this.gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GetReward(collision.transform);
            Destroy(this.gameObject);
        }
    }


}
