using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMeteoMoving : MonoBehaviour
{
    [Header("Draw Curve")]
    public AnimationCurve moveCurve;
    public GameObject pointPos;
    public Vector2 startPos;
    public Vector2 targetPos;
    private void Start()
    {

        startPos = transform.localPosition;
        float currentX = pointPos.transform.position.x;
        float currentY = pointPos.transform.position.y;
        if(currentY == 6f)
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
        StartCoroutine(MoveObject(targetPos, 10f));
    }

    private void Update()
    {
        
  
    }


    public IEnumerator MoveObject(Vector3 targetPos, float duration)
    {
        float time = 0;
        float rate = 1 / duration;
        while (time < 1)
        {
            time += rate * Time.deltaTime;
            transform.localPosition = Vector3.Lerp(startPos, targetPos, moveCurve.Evaluate(time));
            yield return 0;
        }
    }


}
