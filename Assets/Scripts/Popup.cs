using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Popup : MonoBehaviour
{
    public TMPro.TMP_Text Detail;
    public Button[] buttons;


    public void CreatePopup(string text)
    {
        Detail.text = text;
    }

    public void CreatePopup(string text, UnityAction action1, UnityAction action2)
    {
        Detail.text = text;
        SetBtnAction(0, action1);
        SetBtnAction(1, action2);
    }

    public void SetBtnAction(int index,UnityAction action1)
    {
        buttons[index].onClick.RemoveAllListeners();
        buttons[index].onClick.AddListener(action1);
    }
}
