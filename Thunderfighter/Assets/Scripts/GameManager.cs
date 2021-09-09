using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float scoreSum = 0f;
    public Text souceText;
    public GameObject bg;
    public GameObject quit;
    public GameObject start;

    public static GameManager _instanceGameManager;


    private void Start()
    {
        _instanceGameManager = this;
    }


    /// <summary>
    /// 游戏开始
    /// </summary>
    public void gameStart()
    {
        if(bg != null && quit != null && start != null)
        {
            bg.SetActive(true);
            quit.SetActive(false);
            start.SetActive(false);
        }
    }

    /// <summary>
    /// 游戏退出
    /// </summary>
    public void gameQuit()
    {

    }

    /// <summary>
    /// 暂停游戏
    /// </summary>
    public void gamePause()
    {

    }
}
