using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MiniGame : MonoBehaviour
{
    public GameObject GamePopup;
    public TMPro.TMP_Text Score;
    public int GameIndex;
    
    [SerializeField]
    protected int NeedAtems;

    [SerializeField]
    protected int Limit_Time;
    protected bool GameState = false;
    public abstract void GameStart();
    public abstract void GameOver();

    //게임의 포인트와 시간 초기화
    protected void Game_initialize(int t)
    {
        GameManager.instance.Point = 0;
        GameManager.instance.Game_time = t;

    }

    protected bool CheckAtems()
    {
        if (GameManager.instance.Atem < NeedAtems)
        {
            GameManager.instance.popup.SetPopup(true,0,"No Atem");
            return false;
        }

        GameManager.instance.Atem -= NeedAtems;
        GameManager.instance.SetAtemTx();

        Game_initialize(Limit_Time);
        GamePopup.SetActive(true);
        GameState = true;

        return true;
    }

    
    public void SetPoint(int p)
    {
        GameManager.instance.Point += p;
        Score.text = "Score : " + GameManager.instance.Point;
    }
    
    public void SetPoint()
    {
        Score.text = "Score : " + GameManager.instance.Point;
    }
}
