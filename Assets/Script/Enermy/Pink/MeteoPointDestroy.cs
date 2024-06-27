using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoPointDestroy : MonoBehaviour
{
    public GameObject pinkMeteo;
    private float placeY;
    Vector2 FlagSpawn;
    // Use this for initialization
    void Start()
    {
      placeY = pinkMeteo.transform.position.y;
        
    }
  
    // Update is called once per frame
    void Update()
    {
       if(placeY==6f)
        {
            if (pinkMeteo.transform.localPosition.y < -5.5f)
            {
                Destroy(pinkMeteo);
            }
        }
        if (placeY == -6f)
        {
            if (pinkMeteo.transform.localPosition.y > 5.5f)
            {

                Destroy(pinkMeteo);
            }
        }
    }
   
}
