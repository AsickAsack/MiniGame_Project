using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class woowang_System : MiniGame
{


    public WWJW_OBJ[] W_Objects;
    public WWJW_OBJ[] Answers;
    public WWJW_OBJ[] TempPics;
    public Slider TimeSlider;
    public TMPro.TMP_Text Time_text;
    public Sprite[] CharacterImage;


    protected override void Game_initialize(float t)
    {
        GameManager.instance.Point = 0;
        GameManager.instance.Game_time = t;

    }


    IEnumerator GameRoutine()
    {
        while (GameManager.instance.Game_time >= 0.0f)
        {
            GameManager.instance.Game_time -= Time.deltaTime;
            TimeSlider.value = GameManager.instance.Game_time / Limit_Time;
            Time_text.text = GameManager.instance.Game_time.ToString("F2");

            yield return null;
        }

        //시간 다지나면 게임 오버
        GameOver();
    }


    public override void GameOver()
    {
     
    }

    public override void GameStart()
    {
        if (CheckAtems())
        {
            SetPoint();
            StartGameRoutine();

        }

    }


}
