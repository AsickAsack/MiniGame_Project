using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour
{
    int Artem;
    int GameTime;
    public GameObject Arrow;
    public GameObject Truck;
    public GameObject blanket;
    float CreateTime = 3.0f;

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


            GameObject obj = Instantiate(temp,
            Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 2), Random.Range(0, 2), 0.0f)), Quaternion.identity);
        }   
    
        
    }
    
    void Update()
    {
        
        CreateTime -= Time.deltaTime;
        if(CreateTime < 0)
        {
            int temp = Random.Range(0, 3);
            CreateItem(temp);
            CreateTime = 3.0f;
        }
    }
    
    
}
