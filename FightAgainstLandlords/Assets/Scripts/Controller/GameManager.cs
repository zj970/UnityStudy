using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* 2021-11-3 发牌，洗牌, 排序测试
     * 
     *
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
        farmerA.SortCards();
        farmerB.SortCards();
        landlord.SortCards();

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
    public User play0;
    public User play1;
    public User play2;

    //TODO:出牌规则
    //TODO:出牌时防止玩家乱出，出的牌一定要排序！


}
