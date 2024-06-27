using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class SpaceshipControll : MonoBehaviour {
    Vector3 mousePos;
    public float moveSpeed = 5;
    public float minX = -5.5f;
    public float maxX = 5.5f;
    public float minY = -3;
    public float maxY = 3;
    public GameObject gameController;
    public GameObject PinkEarn;
    private Animator anim;
    private int heal=0;
    public GameObject shield1;
    public GameObject shield2;
    public GameObject shield3;
    public AudioSource audSource;
    public AudioClip pink;
    public AudioClip blue;
    public AudioClip orange;
    public AudioClip warring;
    public AudioClip superBoom;
    // Use this for initialization
    void Start () {
        mousePos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("UiControl");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isEarn", false);

    }
	// Update is called once per frame
	void Update () {
        if (heal >= 1) shield1.SetActive(true);
        else
        {
            shield1.SetActive(false);
            anim.SetBool("isProtect", false);
        }
        if (heal >= 2) shield2.SetActive(true);
        else shield2.SetActive(false);
        if (heal >= 3) shield3.SetActive(true);
        
        else shield3.SetActive(false);
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX), Mathf.Clamp(mousePos.y, minY, maxY), 0);
        }
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
       
      
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "OrangeMeteo")
        {
            heal--;
            Destroy(hitInfo.gameObject);
            if(heal<0)
            gameController.GetComponent<UiController>().EndGame(0);
        }
        if (hitInfo.tag == "PinkMeteo")
        {
            anim.SetBool("isEarn", true);
            Destroy(hitInfo.gameObject);
            gameController.GetComponent<UiController>().GetPoint(5);
            Invoke("turnOffAnmPink", 1f);
            if(audSource&&pink)
            {
                audSource.PlayOneShot(pink);
            }
        }
        if(hitInfo.tag =="BlueMeteo")
        {
            heal++;
            anim.SetBool("isProtect", true);
            Destroy(hitInfo.gameObject);
            if (audSource && blue)
            {
                audSource.PlayOneShot(blue);
            }
        }
    }
    void turnOffAnmPink()
    {
        anim.SetBool("isEarn", false);
    }
    public void destroyOrange()
    {
        if (audSource && orange)
        {
            audSource.PlayOneShot(orange);
        }
    }
    public void isWarring()
    {
        if (audSource && warring)
        {
            audSource.PlayOneShot(warring);
        }
    }
    public void isSuperBoom()
    {
        if (audSource && superBoom)
        {
            audSource.PlayOneShot(superBoom);
        }
    }
}
