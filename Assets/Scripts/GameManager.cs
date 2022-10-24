using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MiniGame[] MiniGames;
    public int Atem = 0;
    public int Point = 0;
    public float Game_time = 0;

    //¾ÆÅÛ Ç¥½ÃÇÒ ÅØ½ºÆ®
    public TMPro.TMP_Text Atem_Tx;

    //¾Ë¸² ¶ç¿ï ÆË¾÷
    public PopupManager popup;

    //½Ì±ÛÅæ 
    private void Awake()
    {
        instance = this;
        SetAtemTx();
    }

    public void Click_Btn(int index)
    {
        MiniGames[index].GameStart();
    }

    public void SetAtemTx()
    {
        Atem_Tx.text = "Atems : " + Atem;
    }

}
