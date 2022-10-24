using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaGirlSystem : MiniGame
{

    public Player MetaGirl;
    public Transform MetaGirl_Canvas;

    private Coroutine RoutineCo;
    public GameObject[] item_Prefabs;
    private List<GameObject> items = new List<GameObject>();

    [SerializeField]
    float CreateTime = 0.5f;

    public override void GameStart()
    {
        if(CheckAtems())
        { 
            MetaGirl.SetMoveMent(true);
            SetPoint();

            if(RoutineCo == null)
            RoutineCo = StartCoroutine("GameRoutine");
            else
            {
                StopCoroutine(RoutineCo);
                RoutineCo = StartCoroutine("GameRoutine");
            }
        }
    }

    IEnumerator GameRoutine()
    {
        while(true)
        {
            CreateTime -= Time.deltaTime;
            if(CreateTime <= 0)
            {
                CreateTime = 0.5f;

                GameObject obj = Instantiate(Getitems(), GetItems_Pos(), Quaternion.identity, MetaGirl_Canvas);
                obj.GetComponent<Items>().Fire(MetaGirl.transform);

                items.Add(obj);
                
            }

            yield return null;
        }
    }

    public GameObject Getitems()
    {
        int rand = Random.Range(1, 11);

        if (rand <= 5) rand = 0;
        else if (rand > 5 && rand <= 9) rand = 1;
        else rand = 2;

        return item_Prefabs[rand];
        
    }

    public Vector2 GetItems_Pos()
    {
        return Camera.main.ViewportToScreenPoint(new Vector3(Random.Range(0, 2), Random.Range(0, 2), 0.0f));
    }

    public override void GameOver()
    {
        StopAllCoroutines();

        for(int i=0;i<items.Count;i++)
            Destroy(items[i]);

        items.Clear();
        GameState = false;

        GameManager.instance.popup.SetPopup(true, 1, "GameOver!\nGet Atem : " + GameManager.instance.Point / 10, ()=>GameStart(),()=> GamePopup.SetActive(false));
        GameManager.instance.Atem+=GameManager.instance.Point/10;
        GameManager.instance.SetAtemTx();
    }



}
