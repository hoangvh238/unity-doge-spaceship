using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


public class SpawnOrange : MonoBehaviour
{
    public Object OrangeMeteo;
    Vector2 PlaceFlag;
    private int countTime =0;
    private float boomTime = 0;
    private float lastBoomTime = 0;
    private GameObject Plane;
    private GameObject gameController;
    private int check = 0;
    public GameObject warring;
    // Start is called before the first frame update
    void Start()
    {
        updateTime();
        check = 0;
        Plane = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("UiControl");

    }

    // Update is called once per frame
    void Update()
    {
        if (check == 0 && Time.timeSinceLevelLoad > 16) spawnWarring();
        countTime= (int)Time.timeSinceLevelLoad;
        if((Time.timeSinceLevelLoad >= lastBoomTime + boomTime && countTime>5)&&Time.timeScale!=2f)
        {   
            if(Time.timeSinceLevelLoad <15 || Time.timeSinceLevelLoad > 20)
                Spawn();   
        }
    }
    void Spawn()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                float x = -9.6f;
                float y = Random.Range(-6,6);
                PlaceFlag = new Vector2(x, y);              
                break;
            case 2:
                float t = 9.6f;
                float k = Random.Range(-6,6);
                PlaceFlag = new Vector2(t, k);             
                break;
            case 3:
                float m = Random.Range(-9,9);
                float n = 5.6f;
                PlaceFlag = new Vector2(m, n);             
                break;
            case 4:
                float l = Random.Range(-9,9);
                float p = -5.6f;
                PlaceFlag = new Vector2(l, p);             
                break;
        }
        GameObject bom = Instantiate(OrangeMeteo, PlaceFlag, Quaternion.identity) as GameObject;
        bom.GetComponent<MeteoriteControll>().target = Plane.transform.position;
        gameController.GetComponent<UiController>().GetPoint(1);
        updateTime();
    }
    
    void updateTime()
    {
        float rangeMin = 2;
        float rangeMax = 3;
        if(Time.timeSinceLevelLoad>35)
        {
            rangeMax = 2;
            rangeMin = 1;
        }
        if(Time.timeSinceLevelLoad>50)
        {
            rangeMax = 2;
            rangeMin = 1;
        }
        if (Time.timeSinceLevelLoad > 55)
        {
            rangeMax = 1;
            rangeMin = 0;
        }
            lastBoomTime = Time.timeSinceLevelLoad;
        boomTime = Random.Range(rangeMin,rangeMax);
    
    }

    void spawnWarring()
    {
        check++;
        PlaceFlag = new Vector2(0,0);
        GameObject warringChildren = Instantiate(warring, PlaceFlag, Quaternion.identity) as GameObject;
        Destroy(warringChildren, 2.5f);
    }
}
