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

    /// <summary>
    /// 初始化玩家集合
    /// </summary>
    User[] users = new User[3] { new User(), new User(), new User() };//静态初始化

    /// <summary>
    /// 已出牌的容器
    /// </summary>
    public List<Card> outCardBox = new List<Card>();

    /// <summary>
    /// 上一回合的容器
    /// </summary>
    public List<Card> lastOutCards = new List<Card>();
    /// <summary>
    /// 本回合的容器
    /// </summary>
    public List<Card> thisOutCards = new List<Card>();

    /// <summary>
    /// 方便调用
    /// </summary>
    public static GameManager _instance;
    /// <summary>
    /// 记录不出的回合数
    /// </summary>
    public int notFollowIndex = 0;  //不跟累计，如果=2，则对手要不起，继续出牌
    /// <summary>
    /// 当前回合玩家的索引
    /// </summary>
    private int termCurrentIndex = 0;
    /// <summary>
    /// 出牌的位置
    /// </summary>
    public Transform playPos;

    //当前等陆的玩家
    public User player = new User();

    //当前出牌玩家
    public User currentUser = new User();

    //考虑的时间(s)
    public int consideratingFollowTime = 10;

    /// <summary>
    /// outCards 的类型
    /// </summary>
    public DDZ_POKER_TYPE lastCards_type;
    public DDZ_POKER_TYPE thisCards_type;


    /// <summary>
    /// AI对象
    /// </summary>
    public EasyAI AI = new EasyAI();

    #region UI界面的对象
    /**************************************UI*****************************************************/
    //准备按钮
    public GameObject prepareBtn;
    //选择按钮
    public GameObject FarmerBtn;
    public GameObject LandlordBtn;
    //出牌按钮
    public GameObject PopCards;
    //虚拟玩家1， 玩家2
    public GameObject player1;//头像
    public Transform player1HeapPos;//牌的储存位置
    public Text player1HeapPosText;//牌的数据
    public GameObject player2;
    public Transform player2HeapPos;
    public Text player2HeapPosText;
    //地主牌 --- 》 显示位置
    public GameObject LandlordCard1;
    public GameObject LandlordCard2;
    public GameObject LandlordCard3;
    //当前玩家姓名
    public Text name01;
    //倒计时
    public Text countDown;
    public Text countDownName;

    //游戏结束的界面
    public GameObject GameOver;
    /**************************************UI*****************************************************/
    #endregion

    //1.牌库初始化
    /// <summary>
    /// 三个玩家的牌库
    /// </summary>
    List<Card>[] playerCards = new List<Card>[3] { new List<Card>(), new List<Card>(), new List<Card>() };
    //2.当玩家点击开始游戏的时候--->btn_Start
    //2.1准备游戏

    private void Awake()
    {
        ////获得名字
        if (name01 != null && Login.getName != null)
        {
            name01.text = Login.getName;
        }
        else if (SignIn_Up._instance.inUserName.text != null)
        {
            name01.text = SignIn_Up._instance.inUserName.text;
        }
        _instance = this;
    }

    /// <summary>
    /// 准备按钮事件
    /// </summary>
    public void Prepare()
    {
        //print(users[0]);--->值为null

        //1.改变玩家游戏状态
        users[0].player_state = PLAYER_STATE.PREGAME;
        users[1].player_state = PLAYER_STATE.PREGAME;
        users[2].player_state = PLAYER_STATE.PREGAME;

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
            users[0].playerPokers.Add(playerCards[0][i]);
            users[1].playerPokers.Add(playerCards[1][i]);
            users[2].playerPokers.Add(playerCards[2][i]);
        }

        //测试---->判断发牌是否正确
        /*for (int i = 0; i < users.Count; i++)
        {
            print("玩家类型" + users[i].player_type);
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
        //给玩家2 分配地主牌 ----》默认玩家0拥有地主牌
        users[2].playerPokers.Add(Cardbox._instanceCardbox.pokers[51]);
        users[2].playerPokers.Add(Cardbox._instanceCardbox.pokers[52]);
        users[2].playerPokers.Add(Cardbox._instanceCardbox.pokers[53]);

        //排序
        Cardbox._instanceCardbox.SortCards(users[0].playerPokers);
        Cardbox._instanceCardbox.SortCards(users[1].playerPokers);
        Cardbox._instanceCardbox.SortCards(users[2].playerPokers);

        //设置玩家游戏状态
        users[0].player_state = PLAYER_STATE.RUNNING;
        users[1].player_state = PLAYER_STATE.RUNNING;
        users[2].player_state = PLAYER_STATE.RUNNING;

        //设置玩家类型----0.农民A, 1.农民，2.地主
        users[0].player_type = PLAYER_TYPE.FARMERA;
        users[1].player_type = PLAYER_TYPE.FARMERB;
        users[2].player_type = PLAYER_TYPE.LANDLORD;

        player = users[0];
        //2.播放发牌动画，实则已经发完牌
        PlayAnimation();
        //3.设置牌的位置，并显示地主牌
        //3.1显示地主牌
        LookLandLordCards();
        //3.2显示牌的位置
        showCardPos();

        //失活按钮
        FarmerBtn.SetActive(false);
        LandlordBtn.SetActive(false);


        //默认地主出牌
        termCurrentIndex = 1;
        currentUser = users[termCurrentIndex];
        currentUser.isMyTerm = true;
        currentUser.ForFollow();
        SetNextPlayer();
        users[termCurrentIndex].PopCards();
        print("打印下一回合玩家" + termCurrentIndex);
        //激活出牌按钮 --> 测试用的
        //PopCards.SetActive(true);
    }

    /// <summary>
    /// 选择地主
    /// </summary>
    public void SelectLandle()
    {
        //给玩家0 分配地主牌 ----》默认玩家0拥有地主牌
        users[0].playerPokers.Add(Cardbox._instanceCardbox.pokers[51]);
        users[0].playerPokers.Add(Cardbox._instanceCardbox.pokers[52]);
        users[0].playerPokers.Add(Cardbox._instanceCardbox.pokers[53]);

        //排序
        Cardbox._instanceCardbox.SortCards(users[0].playerPokers);
        Cardbox._instanceCardbox.SortCards(users[1].playerPokers);
        Cardbox._instanceCardbox.SortCards(users[2].playerPokers);

        //设置玩家类型----0.地主,1.农民A, 2.农民B
        users[0].player_type = PLAYER_TYPE.LANDLORD;
        users[1].player_type = PLAYER_TYPE.FARMERA;
        users[2].player_type = PLAYER_TYPE.FARMERB;

        //当前回合为地主玩家
        player = users[0];
        //设置玩家游戏状态
        users[0].player_state = PLAYER_STATE.RUNNING;
        users[1].player_state = PLAYER_STATE.RUNNING;
        users[2].player_state = PLAYER_STATE.RUNNING;


        //轮到自己的回合
        //landlord.isMyTerm = true;
        //1.获得地主牌

        //2.播放发牌动画
        PlayAnimation();
        //3.显示牌的位置，并显示地主牌
        //3.1显示地主牌
        LookLandLordCards();
        //3.2显示牌的位置
        showCardPos();
        //失活按钮
        LandlordBtn.SetActive(false);
        FarmerBtn.SetActive(false);

        //激活按钮
        PopCards.SetActive(true);

        //TODO：开始回合倒计时 ---> 写一个倒计时的协程
        //users[termCurrentIndex].PopCards();

        //当前玩家出手
        currentUser = users[0];
        player.PopCards();
        SetNextPlayer();
        users[termCurrentIndex].PopCards();
        print("打印下一回合玩家" + termCurrentIndex);
    }

    /// <summary>
    /// 显示牌的位置
    /// </summary>
    public void showCardPos()
    {
        /*if (player.player_type == PLAYER_TYPE.LANDLORD)
        {
            Cardbox._instanceCardbox.SetCardPos(users[0].playerPokers);
            SetFPos(users[0].playerPokers,Cardbox._instanceCardbox.heapPos);
            Cardbox._instanceCardbox.SetCardPos(users[1].playerPokers, player1HeapPosText, player1HeapPos);
            SetFPos(users[1].playerPokers,player1HeapPos);
            Cardbox._instanceCardbox.SetCardPos(users[2].playerPokers, player2HeapPosText, player2HeapPos);
            SetFPos(users[2].playerPokers, player2HeapPos);
        }
        else if (player.player_type == PLAYER_TYPE.FARMERA)
        {
            Cardbox._instanceCardbox.SetCardPos(users[0].playerPokers);
            Cardbox._instanceCardbox.SetCardPos(users[1].playerPokers, player1HeapPosText, player1HeapPos);
            Cardbox._instanceCardbox.SetCardPos(users[2].playerPokers, player2HeapPosText, player2HeapPos);
        }*/
        Cardbox._instanceCardbox.SetCardPos(users[0].playerPokers);
        SetFPos(users[0].playerPokers, Cardbox._instanceCardbox.heapPos);
        Cardbox._instanceCardbox.SetCardPos(users[1].playerPokers, player1HeapPosText, player1HeapPos);
        SetFPos(users[1].playerPokers, player1HeapPos);
        Cardbox._instanceCardbox.SetCardPos(users[2].playerPokers, player2HeapPosText, player2HeapPos);
        SetFPos(users[2].playerPokers, player2HeapPos);
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
    public void LookPlayCards()
    {
        //遍历手中的牌
        for (int i = 0; i < player.playerPokers.Count; i++)
        {
            if (player.playerPokers[i].isSelected)
            {
                thisOutCards.Add(player.playerPokers[i]);//添加到出手的牌库中
            }
        }
        print("出手的数量" + thisOutCards.Count);
        //判断出手牌是否满足规则
        if (CardRule.PopEnable(thisOutCards, out thisCards_type))
        {

            outCards();//出牌
            lastCards_type = thisCards_type;
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

        LookPlayCards();//看手中的牌能否出的去
        Recorder();
        player.isMyTerm = false;//出手完变成false;
        SetNextPlayer();
        users[termCurrentIndex].PopCards();
        //重置不出牌的回合数
        notFollowIndex = 0;
    }

    public void NotFollow()
    {

        //上轮玩家出牌清空;
        //users[termCurrentIndex].isMyTerm = false;
        SetNextPlayer();
        users[termCurrentIndex].PopCards();
        notFollowIndex++;
        if (notFollowIndex >= 2)
        {
            lastOutCardsFalse();
            notFollowIndex = 0;
        }
        print(notFollowIndex);

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

    //TODO:清理出牌，并且记牌

    /// <summary>
    /// 清理出牌并记牌
    /// </summary>
    public void Recorder()
    {
        for (int i = 0; i < thisOutCards.Count; i++)
        {
            //playCards[i].gameObject.SetActive(false);
            //outCardBox.Add(thisOutCards[i]);
            //lastOutCards.Add(thisOutCards[i]);
        }
        //清空出牌库      
        thisOutCards.Clear();
    }

    /// <summary>
    /// 考虑出牌的倒计时
    /// </summary>
    public IEnumerator FollowConsiderating()
    {
        var time = consideratingFollowTime;
        int AI_time = consideratingFollowTime - 2;
        while (time >= 0)
        {
            countDown.text = time.ToString();

            yield return new WaitForSeconds(1);            
            time--;
            //AI考虑事件为2S
            if (time < AI_time && currentUser.player_type != player.player_type)
            {
                AI_Auto_Cards();
            }

        }
        print("时间到了");
        currentUser.NotFollow();
    }

    /// <summary>
    /// 设置下一个玩家
    /// </summary>
    public void SetNextPlayer()
    {
        //利用下标索引，循环设置是否处于本玩家的回合
        //print(users.Count);
        
            termCurrentIndex = (termCurrentIndex + 1) % users.Length;
            player2HeapPosText.text = users[2].playerPokers.Count.ToString();
            player1HeapPosText.text = users[1].playerPokers.Count.ToString();
            for (int i = 0; i < users.Length; i++)
            {
                print(i + "玩家" + users[i].isMyTerm);
                if (users[i].isMyTerm)
                {
                    print("本回合出手玩家" + i);
                    countDownName.text = "玩家" + i + "正在出手";
                    currentUser = users[i];
                    if (player.isMyTerm)
                    {
                        PopCards.SetActive(true);
                    }
                    else
                    {
                        PopCards.SetActive(false);
                    }
                }
            }

            //查看所有玩家的牌库
        
    }

    /// <summary>
    /// 出牌
    /// </summary>
    public void outCards()
    {
        print("出牌的类型为：" + thisCards_type);
        //出牌了就直接清除上一轮的牌
        for (int i = 0; i < lastOutCards.Count; i++)
        {
            lastOutCards[i].gameObject.SetActive(false);
        }
        //处理上次出牌
        //lastOutCardsFalse();
        lastOutCards.Clear();
        //出牌，删除两个牌库，一个是手中的牌库，一个是出的牌库
        for (int i = 0; i < thisOutCards.Count; i++)
        {
            lastOutCards.Add(thisOutCards[i]);
            player.playerPokers.Remove(thisOutCards[i]);
        }
        //重置位置
        print(player.playerPokers.Count);
        Cardbox._instanceCardbox.SetCardPos(player.playerPokers);//重置手中牌的位置
        Cardbox._instanceCardbox.SetCardPos(thisOutCards, playPos);//重置出手牌的位置  
    }

    /// <summary>
    /// 自动出牌
    /// </summary>
    public void AI_Auto_Cards()
    {
        Cardbox._instanceCardbox.SortCards(lastOutCards);//理牌
        AI.GetCards(currentUser.playerPokers, lastOutCards, lastCards_type, thisOutCards);
        AI.AutoPlay();
        currentUser.isMyTerm = false;
        SetNextPlayer();
        users[termCurrentIndex].PopCards();
    }

    /// <summary>
    /// 归纳牌库
    /// </summary>
    /// <param name="cards"></param>
    /// <param name="FPos"></param>
    public void SetFPos(List<Card> cards,Transform FPos)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].GetComponent<Transform>().SetParent(FPos);
        }
    }

    /// <summary>
    /// 处理上次出牌
    /// </summary>
    public void lastOutCardsFalse()
    {
        for (int i = 0; i < lastOutCards.Count; i++)
        {
            outCardBox.Add(lastOutCards[i]);
            lastOutCards[i].gameObject.SetActive(false);
        }
        lastOutCards.Clear();
    }

    /// <summary>
    /// 游戏结束
    /// </summary>
    public bool PlayOver()
    {
        if (users[0].playerPokers.Count == 0 || users[1].playerPokers.Count == 0 || users[2].playerPokers.Count == 0)
        {
            GameOver.gameObject.SetActive(true);

            if (player.player_type == PLAYER_TYPE.LANDLORD)
            {
                if (player.playerPokers.Count == 0 )
                {
                    //玩家加40分
                    JsonScript.SetScore(name01.text,40);
                }
                else if (player.playerPokers.Count != 0)
                {
                    //玩家减40分
                    JsonScript.SetScore(name01.text, -40);
                }
            }
            else if (player.player_type == PLAYER_TYPE.FARMERA)
            {
                if (users[2].playerPokers.Count != 0)
                {
                    //玩家加20分
                    JsonScript.SetScore(name01.text, 20);
                }
                else if (users[2].playerPokers.Count == 0)
                {
                    //玩家减20分
                    JsonScript.SetScore(name01.text, -20);
                }
            }

            return true;
        }
        return false;
    }
}

//2021-11-4
//问题1 ： 登录界面，注册完后无法登录
//初步从猜测：数据结构的问题 用到了string,还有数据结构的问题

//2021-11-09
//问题：不点击出牌没有问题，点击出牌，协程回合出现异常---------解决
//回合结束后出牌异常------异常

