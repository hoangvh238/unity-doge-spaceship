using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMeteo : MonoBehaviour
{
    public Object pointMeteo;
    Vector2 PlaceFlag;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 7f, 10f);
       
    }

    void Spawn()
    {
        switch(Random.Range(1,3))
        {
            case 1:
                float x = Random.Range(-5f, 5f);
                float y = -6f;
                PlaceFlag = new Vector2(x, y);
                Instantiate(pointMeteo, PlaceFlag, Quaternion.identity);        
                break;
            case 2:
                float t = Random.Range(-5f, 5f);
                float k = 6f;
                PlaceFlag = new Vector2(t, k);
                Instantiate(pointMeteo, PlaceFlag, Quaternion.identity);
                break;
        }
    }
   
    void Update()
    {
       

    }
    
}
