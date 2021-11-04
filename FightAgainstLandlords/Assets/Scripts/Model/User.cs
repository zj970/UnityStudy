using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家类型
/// </summary>
public enum PLAYER_TYPE
{
    /// <summary>
    /// 农民
    /// </summary>
    FARMER = 0,
    /// <summary>
    /// 地主
    /// </summary>
    LANDLORD = 1
}

/// <summary>
/// 玩家游戏状态
/// </summary>
public enum PLAYER_STATE
{
    /// <summary>
    /// 准备状态
    /// </summary>
    PREGAME = 0,
    /// <summary>
    /// 正在游戏
    /// </summary>
    RUNNING = 1,
    /// <summary>
    /// 暂停游戏
    /// </summary>
    PAUSED = 2,
    /// <summary>
    /// 退出
    /// </summary>
    QUIT = 3,
}
/// <summary>
/// 倒计时状态
/// </summary>
public enum CountDownTypes
{
    Bid,
    Follow
}

/// <summary>
/// 玩家实例
/// </summary>
public class User : MonoBehaviour
{
    //TODO:玩家手里面的牌

    //存放扑克牌
    public List<Card> playerPokers = new List<Card>();

    //玩家类型
    public PLAYER_TYPE player_type = PLAYER_TYPE.FARMER;//默认为农民
    //玩家状态 
    public PLAYER_STATE player_state = PLAYER_STATE.PREGAME;//默认为准备状态

    private int consideratingBidTime = 12; //玩家考虑时间
    private int consideratingFollowTime = 20; //玩家考虑时间
    protected bool isMyTerm = false;  //当前是否是自己回合




    //TODO:直接选择当农民还是地主

    /// <summary>
    /// 当农民
    /// </summary>
    public void btn_farmer()
    {
        player_type = PLAYER_TYPE.FARMER;//设置为农民
    }

    /// <summary>
    /// 当地主
    /// </summary>
    public void btn_landlord()
    {
        player_type = PLAYER_TYPE.LANDLORD;//设置为地主
        
        //TODO:获得底牌
    }

    //TODO:把牌排列整齐
    //已在CardBOx类中实现

}
