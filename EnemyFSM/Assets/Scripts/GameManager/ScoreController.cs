using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private string path = @"\Data\Score.txt";//数据存储位置
    public Text scoreText;//分数



    /// <summary>
    /// 游戏结束后 保存分数
    /// </summary>
    public void Save()
    {
        bool bol = false;
        if (scoreText.text != "")
        {
            if (SaveScore.instance.DicScore.Count != 0)
            {
                if (SaveScore.instance.DicScore.ContainsKey(SaveScore.userName))
                {
                    SaveScore.instance.DicScore[SaveScore.userName].fraction.Add(scoreText.text);
                    SaveScore.instance.DicScore[SaveScore.userName].time.Add(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                    //ClongPoP("添加分数成功");
                    bol = false;
                }
                else
                {
                    bol = true;
                }
            }
            else
            {
                userScore score = new userScore();
                score.fraction = new List<string>();
                score.fraction.Add(scoreText.text);
                DateTime timee = DateTime.Now.ToLocalTime();
                score.time = new List<string>();
                score.time.Add(timee.ToString("yyyy-MM-dd HH:mm:ss"));
                SaveScore.instance.DicScore.Add(SaveScore.userName, score);
                //ClongPoP("添加分数成功");
            }
            if (bol)
            {
                userScore score = new userScore();
                score.fraction = new List<string>();
                score.fraction.Add(scoreText.text);
                DateTime timee = DateTime.Now.ToLocalTime();
                score.time = new List<string>();
                score.time.Add(timee.ToString("yyyy-MM-dd HH:mm:ss"));
                SaveScore.instance.DicScore.Add(SaveScore.userName, score);
                //ClongPoP("添加分数成功");
            }
        }
    }

}
