using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /* 2021-11-3 发牌，洗牌测试
     * 2021-11-4 排序，设置牌的位置测试

    //实例化农民对象
    private PlayerFarmer farmerA = new PlayerFarmer();
    private PlayerFarmer farmerB = new PlayerFarmer();
    //实例化地主对象
    private PlayerLandlord landlord = new PlayerLandlord();

    //牌库
    List<Card>[] player = new List<Card>[3] { new List<Card>(), new List<Card>(), new List<Card>() };
    public void btn_test()
    {
        //洗牌
        Cardbox._instanceCardbox.Shuffle();
        //发牌
        player = Cardbox._instanceCardbox.Licensing();
        //分牌
        for (int i = 0; i < player[0].Count; i++)
        {
            farmerA.playerPokers.Add(player[0][i]);
            farmerB.playerPokers.Add(player[1][i]);
            landlord.playerPokers.Add(player[2][i]);
        }
        //地主牌
        landlord.playerPokers.Add(Cardbox._instanceCardbox.pokers[51]);
        landlord.playerPokers.Add(Cardbox._instanceCardbox.pokers[52]);
        landlord.playerPokers.Add(Cardbox._instanceCardbox.pokers[53]);

        //排序
        Cardbox._instanceCardbox.SortCards(farmerA.playerPokers);
        Cardbox._instanceCardbox.SortCards(farmerB.playerPokers);
        Cardbox._instanceCardbox.SortCards(landlord.playerPokers);

        Cardbox._instanceCardbox.SetCardPos(farmerA.playerPokers);
        print("玩家A");
        for (int i = 0; i < 17; i++)
        {
            print("点数" + farmerA.playerPokers[i].cardIndex + "类型" + farmerA.playerPokers[i].card_type);
        }
        print("玩家B");
        for (int i = 0; i < 17; i++)
        {
            print("点数" + farmerB.playerPokers[i].cardIndex + "类型" + farmerB.playerPokers[i].card_type);
        }
        print("玩家C");
        for (int i = 0; i < 20; i++)
        {
            print("点数" + landlord.playerPokers[i].cardIndex + "类型" + landlord.playerPokers[i].card_type);
        }
    } 
         */


    //TODO:实例化出三个玩家，根据叫分或者选择，成为地主或者农民
    private User landlord = new User();//默认玩家0拥有地主牌
    private User farmerA = new User();
    private User farmerB = new User();

    public List<User> Players;

    //TODO:初始化出牌的容器
    /// <summary>
    /// 出牌的容器
    /// </summary>
    public List<Card> playCards = new List<Card>();

    public static GameManager _instance;

    public int notFollowIndex = 0;  //不跟累计，如果=2，则对手要不起，继续出牌
    private int termStartIndex;  //回合开始玩家索引
    private int termCurrentIndex;  //回合当前玩家索引

    public Transform playPos;
    /// <summary>
    /// 出手的牌型
    /// </summary>
    DDZ_POKER_TYPE playCards_type = DDZ_POKER_TYPE.NOT_OUT;

    //当前出手的玩家
    private User player = new User();

    public int consideratingFollowTime = 5;

    /**************************************UI*****************************************************/
    //准备按钮
    public GameObject prepareBtn;
    //选择按钮
    public GameObject FarmerBtn;
    public GameObject LandlordBtn;
    //出牌按钮
    public GameObject PopCards;
    //虚拟玩家1， 玩家2
    public GameObject player1;
    public Transform player1HeapPos;
    public Text player1HeapPosText;
    public GameObject player2;
    public Transform player2HeapPos;
    public Text player2HeapPosText;
    //地主牌 --- 》 显示位置
    public GameObject LandlordCard1;
    public GameObject LandlordCard2;
    public GameObject LandlordCard3;
    //玩家姓名
    public Text name01;
    //倒计时
    public Text countDown;
    public Text countDownName;
    /**************************************UI*****************************************************/


    //1.牌库初始化
    List<Card>[] playerCards = new List<Card>[3] { new List<Card>(), new List<Card>(), new List<Card>() };
    //2.当玩家点击开始游戏的时候--->btn_Start
    //2.1准备游戏

    private void Start()
    {
        //获得名字
        if (name01 != null )
        {
            name01.text = Login.getName;
        }
        _instance = this;
    }

    /// <summary>
    /// 准备按钮事件
    /// </summary>
    public void Prepare()
    {
        //1.改变玩家游戏状态
        landlord.player_state = PLAYER_STATE.PREGAME;
        farmerA.player_state = PLAYER_STATE.PREGAME;
        farmerB.player_state = PLAYER_STATE.PREGAME;

        //2.显示选择按钮---选择农民 OR 选择地主
        FarmerBtn.SetActive(true);
        LandlordBtn.SetActive(true);

        //3.显示虚拟玩家1，玩家2
        player1.SetActive(true);
        player2.SetActive(true);

        //4.预加载开始游戏事件
        btn_Start();

        //5.销毁自身
        prepareBtn.SetActive(false);
    }

    /// <summary>
    /// 开始游戏事件
    /// </summary>
    public void btn_Start()
    {
        //洗牌
        Cardbox._instanceCardbox.Shuffle();
        //发牌
        playerCards = Cardbox._instanceCardbox.Licensing();
        //分牌
        for (int i = 0; i < playerCards[0].Count; i++)
        {
            landlord.playerPokers.Add(playerCards[0][i]);
            farmerA.playerPokers.Add(playerCards[1][i]);
            farmerB.playerPokers.Add(playerCards[2][i]);
        }
        //给玩家0 分配地主牌
        landlord.playerPokers.Add(Cardbox._instanceCardbox.pokers[51]);
        landlord.playerPokers.Add(Cardbox._instanceCardbox.pokers[52]);
        landlord.playerPokers.Add(Cardbox._instanceCardbox.pokers[53]);

        //排序
        Cardbox._instanceCardbox.SortCards(landlord.playerPokers);
        Cardbox._instanceCardbox.SortCards(farmerA.playerPokers);
        Cardbox._instanceCardbox.SortCards(farmerB.playerPokers);

        //添加到玩家的集合
        Players.Add(landlord);
        Players.Add(farmerA);
        Players.Add(farmerB);
        //测试
        /*for (int i = 0; i < Players.Count; i++)
        {
            print("玩家类型"+Players[i].player_type);
        }*/
    }

    //3.开始抢地主 --->这里设置的是直接选择，跳过这个环节

    //4.当玩家是地主 OR 农民 时
    //4.1 地主
    //4.2 农民

    /// <summary>
    /// 选择农民
    /// </summary>
    public void SelectFarmer()
    {
        //设置玩家游戏状态
        landlord.player_state = PLAYER_STATE.RUNNING;
        farmerA.player_state = PLAYER_STATE.RUNNING;
        farmerB.player_state = PLAYER_STATE.RUNNING;
        //1.从两个农民库中随机抽选一个牌库，这里选择农民A
        farmerA.player_type = PLAYER_TYPE.LANDLORD;

        //测试
       /* for (int i = 0; i < Players.Count; i++)
        {
            print(i+"玩家类型" + Players[i].player_type);
        }*/

        //2.播放发牌动画，实则已经发完牌

        //3.设置牌的位置，并显示地主牌
        //3.1显示地主牌
        LookLandLordCards();
        //3.2显示牌的位置
        Cardbox._instanceCardbox.SetCardPos(farmerA.playerPokers);
  
        Cardbox._instanceCardbox.SetCardPos(landlord.playerPokers, player1HeapPosText, player1HeapPos);
        Cardbox._instanceCardbox.SetCardPos(farmerB.playerPokers, player2HeapPosText, player2HeapPos);

        //失活按钮
        FarmerBtn.SetActive(false);
        LandlordBtn.SetActive(false);

        //激活出牌按钮 --> 测试用的
        //PopCards.SetActive(true);
    }

    /// <summary>
    /// 选择地主
    /// </summary>
    public void SelectLandle()
    {
        //设置玩家游戏状态
        landlord.player_state = PLAYER_STATE.RUNNING;
        farmerA.player_state = PLAYER_STATE.RUNNING;
        farmerB.player_state = PLAYER_STATE.RUNNING;

        landlord.player_type = PLAYER_TYPE.LANDLORD;
        //轮到自己的回合
        landlord.isMyTerm = true;
        //1.获得地主牌

        //2.播放发牌动画
        PlayAnimation();
        //3.显示牌的位置，并显示地主牌
        //3.1显示地主牌
        LookLandLordCards();
        //3.2显示牌的位置
        Cardbox._instanceCardbox.SetCardPos(landlord.playerPokers);
        Cardbox._instanceCardbox.SetCardPos(farmerA.playerPokers,player1HeapPosText,player1HeapPos);
        Cardbox._instanceCardbox.SetCardPos(farmerB.playerPokers,player2HeapPosText,player2HeapPos);

        //测试
        /*for (int i = 0; i < Players.Count; i++)
        {
            print(i + "玩家类型" + Players[i].player_type);
        }*/

        //失活按钮
        LandlordBtn.SetActive(false);
        FarmerBtn.SetActive(false);

        //激活按钮
        PopCards.SetActive(true);

        //TODO：开始回合倒计时 ---> 写一个倒计时的协程
        StartCountDown();
    }

    /// <summary>
    /// 开始计时
    /// </summary>
    public void StartCountDown()
    {
        StartCoroutine("FollowConsiderating");//时间到了     
    }
    
    /// <summary>
    /// 关闭计时
    /// </summary>
    public void StopCountDown()
    {
        StopCoroutine("FollowConsiderating");//时间到了     
    }
    7



    /// <summary>
    /// 发牌动画
    /// </summary>
    public void PlayAnimation()
    {
        //TODO:播放发牌动画
    }

    /// <summary>
    /// 显示地主牌
    /// </summary>
    public void LookLandLordCards()
    {
        //TODO:显示地主牌
        LandlordCard1.SetActive(true);
        LandlordCard2.SetActive(true);
        LandlordCard3.SetActive(true);
        LandlordCard1.GetComponent<Image>().sprite = Cardbox._instanceCardbox.GetCardSp(Cardbox._instanceCardbox.pokers[51]);
        LandlordCard2.GetComponent<Image>().sprite = Cardbox._instanceCardbox.GetCardSp(Cardbox._instanceCardbox.pokers[52]);
        LandlordCard3.GetComponent<Image>().sprite = Cardbox._instanceCardbox.GetCardSp(Cardbox._instanceCardbox.pokers[53]);
    }

    //5.地主出牌 --- 判断出牌数量，出牌类型
    //5.1遍历手中的牌那些被选中
    /// <summary>
    /// 判断手中的牌是否被选择
    /// </summary>
    public void LookPlayCards(List<Card> cards)
    {
        //遍历手中的牌
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].isSelected)
            {
                playCards.Add(cards[i]);//添加到出手的牌库中
            }
        }
        print("出手的数量"+ playCards.Count);
        //判断出手牌是否满足规则
        if (CardRule.PopEnable(playCards, out playCards_type))
        {
            //可以出牌
            print(playCards_type);

            //出牌，删除两个牌库，一个是手中的牌库，一个是出的牌库
            /*for (int i = 0; i < player.playCards.Count; i++)
            {
                cards.Remove(player.playCards[i]);
            }*/
            //重置位置
            Cardbox._instanceCardbox.SetCardPos(cards);//重置手中牌的位置
            Cardbox._instanceCardbox.SetCardPos(playCards, playPos);//重置手中牌的位置
        }
        else
        {
            //出牌类型不满足
            print("不能出牌");
        }

    }
    //5.2判断出牌的类型，是否满足出牌
    public void btn_LandlordPlay()
    {
        //获得当前出手玩家 + 名字

        for (int i = 0; i < Players.Count; i++)
        {
            print(i+"玩家"+ Players[i].player_type + "是否为本局出手" + Players[i].isMyTerm);
            if (Players[i].isMyTerm)
            {
                print("本回合出手玩家"+i);
                countDownName.text = "玩家" + i + "正在出手";
                player = Players[i];
            }
        }

        //判断能否出牌
        LookPlayCards(player.playerPokers);//当前回合玩家所拥有的牌
        //清空出牌库
        playCards.Clear();
        //player.isMyTerm = false;
        //TODO：并设置下一个玩家出牌 ----> SetNextPlayer(）方法
        //SetNextPlayer();
        //下一个玩家出牌 ---> 下一个玩家的状态为在本回合
        print("打印下一回合玩家"+termCurrentIndex);
        Players[termCurrentIndex].PopCards();

        //当前玩家按钮出牌消失

    }

    public void NotFollow()
    {

        //上轮玩家出牌清空;
        //Players[termCurrentIndex].isMyTerm = false;
        SetNextPlayer();
        Players[termCurrentIndex].PopCards();
        notFollowIndex++;

    }
    //6.下家出牌，轮流循环出牌，直至 要不起牌 ，由 出牌最大者 开始新一轮出牌
    //TODO:出牌回合：进入出牌阶段、出牌(规则：满足类型且数量大，牌力值也得大)、不出
    //改变User的基类


    //7.游戏结束 ---- 判断玩家中谁的牌数量 为 0 ，则判断玩家 类型 从而判断 谁获胜，
    //7.1地主获胜 积分+2， 农民  积分-1
    //7.2农民获胜 积分+1， 地主  积分-2

    //8. 重新回到步骤1

    //TODO:出牌规则------------>已在CardRule类中实现
    //TODO:出牌时防止玩家乱出，出的牌一定要排序！


    /// <summary>
    /// 考虑出牌的倒计时
    /// </summary>
    public IEnumerator FollowConsiderating()
    {
        var time = consideratingFollowTime;
        while (time >= 0)
        {
            countDown.text = time.ToString();

            yield return new WaitForSeconds(1);

            time--;
        }
        print("时间到了");
        player.NotFollow();
    }

    /// <summary>
    /// 设置下一个玩家
    /// </summary>
    public void SetNextPlayer()
    {
        //利用下标索引，循环设置是否处于本玩家的回合
        print(Players.Count);
        termCurrentIndex = (termCurrentIndex + 1) % Players.Count;

        for (int i = 0; i < Players.Count; i++)
        {
            print(i+"玩家"+ Players[i].isMyTerm);
            if (Players[i].isMyTerm)
            {
                print("本回合出手玩家" + i);
                countDownName.text = "玩家" + i + "正在出手";
                player = Players[i];
                if (i==0)
                {
                    PopCards.SetActive(true);
                }
                else
                {
                    PopCards.SetActive(false);
                }
            }
        }
    }
}

//2021-11-4
//问题1 ： 登录界面，注册完后无法登录
//初步从猜测：数据结构的问题 用到了string,还有数据结构的问题

