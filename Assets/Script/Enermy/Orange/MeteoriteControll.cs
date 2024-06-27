using UnityEngine;
using System.Collections;

public class MeteoriteControll : MonoBehaviour
{
    [Header("Draw Curve")]
    public AnimationCurve moveCurveEasy;
    public AnimationCurve moveCurveHard;
    public Vector3 target;
    public GameObject explore;
    private Animator anim;
    private float s = 0.005f;
    private int level=2;
    private float durationLevel;
    public AudioSource audSource;
    public AudioClip destroyOrange;
    public GameObject connectSound;
    public int mateoCate;
    void Start()
    {


        durationLevel = 1.5f;
        level = 2;
        anim = gameObject.GetComponent<Animator>();
        connectSound = GameObject.FindGameObjectWithTag("Player");
        anim.SetBool("isWarring", false);

        if (Time.timeSinceLevelLoad < 20)
        {
            level = 2;
        }
        if(Time.timeSinceLevelLoad < 30 && Time.timeSinceLevelLoad>20)
        {
            level = 3;
            durationLevel = 0.80f;
        }
        if(Time.timeSinceLevelLoad < 45 && Time.timeSinceLevelLoad > 30)
        {
            level = 3;
            durationLevel = 0.75f;
        }
        if(Time.timeSinceLevelLoad>45)
        {
            level = 3;
            durationLevel = 0.65f;
        }
        if (Time.timeSinceLevelLoad  <50&& Time.timeSinceLevelLoad > 45)
        {
            level = 3;
            durationLevel = 0.65f;
        }
        if (Time.timeSinceLevelLoad > 50)
        {
            level = 3;
            durationLevel = 0.6f;
        }
        switch (Random.Range(1, level))
        {
            case 1:
                StartCoroutine(MoveObjectEasy(target, durationLevel));
                Destroy(gameObject,durationLevel);
                mateoCate = 1;
                break;
            case 2:
                anim.SetBool("isWarring", true);
                StartCoroutine(MoveObjectHard(target, durationLevel));
                Destroy(gameObject,durationLevel);
                connectSound.GetComponent<SpaceshipControll>().isWarring();
                mateoCate = 2;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetBool("isWarring") == true) 
        transform.localScale = (Vector2)transform.localScale + Vector2.one * s;
    }
    void OnDestroy()
    {
        GameObject exp = Instantiate(explore, transform.position, Quaternion.identity);
        Destroy(exp, 0.5f);
        if (Time.timeScale == 2f) Destroy(exp);
        if (mateoCate == 1)
        connectSound.GetComponent<SpaceshipControll>().destroyOrange();
        else
            connectSound.GetComponent<SpaceshipControll>().isSuperBoom();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Destroy(gameObject);

        }
    }
    public IEnumerator MoveObjectEasy(Vector3 targetPos, float duration)
    {
        float time = 0;
        float rate = 1 / duration;
        Vector3 startPos = transform.localPosition;
        while (time < 1)
        {
            time += rate * Time.deltaTime;
            transform.localPosition = Vector3.Lerp(startPos, targetPos, moveCurveEasy.Evaluate(time));
            yield return 0;
        }
    }
    public IEnumerator MoveObjectHard(Vector3 targetPos, float duration)
    {
        float time = 0;
        float rate = 1 / duration;
        Vector3 startPos = transform.localPosition;
        while (time < 1)
        {
            time += rate * Time.deltaTime;
            transform.localPosition = Vector3.Lerp(startPos, targetPos, moveCurveHard.Evaluate(time));
            yield return 0;
        }
    }
   
}
