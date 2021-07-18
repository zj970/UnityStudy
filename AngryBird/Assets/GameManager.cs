using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;//存放多只小鸟
    public List<Pig> pigs;//存放多只猪
    public static GameManager _instance;//
    private Vector3 originPos;//初始化的位置

    public GameObject win;//赢的对象
    public GameObject lose;//输的对象

    public GameObject pausepanel;

    public GameObject[] stars;//一个关卡的储存星级

    private int starNum = 0;//储存总星星个数

    private int totalnum = 10;//设置总关卡数

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
                birds[i].canMove = true;
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
                pausepanel.SetActive(false);
                

            }
        }
        else
        {
            //赢了
            win.SetActive(true);
            pausepanel.SetActive(false);
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
        int i;
        for ( ; starNum < birds.Count + 1; starNum++)
        {
            if (starNum >= stars.Length)
            {
                break;
            }
            yield return new WaitForSeconds(0.2f);
            stars[starNum].SetActive(true);//第i个星星激活
        }
        //starNum += i;
    }


    public void Replay()
    {
        SaveData();
        SceneManager.LoadScene(2);
        //print("点击了retry");
    }

    public void Home()
    {
        SaveData();
        //print("点击了Home");
        SceneManager.LoadScene(1);
        
    }
    /// <summary>
    /// 存储星星总数的方法
    /// </summary>
   public void SaveData()
    {
        if(starNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowLevel")))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), starNum);
        }
        //PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), starNum);

        //存储所有星星个数
        int sum = 0;
        for (int i = 1; i <= totalnum; i++)
        {
            sum += PlayerPrefs.GetInt("level"+i.ToString());
        }
      
        PlayerPrefs.SetInt("totalNum",sum);
        print(PlayerPrefs.GetInt("totalNum"));
    }
}
