using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实现压死的AI
/// </summary>
public class EasyAI : MonoBehaviour
{
    //TODO:手里面自己牌型，可以通过传参或者继承的方式，获得电脑玩家的手中的牌
    
    /// <summary>
    /// AL手里面的牌
    /// </summary>
    public List<Card> AICards = new List<Card>();

    /// <summary>
    /// 满足上家出的牌型牌力值
    /// </summary>
    public List<Card> SatisfyCards = new List<Card>();


    /// <summary>
    /// 上家出的牌
    /// </summary>
    public List<Card> OutCards = new List<Card>();

    /// <summary>
    /// 上家出的牌数量
    /// </summary>
    public int outCounts;

    /// <summary>
    /// 上家出的牌型
    /// </summary>
    public DDZ_POKER_TYPE out_cards_type = DDZ_POKER_TYPE.NOT_OUT;


    //TODO
    //1.获得上家出的牌------>通过传参的方式

    /// <summary>
    /// AI获得牌库
    /// </summary>
    /// <param name="cards"></param>
    public void GetAICards(List<Card> cards)
    {
        AICards = cards;
    }

    /// <summary>
    /// 获得上家的出牌库
    /// </summary>
    /// <param name="cards"></param>
    public void GetOutCards(List<Card> cards , DDZ_POKER_TYPE type)
    {
        out_cards_type = type;//获得牌型
        OutCards = cards;//获得上一轮出牌
        outCounts = cards.Count;//获得上一轮出牌数
    }
    //2.寻找自己牌库里满足的牌型，且牌力值比上家大

    //TODO:计算牌力值
    /// <summary>
    /// 计算牌力值
    /// </summary>
    public void Calculation()
    {

    }

    //TODO:找自己牌库里满足的牌型

    //2.1找出单张

    //2.2找出对子

    //2.3找出三带

    //2.4找出连牌
    static List<Card> EvenCards(List<Card> list)
    {
        List<Card> cList = new List<Card>();
        for (int i = 0; i < list.Count; ++i)
        {
            int num = list[i].cardIndex;
            cList.Add(list[i]);
            for (int j = 0; j < list.Count; ++j)
            {
                if (list[j].cardIndex == num + 1)
                {
                    num = list[j].cardIndex;
                    cList.Add(list[j]);
                }
            }
            if (cList.Count >= 5)
            {

                return cList;
            }
            else
            {
                cList.Clear();
            }
        }
        return null;
    }

    //2.5找出连队

    //2.6找出飞机

    //2.7找出炸弹


    //3.出牌或者不出牌---->通过返回值


}
