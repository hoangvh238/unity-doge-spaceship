using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;


public class UiController : MonoBehaviour
{
    public GameObject blurScreen;
    public GameObject boomEffect;
    public GameObject pnlEndGame;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    public TMP_Text txtPoint;
    public TMP_Text txtEnd;  
    private int gamePoint =0;
    public TMP_Text timeLevel;
    // Use this for initialization
    void Start()
    {
        blurScreen.SetActive(true);
        Time.timeScale = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad>5) blurScreen.SetActive(false);
        timeLevel.text = "Time: " +(int) Time.timeSinceLevelLoad;
    }

    public void GetPoint(int x)
    {
        gamePoint+=x;
        txtPoint.text = "SCORE: " + gamePoint.ToString();
    }

    public void ButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }
    public void ButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }
    public void ButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;

    }

    public void StartGame()
    {
       
        Application.LoadLevel("MainGame");
        
       
    }

    public void EndGame(int checkTime)
    {
            Time.timeScale = 2f;
            Destroy(txtPoint);
            txtEnd.text = "SCORE: " + gamePoint.ToString();
            pnlEndGame.SetActive(true);
    }
    public void UpdateTime()
    {
        
    }
   
}
