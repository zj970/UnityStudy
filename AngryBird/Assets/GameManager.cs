using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<bird> birds;//存放多只小鸟
    public List<pig> pigs;//存放多只猪
    public static GameManager _instance;//
    private Vector3 originPos;//初始化的位置

    public GameObject win;//赢的对象
    public GameObject lose;//输的对象

    public GameObject[] stars;//储存星级


    private void Awake()
    {
        _instance = this;
        if (birds.Count > 0)
        {
            originPos = birds[0].transform.position;
        }
        
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
                birds[i].transform.position = originPos;
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
                lose.SetActive(true);

            }
        }
        else
        {
            //赢了
            win.SetActive(true);
        }
    }
    

    /// <summary>
    /// 显示星星
    /// </summary>
    public void ShowStart()
    {
        StartCoroutine("show");
    }

    IEnumerator show()
    {
        for (int i = 0; i < birds.Count + 1; i++)
        {
            yield return new WaitForSeconds(0.2f);
            stars[i].SetActive(true);//第i个星星激活
        }
    }

}
