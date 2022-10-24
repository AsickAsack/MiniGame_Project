using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveSystem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Transform JoySticBase;
    public Transform JoyStic;

    public float Speed = 5.0f;
    private float JoysticSize;

    private Vector2 StartPos;
    private Vector2 CurPos;
    private Vector2 TempPos;

    bool IsClick = false;

   void Awake()
    {
        JoysticSize = JoySticBase.GetComponent<RectTransform>().sizeDelta.x * 0.25f;

        
    }

    
    //드래그 중일때
    public void OnDrag(PointerEventData eventData)
    {
        CurPos = eventData.position;
        TempPos = eventData.position;
        TempPos.x = Mathf.Clamp(TempPos.x,StartPos.x- JoysticSize, StartPos.x+ JoysticSize);
        TempPos.y = Mathf.Clamp(TempPos.y, StartPos.y - JoysticSize, StartPos.y + JoysticSize);
        JoyStic.position = Vector3.Lerp(JoyStic.position, TempPos, Time.deltaTime*20.0f);
    }

    //터치 했을때
    public void OnPointerDown(PointerEventData eventData)
    {
        ChangeState(true);
        StartPos = JoySticBase.position = eventData.position;
    }

    //터치 뗐을때
    public void OnPointerUp(PointerEventData eventData) => ChangeState(false);

    //조이스틱 on/off, 클릭 상태 변경
    public void ChangeState(bool check)
    {
        IsClick = check;
        JoySticBase.gameObject.SetActive(check);
    }

    public bool GetState()
    {
        return IsClick;
    }

    public Vector2 GetDir()
    {
        return (CurPos - StartPos).normalized;
    }




}
