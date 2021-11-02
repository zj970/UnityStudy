using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 扑克牌实体
/// </summary>
public class Card : MonoBehaviour
{
    //TODO:属性和方法
    #region 初始化
    /// <summary>
    /// 扑克类型
    /// </summary>
    public enum CARD_TYPE
    {
        /// <summary>
        /// 方块
        /// </summary>
        BLOCK = 0,
        /// <summary>
        /// 梅花
        /// </summary>
        PLUM_BLOSSOM = 1,
        /// <summary>
        /// 红桃
        /// </summary>
        HEART = 2,
        /// <summary>
        /// 黑桃
        /// </summary>
        SPADE = 3,
        /// <summary>
        /// 小王
        /// </summary>
        SMALL_KING = 4,
        /// <summary>
        /// 大王
        /// </summary>
        KING = 5
    };

    //牌的类型
    public CARD_TYPE card_type = CARD_TYPE.BLOCK;//默认为方块


    //卡牌所在类型的索引,代表大小
    public int cardIndex;

    #endregion


}
