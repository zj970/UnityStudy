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

    public bool isMyTerm = false;  //当前是否是自己回合


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


    //TODO：写一个出牌的方法 : 只有当属于自己的回合的时候才能出牌
    /// <summary>
    /// 开始出牌
    /// </summary>
    public void PopCards()
    {
        isMyTerm = true;
        GameManager._instance.StopCountDown();
        //等待，开始计时
        GameManager._instance.StartCountDown();

    }

    /// <summary>
    /// 出牌
    /// </summary>
    public void ForFollow()
    {

        //关闭倒计时
        GameManager._instance.StopCountDown();
        //选择的牌，添加到出牌区域
        GameManager._instance.btn_LandlordPlay();
        isMyTerm = false;

    }

    /// <summary>
    /// 不出
    /// </summary>
    public void NotFollow()
    {
        //关闭倒计时
        GameManager._instance.StopCountDown();
        isMyTerm = false;//顺序很重要！！！！！！！！！！！！！！！！！！！！！！！！！！！
        GameManager._instance.NotFollow();


    }

   
    //TODO:把牌排列整齐
    //已在CardBox类中实现

    //1.首先判断当前用户是否是 地主
    // 判断player_type == PLAYER_TYPE.LANDLOD;
    //2.由地主 第一轮 出牌
    //出牌进入倒计时，开始==到计时，倒计时(未出牌)完了，默认出 某种牌
    //牌出完，倒计时提前结束，轮到下位出牌，下一位玩家开始倒计时，出牌

}
