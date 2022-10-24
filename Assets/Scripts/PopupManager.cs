using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PopupManager : MonoBehaviour
{
    public GameObject NoTouchPopup;
    public Popup[] My_Popup;

    public void SetPopup(bool check, int index)
    {
        NoTouchPopup.SetActive(check);
        My_Popup[index].gameObject.SetActive(check);
    }

    public void SetPopup(bool check, int index, string message)
    {
        NoTouchPopup.SetActive(check);
        My_Popup[index].gameObject.SetActive(check);
        My_Popup[index].CreatePopup(message);
    }
    public void SetPopup(bool check,int index,string message,UnityAction action1,UnityAction action2)
    {
        NoTouchPopup.SetActive(check);
        My_Popup[index].gameObject.SetActive(check);
        My_Popup[index].CreatePopup(message,action1,action2);
    }
}
