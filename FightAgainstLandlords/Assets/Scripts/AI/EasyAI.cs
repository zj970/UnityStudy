using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实现压死的AI
/// </summary>
public class EasyAI
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
    public List<Card> lastOutCards = new List<Card>();

    /// <summary>
    /// 上家出的牌数量
    /// </summary>
    public int outCounts;

    /// <summary>
    /// 上家出的牌型
    /// </summary>
    public DDZ_POKER_TYPE out_cards_type = DDZ_POKER_TYPE.NOT_OUT;

    //玩家类型
    public PLAYER_TYPE player_type = PLAYER_TYPE.FARMERA;//默认为农民

    /// <summary>
    /// outCards 的类型
    /// </summary>
    public DDZ_POKER_TYPE playCards_type = DDZ_POKER_TYPE.NOT_OUT;

    /// <summary>
    /// 获得上家的出牌库
    /// </summary>
    /// <param name="cards"></param>
    public void GetCards(List<Card> cards ,List<Card> last_cards, DDZ_POKER_TYPE type,List<Card> thisCards)
    {
        AICards = cards;//初始化牌库
        out_cards_type = type;//获得牌型
        lastOutCards = last_cards;//获得上一轮出牌
        outCounts = last_cards.Count;//获得上一轮出牌数
        SatisfyCards = thisCards;
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
    public List<Card> FindCard(List<Card> cards)
    {
        
        if (cards.Count == 1)
        {
            for (int i = 0; i < AICards.Count; i++)
            {
                if (AICards[i].cardIndex > cards[0].cardIndex)
                {
                    SatisfyCards.Add(AICards[i]);
                    return SatisfyCards;
                }
            }
        }

        return null;
    }

    //2.2找出对子
    public List<Card> FindTwin(List<Card> cards)
    {
        List<Card> temp = new List<Card>();
        for (int i = 0; i < AICards.Count - 1; i++)
        {
            if (AICards[i].cardIndex > cards[0].cardIndex && AICards[i + 1].cardIndex == AICards[i].cardIndex)
            {
                temp.Add(AICards[i]);
                temp.Add(AICards[i + 1]);
                return temp;
            }
        }
        return null;
    }
    //2.3找出三带
    public List<Card> FindThree(List<Card> cards)
    {
        int index = 0;
        int target = 0;
        List<Card> temp = new List<Card>();
        
        //三不带
        if (cards.Count == 3)
        {
            target = cards[0].cardIndex;
            for (int i = 0; i < AICards.Count - 2; i++)
            {
                if (AICards[i].cardIndex == AICards[i + 1].cardIndex && AICards[i + 1].cardIndex == AICards[i + 2].cardIndex && AICards[i].cardIndex > target)
                {
                    temp.Add(AICards[i]);
                    temp.Add(AICards[i + 1]);
                    temp.Add(AICards[i + 2]);                   
                    return temp;
                }
            }
        }


        if (cards.Count == 4)
        {
            //找出三带一的牌力值
            for (int i = 0; i < cards.Count -1; i++)
            {
                if (cards[i].cardIndex == cards[i + 1].cardIndex)
                {
                    target = cards[i].cardIndex;
                }
            }
            for (int i = 0; i < AICards.Count - 2; i++)
            {
                if (AICards[i].cardIndex == AICards[i + 1].cardIndex && AICards[i + 1].cardIndex == AICards[i + 2].cardIndex && AICards[i].cardIndex > target)
                {
                    temp.Add(AICards[i]);
                    temp.Add(AICards[i + 1]);
                    temp.Add(AICards[i + 2]);
                    if (i != 0)
                    {
                        temp.Add(AICards[0]);
                    }
                    else
                    {
                        temp.Add(AICards[i - 1]);
                    }
                    return temp;
                }
            }
        }
        else if (cards.Count == 5)
        {
            //找三带二的三的牌力值
            for (int i = 0; i < cards.Count - 2; i++)
            {
                if (cards[i].cardIndex == cards[i + 1].cardIndex && cards[i + 1].cardIndex == cards[i + 2].cardIndex)
                {
                    target = cards[i].cardIndex;
                }
            }

            for (int i = 0; i < AICards.Count -2; i++)
            {
                if (AICards[i].cardIndex == AICards[i + 1].cardIndex && AICards[i + 1].cardIndex == AICards[i + 2].cardIndex && AICards[i].cardIndex > target)
                {
                    temp.Add(AICards[i]);
                    temp.Add(AICards[i + 1]);

                    temp.Add(AICards[i + 2]);
                    index = i;
                    break;
                }
            }

            for (int i = 0; i < AICards.Count - 1; i++)
            {
                if (AICards[i].cardIndex == AICards[i + 1].cardIndex && i != index && temp != null)
                {
                    temp.Add(AICards[i]);
                    temp.Add(AICards[i + 1]);
                    return temp;
                }
            }
        }
        return null;
    }
    //2.4找出连牌

    public List<Card> FindStraight(List<Card> cards)
    {
        List<Card> temp = new List<Card>();
        int index = 0;
        int start = cards[0].cardIndex;
        int counts = cards.Count;
        List<Card> result = EvenCards(AICards);
        if ( result !=null && counts <= result.Count)
        {
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].cardIndex > start)
                {
                    index = i;
                    break;
                }
            }
            if (result.Count - index >= cards.Count)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    temp.Add(result[index++]);
                }
            }


        }

        if (temp != null)
        {
            return temp;
        }
        else
        {
            return null;
        }
    }

    public List<Card> EvenCards(List<Card> list)
    {
        List<Card> cList = new List<Card>();
        for (int i = 0; i < list.Count; i++)
        {
            int num = list[i].cardIndex;
            cList.Add(list[i]);
            for (int j = 0; j < list.Count; j++)
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
    public List<Card> FindStraightWithTwin(List<Card> cards)
    {
        List<Card> temp = new List<Card>();
        List<Card> result = EvenCardsWithTwin(AICards);
        int counts = cards.Count;
        int start = cards[0].cardIndex;
        int index = 0;
        if (result.Count >= counts)
        {
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].cardIndex > start)
                {
                    index = i;
                    break;
                }
            }

            if (result.Count - index >= counts)
            {
                for (int i = 0; i < counts; i++)
                {
                    temp.Add(result[index++]);
                }
            }

        }
        if (temp != null)
        {
            return temp;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 辅助类 ，找出手牌中的连队
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public List<Card> EvenCardsWithTwin(List<Card> list)
    {
        List<Card> cList = new List<Card>();
        for (int i = 0; i < list.Count; i++)
        {
            int num = list[i].cardIndex;

            for (int j = 0; j < list.Count - 1; j += 2)
            {
                if (list[j].cardIndex == num + 1)
                {
                    num = list[j].cardIndex;
                    cList.Add(list[j]);
                    cList.Add(list[j + 1]);
                }
            }

            if (cList.Count >= 6)
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
    //2.6找出飞机
    public List<Card> FindTripleStraight(List<Card> cards)
    {
        List<Card> temp = new List<Card>();
        List<Card> result = new List<Card>();
        int start = 0;
        int end = 0;
        //找出飞机的牌力值
        for (int i = 0; i < cards.Count - 2; i++)
        {
            if (cards[i].cardIndex == cards[i+2].cardIndex)
            {
                start = cards[i].cardIndex;
                break;
            }
        }
        for (int i = 0; i < cards.Count - 2; i++)
        {
            if (cards[i].cardIndex == cards[i + 2].cardIndex)
            {
                end = cards[i].cardIndex;
            }
        }

        //找出飞机
        result = TripleStraight(AICards);

        //三种情况飞机不带，飞机带单，飞机带双
        if (out_cards_type == DDZ_POKER_TYPE.PLANE_PURE)//飞机不带
        {

        }
        else if (out_cards_type == DDZ_POKER_TYPE.PLANE_WITH_SINGLE)//飞机带单
        {

        }
        else if (out_cards_type == DDZ_POKER_TYPE.PLANE_WITH_TWIN)//飞机带双
        {

        }


        return null;
    }

    /// <summary>
    /// 辅助类 找出手牌的飞机
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public List<Card> TripleStraight(List<Card> cards)
    {
        List<Card> result = new List<Card>();
        for (int i = 0; i < cards.Count - 3; i+=2)
        {
            if (cards[i].cardIndex == cards[i+2].cardIndex)
            {
                result.Add(cards[i]);
                result.Add(cards[i+1]);
                result.Add(cards[i+2]);
            }
        }

        bool isStraight = true;
        for (int i = 0; i < result.Count -3; i++)
        {
            if (result[i+3].cardIndex - result[i].cardIndex != 1)
            {
                isStraight = false;
            }
            if (isStraight)
            {
                return result;
            }
        }

        return null;
    }
    //2.7找出炸弹
    public List<Card> FindBoom()
    {
        List<Card> temp = new List<Card>();
        int counts = AICards.Count;
        if (AICards[counts - 2].card_type == Card.CARD_TYPE.SMALL_KING && AICards[counts-1].card_type == Card.CARD_TYPE.KING)
        {
            temp.Add(AICards[counts-2]);
            temp.Add(AICards[counts-1]);
        }
        else
        {
            for (int i = 0; i < AICards.Count-3; i++)
            {
                if (AICards[i].cardIndex == AICards[i+1].cardIndex && AICards[i+1].cardIndex == AICards[i + 2].cardIndex && AICards[i+2].cardIndex == AICards[i + 3].cardIndex)
                {
                    temp.Add(AICards[i]);
                    temp.Add(AICards[i+1]);
                    temp.Add(AICards[i+2]);
                    temp.Add(AICards[i+3]);
                }
            }
        }

        if (temp != null)
        {
            return temp;
            //TODO:有可能炸弹不止一个
        }
        else
        {
            return null;
        }
    }


    //3.出牌或者不出牌---->通过返回值

 
    /// <summary>
    /// 找出能出的牌
    /// </summary>
    public void PassiveShot()
    {
        switch (out_cards_type)
        {
            case DDZ_POKER_TYPE.NOT_OUT:
                //不出
                break;
            case DDZ_POKER_TYPE.SINGLE:
                SatisfyCards = FindCard(lastOutCards);
                break;
            case DDZ_POKER_TYPE.TWIN:
                SatisfyCards = FindTwin(lastOutCards);
                break;
            case DDZ_POKER_TYPE.TRIPLE:
            case DDZ_POKER_TYPE.TRIPLE_WITH_SINGLE:
            case DDZ_POKER_TYPE.TRIPLE_WITH_TWIN:
                SatisfyCards = FindThree(lastOutCards);
                break;
            case DDZ_POKER_TYPE.STRAIGHT_SINGLE:
                SatisfyCards = FindStraight(lastOutCards);
                break;
            case DDZ_POKER_TYPE.STRAIGHT_TWIN:
                SatisfyCards = FindStraightWithTwin(lastOutCards);
                break;
            case DDZ_POKER_TYPE.PLANE_PURE:
                break;
            case DDZ_POKER_TYPE.PLANE_WITH_SINGLE:
                break;
            case DDZ_POKER_TYPE.PLANE_WITH_TWIN:
                break;
            case DDZ_POKER_TYPE.FOUR_WITH_SINGLE:
                break;
            case DDZ_POKER_TYPE.FOUR_WITH_TWIN:
                break;
            case DDZ_POKER_TYPE.FOUR_BOMB:
                break;
            case DDZ_POKER_TYPE.KING_BOMB:
                break;
            default:
                break;
        }
    }



    //AI出牌的三种情况
    //1.主动出牌---》AI是地主或者自己出牌压死了对面

    //2.被动出牌---》AI不是农民或者上家有出牌--自己的牌库有对应的牌型且牌力值大过对面

    //3.不出牌---》AI自己的牌库里面没有对应的牌型，没有炸弹，牌力值压不死对面


    /// <summary>
    /// 设置出牌
    /// </summary>
    public void SetSp()
    {
        if (SatisfyCards != null)
        {
            for (int i = 0; i < SatisfyCards.Count; i++)
            {
                Cardbox._instanceCardbox.GetCardSp(SatisfyCards[i]);           
                //AICards.Remove(SatisfyCards[i]);
            }  
        }
    }

    /// <summary>
    /// 获得出牌的类型
    /// </summary>
    public void SetOutType()
    {
        CardRule.PopEnable(SatisfyCards,out playCards_type);
    }


    /// <summary>
    /// 自动出牌
    /// </summary>
    public void AutoPlay()
    {
        PassiveShot();

        if (SatisfyCards == null)
        {
            //要不起
            //GameManager._instance.currentUser.NotFollow();
            Debug.Log(GameManager._instance.currentUser.player_type+"要不起");
        }

        //判断语句顺序代表执行顺序--------------------------------------不能让SatisfyCards为空的情况在后面
        if (SatisfyCards != null && SatisfyCards.Count > 0)
        {
            //出牌
            SetSp();
            Cardbox._instanceCardbox.SortCards(SatisfyCards);
            Cardbox._instanceCardbox.SetCardPos(SatisfyCards, GameManager._instance.playPos);
            GameManager._instance.lastOutCardsFalse();
            //清理牌
            AutoClear();
        }
        
       

        if (SatisfyCards != null && lastOutCards.Count == 0)
        {
            SatisfyCards.Clear();
            SatisfyCards.Add(AICards[0]);
            SetSp();
            //出牌
            Cardbox._instanceCardbox.SetCardPos(SatisfyCards, GameManager._instance.playPos);
            //清理牌
            AutoClear();
        }

    }


    /// <summary>
    /// 清理牌
    /// </summary>
    public void AutoClear()
    {
        for (int i = 0; i < lastOutCards.Count; i++)
        {
            GameManager._instance.outCardBox.Add(lastOutCards[i]);
        }
        //清理上次的出牌库
        lastOutCards.Clear();
        for (int i = 0; i < SatisfyCards.Count; i++)
        {
            lastOutCards.Add(SatisfyCards[i]);
            AICards.Remove(SatisfyCards[i]);
        }
        SatisfyCards.Clear();
    }

    //出牌要排序

    //TODO：调用AI时，出完牌一定将牌删除
}
