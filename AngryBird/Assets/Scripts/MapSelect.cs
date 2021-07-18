using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{
    public int starsNum = 0;
    private bool isSelect = false;

    public GameObject locks;
    public GameObject stars;

    public GameObject panel;
    public GameObject map;

    public Text startText;
    public int startNum = 1;//开始的关卡数
    public int endNum = 3;//结束关卡数



    private void Start()
    {
        ///PlayerPrefs.DeleteAll();//清除游戏数据

        if (PlayerPrefs.GetInt("totalNum", 0) >= starsNum)
        {
            isSelect = true;
        }

        if (isSelect)
        {
            locks.SetActive(false);
            stars.SetActive(true);


            //TODo:text显示星星数量总数
            int counts = 0;
            for(int i = startNum;i <= endNum; i++)
            {
                counts += PlayerPrefs.GetInt("levle" + i.ToString(), 0);

            }
            startText.text = counts.ToString()+"/20";

        }
    }


    /// <summary>
    /// 鼠标点击
    /// </summary>
    public void Selected()
    {
        if (isSelect)
        {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }

   

    public void panelSelect()
    {
        panel.SetActive(false);
        map.SetActive(true);
    }
}
