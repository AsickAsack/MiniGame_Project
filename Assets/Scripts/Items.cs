using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : MonoBehaviour
{
    public float Speed;
    public float RDRange; // ·£´ý ·¹ÀÎÁö
    public float liveTime = 5.0f;
    public abstract void GetReward(Transform tr);

    public void Fire(Transform tr)
    {
        
        StartCoroutine(GoTarget((Vector2)(tr.position-this.transform.position).normalized));
    }

   IEnumerator GoTarget(Vector2 dir)
    {
        while(liveTime > 0.0f)
        {
            liveTime -= Time.deltaTime;

            this.transform.Translate(dir * Time.deltaTime * Random.Range(Speed - RDRange, Speed + RDRange+1));
            yield return null;
        }

        this.gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GetReward(collision.transform.parent);
            this.gameObject.SetActive(false);
        }
    }


}
