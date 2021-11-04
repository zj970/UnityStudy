using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 扑克牌实体
/// </summary>
public class Card : MonoBehaviour
{
    //TODO:属性
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

    //是否选中
    public bool isSelected;

    //获得当前位置信息
    public Vector3 pokerPos;

    #endregion


    //TODO：方法

    /// <summary>
    /// 设置选择状态
    /// </summary>
    public void SetSelectState()
    {
        //记录当前位置
        //pokerPos = this.transform.position;
        if (!isSelected)
        {
            this.transform.position += new Vector3(0, 10, 0);
        }
        else
        {
            //this.transform.position = pokerPos;//重置位置
            this.transform.position -= new Vector3(0, 10, 0);
        }
        isSelected = !isSelected;
        print(isSelected);
    }
}
