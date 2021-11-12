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
    FARMERA = 0,
    FARMERB = 1,
    /// <summary>
    /// 地主
    /// </summary>
    LANDLORD = 2,


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
    /// <summary>
    /// 玩家手中的牌
    /// </summary>
    public List<Card> playerPokers = new List<Card>();
    //TODO:初始化出牌的容器
    /// <summary>
    /// 玩家类型
    /// </summary>
    public PLAYER_TYPE player_type = PLAYER_TYPE.FARMERA;//默认为农民
    //玩家状态 
    public PLAYER_STATE player_state = PLAYER_STATE.PREGAME;//默认为准备状态

    public bool isMyTerm = false;  //当前是否是自己回合


    //TODO：写一个出牌的方法 : 只有当属于自己的回合的时候才能出牌
    /// <summary>
    /// 开始出牌
    /// </summary>
    public void PopCards()
    {
        if (GameManager._instance.PlayOver())
        {
            GameManager._instance.StopCountDown();
        }
        else
        {
            isMyTerm = true;
            GameManager._instance.StopCountDown();
            //等待，开始计时
            GameManager._instance.StartCountDown();
        }
    }

    /// <summary>
    /// 出牌
    /// </summary>
    public void ForFollow()
    {
        if (GameManager._instance.PlayOver())
        {
            GameManager._instance.StopCountDown();
        }
        else
        {
            //关闭倒计时
            GameManager._instance.StopCountDown();
            //选择的牌，添加到出牌区域
            //GameManager._instance.PopCards.SetActive(true);
            GameManager._instance.btn_LandlordPlay();
            //判断能否出牌
            //GameManager._instance.LookPlayCards(GameManager._instance.player.playerPokers);//当前回合玩家所拥有的牌

            isMyTerm = false;
        }
 
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
