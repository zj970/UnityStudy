using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] starObjects;
    public int maxRow = 10;//行
    public int maxColemn = 12;//列
    public GameObject starGroup;//所有星星的父物体
    /// <summary>
    /// 所有星星的集合
    /// </summary>
    public List<Star> starList;
    /// <summary>
    /// 满足条件的星星集合
    /// </summary>
    public List<Star> ClickedStarList;

    public static GameManager gameManager_Instance;

    //分数
    public Text currentScoreText;
    public float currentScore = 0f;

    public Text currentTotalScoreText;
    public float currentTotalScore = 0f;

    public Text targetScoreText;
    public float targetScore = 0f;

    public Text HurdleText;
    public int HurdleIndex = 1;//关卡

    public int judgeSwitch = 0;

    private void Start()
    {
        gameManager_Instance = this;

        GameStart(1);
    }

    /// <summary>
    /// 开始游戏
    /// </summary>
    void GameStart(int hurdle)
    {
        HurdleIndex = hurdle;
        currentTotalScore = 0;
        currentScore = 0;

        SetHurdleTargetScore(HurdleIndex);
        CreatStarList();

    }

    void CreatStarList()
    {
        //生成row*column个星星
        for (int r = 0; r < maxRow; r++)
        {
            for (int c = 0; c < maxColemn; c++)
            {
                //实例化星星
                int index = Random.Range(0, 5);//0 blue,1 Green,2 Orange,3 Purple,4 Red
                var obj = Instantiate(starObjects[index], starGroup.transform);
                Vector3 pos = new Vector3(48 * c, 48 * r, 0);
                obj.transform.localPosition = pos;//赋给相当于父物体的本地坐标

                var star = obj.GetComponent<Star>();
                star.Row = r;
                star.Column = c;       
                starList.Add(star);
            }
        }
    }

    /// <summary>
    /// 递归寻找CurrentStar相邻颜色相同的星星集合，并存到ClickedStarList集合中
    /// </summary>
    /// <param name="currentStar"></param>
    public void FindTheSameStar(Star currentStar)
    {
        int row = currentStar.Row;
        int column = currentStar.Column;
        //Up row+1,column
        if (row<=maxRow)
        {
            foreach (var item in starList)
            {
                if (item.Row == row + 1 && item.Column == column)
                {
                    if (item.starColor == currentStar.starColor)
                    {
                        if (!ClickedStarList.Contains(item))
                        {
                            ClickedStarList.Add(item);
                            FindTheSameStar(item);
                        }
        
                    }
                }
            }
        }
        //down row-1,column
        if (row >=0)
        {
            foreach (var item in starList)
            {
                if (item.Row == row - 1 && item.Column == column)
                {
                    if (item.starColor == currentStar.starColor)
                    {
                        if (!ClickedStarList.Contains(item))
                        {
                            ClickedStarList.Add(item);
                            FindTheSameStar(item);
                        }
                           
                    }
                }
            }
        }
        //left row,column-1
        if (column>=0)
        {
            foreach (var item in starList)
            {
                if (item.Row == row && item.Column == column -1)
                {
                    if (item.starColor == currentStar.starColor)
                    {
                        if (!ClickedStarList.Contains(item))
                        {
                            ClickedStarList.Add(item);
                            FindTheSameStar(item);
                        }
                    }
                }
            }
        }
        //Right row,column+1
        if (column <= maxColemn)
        {
            foreach (var item in starList)
            {
                if (item.Row == row  && item.Column == column + 1)
                {
                    if (item.starColor == currentStar.starColor)
                    {
                        if (!ClickedStarList.Contains(item))
                        {
                            ClickedStarList.Add(item);
                            FindTheSameStar(item);
                        }

                    }
                }
            }
        }
    }


    /// <summary>
    /// 销毁ClickedStarList集合中的信息，并且从StarList中移除ClickedStarList
    /// </summary>
    public void ClearClickedStarList()
    {
        if (ClickedStarList.Count >=2)
        {
            //销毁
            foreach (var item in ClickedStarList)
            {
                item.DestroyStar();
                starList.Remove(item);
            }
            //向下移动
            foreach (var restStar in starList)
            {
                int moveCount = 0;
                //计算需要向下移动的行数
                foreach (var clickedStar in ClickedStarList)
                {
                    if (restStar.Column == clickedStar.Column && restStar.Row > clickedStar.Row)
                    {
                        moveCount++;
                    }
                }
                if (moveCount>0)
                {
                    restStar.moveDownCount = moveCount;
                    restStar.OpenMoveDown();
                }

            }


            //向左移动
            for (int col = maxColemn-2; col >= 0; col--)//按列遍历
            {
                bool isEmpty = true;
                foreach (var restStar in starList)//判断列是否为空
                {
                    if (restStar.Column == col)
                    {
                        isEmpty = false;
                    }
                }
                if (isEmpty)
                {
                    foreach (var restStar in starList)//计算左移的列数
                    {
                        //位于空列的右边
                        if (restStar.Column>col)
                        {
                            restStar.moveLeftCount++;
                        }
                    }
                }
            }

            foreach (var restStar in starList)//找到moveLeftCount>0的星星，打开开关
            {
                if (restStar.moveLeftCount>=1)
                {
                    restStar.OpenMoveLeft();
                }
            }
        }

        //分数计算
        CalculateScore(ClickedStarList.Count);
        ClickedStarList.Clear();
        JudgeHurdleOver();
        if (judgeSwitch == 0)
        {
            judgeSwitch = 1;
        }

    }


    public void JudgeHurdleOver()
    {
        bool isOver = true;
        foreach (var restStaar in starList)
        {
            FindTheSameStar(restStaar);
            if (ClickedStarList.Count > 0)
            {
                isOver = false;
            }
        }
        ClickedStarList.Clear();
        if (isOver)
        {
            //Hurdle Over
            RestStarRewardScore(starList.Count);
            //Debug.Log("游戏结束");
            //判断总得分是否超过目标分
            if (currentTotalScore >= targetScore)
            {
                //Next Hurdle
                int index = HurdleIndex + 1;
                GameStart(index);
            }
            else
            {
                //GameOver
            }
        }
      
    }

    /// <summary>
    /// 计算分数
    /// </summary>
    /// <param name="destoryStarCount"></param>
    void CalculateScore(int destoryStarCount)
    {
        if (destoryStarCount >= 2)
        {
            float tempScore = 0f;
            for (int i = 0; i < destoryStarCount; i++)
            {
                tempScore += i * 10 + 5;
            }
            currentScore = tempScore;
            currentScoreText.text = currentScore.ToString();//Text显示
            currentTotalScore += currentScore;
            currentTotalScoreText.text = currentTotalScore.ToString();

        }
    }

    /// <summary>
	/// 剩余星星奖励分数
	/// </summary>
	/// <param name="restStarCount"></param>
	void RestStarRewardScore(int restStarCount)
    {
        float rewardScore = 0;
        if (restStarCount < 10)
        {
            rewardScore = 2000 - restStarCount * 100;
            currentTotalScore += rewardScore;
            currentTotalScoreText.text = currentTotalScore.ToString();
        }
    }

    void SetHurdleTargetScore(int hurdleIndex)
    {
        HurdleText.text = "关卡：" + hurdleIndex.ToString();
        if (hurdleIndex == 1)
        {
            targetScore = 1000;
        }
        else if(hurdleIndex>1)
        {
            targetScore = 1000;
            for (int i = 1; i < hurdleIndex; i++)
            {
                targetScore += 2000 +100* (i-1);
            }
        }
        targetScoreText.text = "目标：" + targetScore.ToString();
    }
}
