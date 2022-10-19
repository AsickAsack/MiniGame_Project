using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSystem : MonoBehaviour
{
    public static MainSystem instance;

    int Artem;
    int GameTime;
    public Transform MetaGirl;
    public GameObject Arrow;
    public GameObject Truck;
    public GameObject blanket;
    float CreateTime = 0.5f;
    int point;
    public TMPro.TMP_Text poinTtx;

    private void Awake()
    {
        instance = this;
    }

    public void setPoint(int pt)
    {
        point += pt;
        poinTtx.text = "Score : " + point;

    }


    void CreateItem(int num)
    {
        GameObject temp = null;

        switch (num)
        {
            case 0:
                temp = Arrow;
                break;
            case 1:
                temp = Truck;
                break;
            case 2:
                temp = blanket;
                break;


        }

        GameObject obj = Instantiate(temp,
        Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 2), Random.Range(0, 2), 0.0f)), Quaternion.identity);
        obj.GetComponent<Items>().Fire(MetaGirl);

    }
    
    void Update()
    {
        
        CreateTime -= Time.deltaTime;
        if(CreateTime < 0)
        {
            int temp = Random.Range(0, 3);
            CreateItem(temp);
            CreateTime = 0.5f;
        }
    }
    
    
}
