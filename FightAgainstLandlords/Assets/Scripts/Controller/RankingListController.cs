using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingListController : MonoBehaviour
{
    //开关
    private bool isRank = false;


    public GameObject Ranking;
    public Text No1Name;
    public Text No1Intergral;
    public Text No2Name;
    public Text No2Intergral;
    public Text No3Name;
    public Text No3Intergral;


    //Json解析

    public void btn_Rank()
    {


        if (!isRank)
        {
            Ranking.SetActive(true);
            No1Name.text = Login.Ranking[0];
            No1Intergral.text = Login.Ranking[1];
            No2Name.text = Login.Ranking[2];
            No2Intergral.text = Login.Ranking[3];
            No3Name.text = Login.Ranking[4];
            No3Intergral.text = Login.Ranking[5];
        }
        else
        {
            //this.transform.position = pokerPos;//重置位置
            Ranking.SetActive(false);
        }
        isRank = !isRank;
    }

    //
    public void btn_show()
    {
        JsonScript.SortData();
        if (!isRank)
        {
            Ranking.SetActive(true);
            No1Name.text = JsonScript.reslut[0];
            No1Intergral.text = JsonScript.reslutint[0].ToString();
            No2Name.text = JsonScript.reslut[1];
            No2Intergral.text = JsonScript.reslutint[1].ToString();
            No3Name.text = JsonScript.reslut[2];
            No3Intergral.text = JsonScript.reslutint[2].ToString();
        }
        else
        {
            //this.transform.position = pokerPos;//重置位置
            Ranking.SetActive(false);
        }
            isRank = !isRank;       
    }
}
