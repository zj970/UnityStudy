using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 13种牌型
/// </summary>
/// 
enum DDZ_POKER_TYPE
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
    /// <summary>
    /// 是否为单
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsSingle(List<int> cards)
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
}
