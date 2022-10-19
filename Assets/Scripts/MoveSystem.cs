using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveSystem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject MetaGirl;
    public Transform JoySticBase;
    public Transform JoyStic;
    public float Speed = 5.0f;
    private float JoysticSize;
    private Vector3 StartPos;
    private Vector3 CurPos;
    private Vector2 TempPos;
    bool IsClick = false;

   void Awake()
    {
        JoysticSize = JoySticBase.GetComponent<RectTransform>().sizeDelta.x * 0.25f;
    }

    void Update()
    {
        if (IsClick)
        {
            MetaGirl.transform.position += (CurPos - StartPos).normalized * Time.deltaTime * Speed;
        }
    }

    //�巡�� ���϶�
    public void OnDrag(PointerEventData eventData)
    {
        CurPos = eventData.position;
        TempPos = eventData.position;
        TempPos.x = Mathf.Clamp(TempPos.x,StartPos.x- JoysticSize, StartPos.x+ JoysticSize);
        TempPos.y = Mathf.Clamp(TempPos.y, StartPos.y - JoysticSize, StartPos.y + JoysticSize);
        JoyStic.position = Vector3.Lerp(JoyStic.position, TempPos, Time.deltaTime*20.0f);
    }

    //��ġ ������
    public void OnPointerDown(PointerEventData eventData)
    {
        ChangeState();
        StartPos = JoySticBase.position = eventData.position;
    }

    //��ġ ������
    public void OnPointerUp(PointerEventData eventData) => ChangeState();

    //���̽�ƽ on/off, Ŭ�� ���� ����
    public void ChangeState()
    {
        IsClick = !IsClick;
        JoySticBase.gameObject.SetActive(IsClick);
    }



}
