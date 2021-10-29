using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class userScore
{
    public List<string> fraction;//分数
    public List<string> time;//时间
}
public class SaveScore : MonoBehaviour
{
    public Dictionary<string, userScore> DicScore = new Dictionary<string, userScore>();//账户 分数
    private string pathscore = @"\Data\Score.txt";
    public static string userName;
    public static SaveScore instance;

    private void Awake()
    {
        instance = this;
    }

   
    public void ReadScoreTXT()
    {
        string[] Raw = System.IO.File.ReadAllLines(Application.streamingAssetsPath + pathscore);
        if (Raw.Length != 0)
        {
            for (int i = 0; i < Raw.Length; i++)
            {
                userScore usersc = new userScore();
                usersc.fraction = new List<string>();
                usersc.time = new List<string>();

                string[] txt = Raw[i].Split('*');
                string[] txt1 = Raw[i].Split('/');

                foreach (var item in txt1)
                {
                    if (item != "")
                    {
                        usersc.fraction.Add(item);
                    }
                }
                string[] txt2 = txt[2].Split('/');
                foreach (var item in txt2)
                {
                    if (item != null)
                    {
                        usersc.time.Add(item);
                    }
                }

                DicScore.Add(txt[0],usersc);
            }
        }

        string txt3 = "";
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + pathscore, false);
        sw.Write(txt3);
        sw.Flush();
        sw.Close();
 
    }

    /// <summary>
    /// 程序退出
    /// </summary>
    private void OnApplicationQuit()
    {
        SaveFile();
    }


    /// <summary>
    /// 保存文件
    /// </summary>
    public void SaveFile()
    {
        string text = "";
        string text4 = "";

        StreamWriter streamWriter = new StreamWriter(Application.streamingAssetsPath + pathscore, true);

        if (DicScore.Count != 0)
        {
            foreach (var item in DicScore)
            {
                string text1 = "";
                string text2 = "";

                text4 = item.Key;
                foreach (var ite in DicScore[item.Key].fraction)
                { text1 += ite + "/"; }
                foreach (var itew in DicScore[item.Key].time)
                { text2 += itew + "/";}

                text += text4 + "*" + text1 + "*" + text2 + "*" + "\r\n";
           
            }

            streamWriter.Write(text);
            streamWriter.Flush();
            streamWriter.Close();
            print("保存分数文件");
        }
    }
}
