using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 13种牌型
/// </summary>
/// 
public enum DDZ_POKER_TYPE
{
    /// <summary>
    /// 过牌，不出
    /// </summary>
    NOT_OUT = 0,
    /// <summary>
    /// 单张
    /// </summary>
    SINGLE = 1,
    /// <summary>
    /// 一对
    /// </summary>
    TWIN = 2,
    /// <summary>
    /// 三张
    /// </summary>
    TRIPLE = 3,
    /// <summary>
    /// 三带一
    /// </summary>
    TRIPLE_WITH_SINGLE = 4,
    /// <summary>
    /// 三带一对
    /// </summary>
    TRIPLE_WITH_TWIN = 5,
    /// <summary>
    /// 顺子
    /// </summary>
    STRAIGHT_SINGLE = 6,
    /// <summary>
    /// 连对
    /// </summary>
    STRAIGHT_TWIN = 7,
    /// <summary>
    /// 飞机不带
    /// </summary>
    PLANE_PURE = 8,
    /// <summary>
    /// 飞机带单
    /// </summary>
    PLANE_WITH_SINGLE = 9,
    /// <summary>
    /// 飞机带双
    /// </summary>
    PLANE_WITH_TWIN = 10,
    /// <summary>
    /// 四带两单
    /// </summary>
    FOUR_WITH_SINGLE = 11,
    /// <summary>
    /// 四带两对
    /// </summary>
    FOUR_WITH_TWIN = 12,
    /// <summary>
    /// 炸弹
    /// </summary>
    FOUR_BOMB = 13,
    /// <summary>
    /// 王炸
    /// </summary>
    KING_BOMB = 14
};


/// <summary>
/// 出牌规则
/// </summary>
public class CardRule
{

    #region 出牌判断规则

    /// <summary>
    /// 是否为单
    /// </summary>
    /// <param name="cards">选中的牌</param>
    /// <returns></returns>
    public static bool IsSingle(List<Card> cards)
    {
        if (cards.Count == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 是否是对子
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsDouble(List<Card> cards)
    {
        if (cards.Count == 2 && cards[0].cardIndex == cards[1].cardIndex)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 是否为顺子
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsStraight(List<Card> cards)
    {
        if (cards.Count < 5 || cards.Count > 12)
        {
            return false;
        }
        for (int i = 0; i < cards.Count - 1; i++)
        {
            int w = cards[i].cardIndex;
            if (cards[i + 1].cardIndex - w != 1)
            {
                return false;
            }

            //不能超过A
            if (w > 12 || cards[i + 1].cardIndex > 12)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 判断是否为双顺子
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsDoubleStraight(List<Card> cards)
    {
        if (cards.Count < 6 || cards.Count % 2 != 0)
        {
            return false;
        }

        for (int i = 0; i < cards.Count; i += 2)
        {
            if (cards[i].cardIndex != cards[i + 1].cardIndex)
            {
                return false;
            }
            if (i < cards.Count - 2)
            {
                if (cards[i + 2].cardIndex - cards[i].cardIndex != 1)
                {
                    return false;
                }
            }
            //不超过A
            if (cards[i].cardIndex > 12 || cards[i + 2].cardIndex > 12)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 是否是三不带
    /// </summary>
    /// <returns></returns>
    public static bool IsOnlyThree(List<Card> cards)
    {
        if (cards.Count % 3 != 0)
        {
            return false;
        }

        if (cards[0].cardIndex != cards[1].cardIndex ||
            cards[1].cardIndex != cards[2].cardIndex)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 是否三带一
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsThreeAndOne(List<Card> cards)
    {
        if (cards.Count != 4)
        {
            return false;
        }

        if (cards[0].cardIndex == cards[1].cardIndex && cards[1].cardIndex == cards[2].cardIndex && cards[2].cardIndex != cards[3].cardIndex)
        {
            return true;
        }
        else if (cards[0].cardIndex != cards[1].cardIndex && cards[1].cardIndex == cards[2].cardIndex && cards[2].cardIndex == cards[3].cardIndex)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 是否为三带二
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsThreeAndTwo(List<Card> cards)
    {
        if (cards.Count != 5)
        {
            return false;
        }

        if (cards[0].cardIndex == cards[1].cardIndex && cards[1].cardIndex == cards[2].cardIndex && cards[2].cardIndex != cards[3].cardIndex)
        {
            if (cards[3].cardIndex == cards[4].cardIndex)
            {
                return true;
            }
        }
        if (cards[0].cardIndex == cards[1].cardIndex && cards[1].cardIndex != cards[2].cardIndex)
        {
            if (cards[2].cardIndex == cards[3].cardIndex && cards[3].cardIndex == cards[4].cardIndex)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 是否为炸弹
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsBoom(List<Card> cards)
    {
        if (cards.Count != 4)
        {
            return false;
        }

        if (cards[0] != cards[1])
        {
            return false;
        }

        if (cards[1] != cards[2])
        {
            return false;
        }

        if (cards[2] != cards[3])
        {
            return false;
        }

        return true;
    }


    /// <summary>
    /// 是否为王炸
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsJokerBoom(List<Card> cards)
    {
        if (cards.Count != 2)
        {
            return false;
        }
        if (cards[0].card_type == Card.CARD_TYPE.SMALL_KING && cards[1].card_type == Card.CARD_TYPE.KING)
        {
            return true;
        }
        if (cards[1].card_type == Card.CARD_TYPE.SMALL_KING && cards[0].card_type == Card.CARD_TYPE.KING)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 是否为飞机不带
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsTripleStraight(List<Card> cards)
    {
        if (cards.Count < 6 || cards.Count % 3 != 0)
        {
            return false;
        }
        for (int i = 0; i < cards.Count; i += 3)
        {
            if (cards[i + 1].cardIndex != cards[i].cardIndex)
            {
                return false;
            }
            if (cards[i + 2].cardIndex != cards[i].cardIndex)
            {
                return false;
            }
            if (cards[i + 1].cardIndex != cards[i + 2].cardIndex)
            {
                return false;
            }

            if (i < cards.Count - 3)
            {
                if (cards[i + 3].cardIndex - cards[i].cardIndex != 1)
                {
                    return false;
                }

                //不超过A
                if (cards[i].cardIndex > 12 || cards[i + 3].cardIndex > 12)
                {
                    return false;
                }
            }
        }

        return true;
    }


    /// <summary>
    /// 是否为飞机带单
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsPlaneWithSingle(List<Card> cards)
    {
        if (cards.Count < 8 || cards.Count % 4 != 0)
        {
            return false;
        }
        else
        {
            List<Card> tempThreeList = new List<Card>();
            for (int i = 0; i < cards.Count; i++)
            {
                int tempInt = 0;
                for (int j = 0; j < cards.Count; j++)
                {
                    if (cards[i].cardIndex == cards[j].cardIndex)
                    {
                        tempInt++;
                    }
                }
                if (tempInt == 3)
                {
                    tempThreeList.Add(cards[i]);
                }
            }
            if (tempThreeList.Count % 3 != cards.Count % 4)
            {
                return false;
            }
            else
            {
                if (IsTripleStraight(tempThreeList))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }


    /// <summary>
    /// 是否为飞机带双
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsPlaneWithTwin(List<Card> cards)
    {
        if (cards.Count < 10 || cards.Count % 5 != 0)
        {
            return false;
        }
        else
        {
            List<Card> tempThreeList = new List<Card>();
            List<Card> tempTwoList = new List<Card>();

            for (int i = 0; i < cards.Count; i++)
            {
                int tempInt = 0;
                for (int j = 0; j < cards.Count; j++)
                {
                    if (cards[i].cardIndex == cards[j].cardIndex)
                    {
                        tempInt++;
                    }
                }

                if (tempInt == 3)
                {
                    tempThreeList.Add(cards[i]);
                }
                else if (tempInt == 2)
                {
                    tempTwoList.Add(cards[i]);
                }
            }

            if (tempThreeList.Count % 3 != cards.Count % 5 && tempTwoList.Count % 2 != cards.Count % 5)
            {
                return false;
            }
            else
            {
                if (IsTripleStraight(tempThreeList))
                {
                    if (IsAllDouble(tempTwoList))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }

    /// <summary>
    /// 是否为四带二
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsFourWithTwin(List<Card> cards)
    {
        bool flag = false;
        if (cards != null && cards.Count == 6)
        {
            for (int i = 0; i < 3; i++)
            {
                int grade1 = cards[i].cardIndex;
                int grade2 = cards[i+1].cardIndex;
                int grade3 = cards[i+2].cardIndex;
                int grade4 = cards[i+3].cardIndex;

                if (grade2 == grade1 && grade3 == grade1 && grade1 == grade4)
                {
                    flag = true;
                }
            }
        }

        return flag;
    }


    #endregion

    /*************************************************辅助方法**********************************************************/


    /// <summary>
    /// 判断手中的牌是否全是对子
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsAllDouble(List<Card> cards)
    {
        for (int i = 0; i < cards.Count % 2; i+=2)
        {
            if (cards[i] != cards[i+1])
            {
                return false;
            }
        }
        return true;
    }


    /// <summary>
    /// 是否里面拥有四张牌
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool HaveFour(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int tempInt = 0;
            for (int j = 0; j < cards.Count; j++)
            {
                if (cards[i] == cards[j])
                {
                    tempInt++;
                }
            }
            if (tempInt == 4)
            {
                return true;
            }
        }
        return false;
    }

    /*************************************************辅助方法**********************************************************/




    #region 判断是否能出手
    /// <summary>
    /// 判断是否可以出牌
    /// </summary>
    /// <param name="cards">出的牌</param>
    /// <param name="type">出的牌型，自动判断</param>
    /// <returns></returns>
    public static bool PopEnable(List<Card> cards, out DDZ_POKER_TYPE type)
    {
        bool isRule = false;
        type = DDZ_POKER_TYPE.NOT_OUT;

        switch (cards.Count)
        {
            case 1:
                isRule = true;
                type = DDZ_POKER_TYPE.SINGLE;
                break;

            case 2:
                if (IsDouble(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.TWIN;
                }
                else if (IsJokerBoom(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.KING_BOMB;
                }
                break;

            case 3:
                if (IsOnlyThree(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.TRIPLE;
                }
                break;

            case 4:
                if (IsBoom(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.FOUR_BOMB;
                }
                else if (IsThreeAndOne(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.TRIPLE_WITH_SINGLE;
                }
                break;

            case 5:
                if (IsThreeAndTwo(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.TRIPLE_WITH_TWIN;
                }
                else if (IsStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_SINGLE;
                }
                break;

            case 6:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_SINGLE;
                }
                else if (IsTripleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_PURE;
                }
                else if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_TWIN;
                }
                else if (IsFourWithTwin(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.FOUR_WITH_SINGLE;
                }
                break;

            case 7:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_SINGLE;
                }
                break;

            case 8:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_SINGLE;
                }
                else if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_TWIN;
                }
                else if (IsPlaneWithSingle(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_WITH_SINGLE;
                }
                break;

            case 9:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_SINGLE;
                }
                else if (IsTripleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_PURE;
                }
                break;

            case 10:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_SINGLE;
                }
                else if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_TWIN;
                }
                else if (IsPlaneWithTwin(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_WITH_TWIN;
                }
                break;

            case 11:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_SINGLE;
                }
                break;

            case 12:
                if (IsStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_SINGLE;
                }
                else if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_TWIN;
                }
                else if (IsPlaneWithSingle(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_WITH_SINGLE;
                }
                else if (IsTripleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_PURE;
                }
                break;

            case 13:
                break;

            case 14:
                if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_TWIN;
                }
                break;

            case 15:
                if (IsTripleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_PURE;
                }
                else if (IsPlaneWithTwin(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_WITH_TWIN;
                }
                break;

            case 16:
                if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_TWIN;
                }
                else if (IsPlaneWithSingle(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_WITH_SINGLE;
                }
                break;

            case 17:
                break;

            case 18:
                if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_TWIN;
                }
                else if (IsTripleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_PURE;
                }
                break;

            case 19:
                break;

            case 20:
                if (IsDoubleStraight(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.STRAIGHT_TWIN;
                }
                else if (IsPlaneWithSingle(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_WITH_SINGLE;
                }
                else if (IsPlaneWithTwin(cards))
                {
                    isRule = true;
                    type = DDZ_POKER_TYPE.PLANE_WITH_TWIN;
                }
                break;

            default:
                break;
        }

        return isRule;
    }
    #endregion
}
