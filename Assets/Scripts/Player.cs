using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MoveSystem moveSystem;

    public float Speed;
    public Transform Shield;

    private RectTransform metaPos;
    private Vector2 PlayerPos;

    [SerializeField]
    private Vector2 LimitViewPort;

    Coroutine MoveCo;

    private void Awake()
    {
        metaPos = this.GetComponent<RectTransform>();
    }

    //플레이어 이동 코루틴 on/off
    public void SetMoveMent(bool check)
    {
        if (check)
        {
            if (MoveCo == null)
            MoveCo = StartCoroutine("Move");
            else
            {
                StopCoroutine(MoveCo);
                MoveCo = StartCoroutine("Move");
            }
            this.transform.localPosition = Vector2.zero;
        }
        else StopAllCoroutines();
    }

 


    IEnumerator Move()
    {
        while(true)
        {
            if (moveSystem.GetState())
            {
                PlayerPos = metaPos.anchoredPosition + moveSystem.GetDir() * Time.deltaTime * Speed;

                Vector3 pos = Camera.main.ScreenToViewportPoint(PlayerPos);
                pos.x = Mathf.Clamp(pos.x, -LimitViewPort.x, LimitViewPort.x);
                pos.y = Mathf.Clamp(pos.y, -LimitViewPort.y, LimitViewPort.y);

                metaPos.anchoredPosition = Camera.main.ViewportToScreenPoint(pos);
            }
            yield return null;
        }    

    }


}
