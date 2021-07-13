using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<bird> birds;//存放多只小鸟
    public List<pig> pigs;//存放多只猪
    public static GameManager _instance;


    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        Initialized();
    }

    /// <summary>
    /// 初始化小鸟
    /// </summary>
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)//第一只小鸟
            {
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }

    }

    /// <summary>
    /// 判定游戏逻辑
    /// </summary>
    public void NextBird()
    {
        if(pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                //下一只鸟飞
                Initialized();
            }
            else
            {
                //输了
            }
        }
        else
        {
            //赢了
        }
    }
}
