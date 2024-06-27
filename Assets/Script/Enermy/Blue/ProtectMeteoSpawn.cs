using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectMeteoSpawn : MonoBehaviour
{
    public Object protectedMeteo;
    Vector2 PlaceFlag;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 10f, 15f);

    }

    void Spawn()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                float x = Random.Range(-5f, 5f);
                float y = -6f;
                PlaceFlag = new Vector2(x, y);
                Instantiate(protectedMeteo, PlaceFlag, Quaternion.identity);
                break;
            case 2:
                float t = Random.Range(-5f, 5f);
                float k = 6f;
                PlaceFlag = new Vector2(t, k);
                Instantiate(protectedMeteo, PlaceFlag, Quaternion.identity);
                break;
            case 3:
                float m = -9.5f;
                float n = Random.Range(-5f, 5f);
                PlaceFlag = new Vector2(m, n);
                Instantiate(protectedMeteo, PlaceFlag, Quaternion.identity);
                break;
            case 4:
                float l = 9.5f;
                float p = Random.Range(-5f, 5f);
                PlaceFlag = new Vector2(l, p);
                Instantiate(protectedMeteo, PlaceFlag, Quaternion.identity);
                break;
        }
    }

    void Update()
    {
        
    }
}
