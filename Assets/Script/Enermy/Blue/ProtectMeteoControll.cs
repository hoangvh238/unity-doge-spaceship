using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectMeteoControll : MonoBehaviour
{
    public GameObject protectPos;
    public Vector2 startPos;
    public Vector2 targetPos;
    public float duration = 10f;
    float rate = 0;
    float time = 0;
    private void Start()
    {

        startPos = transform.localPosition;
        float currentX = protectPos.transform.position.x;
        float currentY = protectPos.transform.position.y;
        if (currentY == 6f)
        {
            float x = Random.Range(-5, 5);
            float y = -6f;
            targetPos = new Vector2(x, y);
        }
        if (currentY == -6f)
        {
            float x = Random.Range(-5, 5);
            float y = 6f;
            targetPos = new Vector2(x, y);
        }
        if(currentX == -9.5f )
        {
            float x = 9.5f;
            float y = Random.Range(-5, 5);
            targetPos = new Vector2(x, y);
        }
        if (currentX == 9.5f)
        {
            float x = -9.5f;
            float y = Random.Range(-5, 5);
            targetPos = new Vector2(x, y);
        }
    }

    private void Update()
    {

        MoveObject(targetPos);
    }


    private void MoveObject(Vector3 targetPos)
    {
        rate = 1 / duration;
        time += rate * Time.deltaTime;
        transform.localPosition = Vector3.Lerp(startPos, targetPos, time);

    }

}
