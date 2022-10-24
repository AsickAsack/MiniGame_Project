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

    //���� ǥ���� �ؽ�Ʈ
    public TMPro.TMP_Text Atem_Tx;

    //�˸� ��� �˾�
    public PopupManager popup;

    //�̱��� 
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
