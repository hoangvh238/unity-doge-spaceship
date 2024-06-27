using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPlay : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("MainGame");
    }
}
