using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 一副完整的扑克牌
/// </summary>
public class Cardbox : MonoBehaviour
{
    //静态化单例
    public static Cardbox _instanceCardbox;

    //存放扑克牌
    public List<Card> pokers = new List<Card>();

    //精灵图片
    public Sprite[] cardSprite;

    //预制体
    public GameObject cardPrefabs;

    //位置
    public Transform cardPos;

    List<Card>[] player = new List<Card>[3] { new List<Card>(), new List<Card>(), new List<Card>() };



    private void Start()
    {
        _instanceCardbox = this;//单例
        cardSprite = Resources.LoadAll<Sprite>("Poker");//获得所有精灵图片
        AddCard();//初始化卡牌库
    }

    /// <summary>
    /// 实现发牌
    /// </summary>
    public List<Card>[] Licensing()
    {
        //TODO:发牌
        //TODO: 发牌过程中将牌的图片与点数、类型对应,精灵图片的下标等于 CardIndex * 4 + Card_type;
        //playerPokers[i].GetComponent<Image>().sprite = Cardbox._instanceCardbox.cardSprite[spriteIndex];
        for (int i = 0; i < 17; i++)
        {
            //print(pokers[i * 3]);
            //print(player);

            player[0].Add(pokers[i * 3]);
            player[1].Add(pokers[i * 3 + 1]);
            player[2].Add(pokers[i * 3 + 2]);
        }


        return player;
    }

    /// <summary>
    /// 实现洗牌
    /// </summary>
    public void Shuffle()
    {
        //TODO；洗牌
        int m, n;

        for (int i = 0; i < 1000; i++)
        {
            m = Random.Range(0, 54);
            n = Random.Range(0, 54);
            if (m != n)
            {
                Card card;
                card = pokers[n];
                pokers[n] = pokers[m];
                pokers[m] = card;
            }
        }
    }


    /// <summary>
    /// 初始化卡牌库
    /// </summary>
    private void AddCard()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject obj = Instantiate(cardPrefabs, cardPos);
                var poker = obj.GetComponent<Card>();
                poker.cardIndex = i;//设置牌大小，默认从3-A,即0-12的牌力值
                //设置牌的类型
                switch (j)
                {
                    case 0:
                        poker.card_type = Card.CARD_TYPE.BLOCK;
                        break;
                    case 1:
                        poker.card_type = Card.CARD_TYPE.PLUM_BLOSSOM;
                        break;
                    case 2:
                        poker.card_type = Card.CARD_TYPE.HEART;
                        break;
                    case 3:
                        poker.card_type = Card.CARD_TYPE.SPADE;
                        break;
                    default:
                        break;
                }
                pokers.Add(poker);
            }
        }

        //初始化小王
        GameObject obj1 = Instantiate(cardPrefabs, cardPos);
        var poker1 = obj1.GetComponent<Card>();
        poker1.cardIndex = 13;
        poker1.card_type = Card.CARD_TYPE.SMALL_KING;
        //初始化大王
        GameObject obj2 = Instantiate(cardPrefabs, cardPos);
        var poker2 = obj2.GetComponent<Card>();
        poker2.cardIndex = 14;
        poker2.card_type = Card.CARD_TYPE.KING;

        pokers.Add(poker1);
        pokers.Add(poker2);
    }


    //TODO:排序手里的扑克，按照大王->小王->2->A-->3的顺序，黑桃-->红桃-->梅花-->方块的逆序

    /// <summary>
    /// 理牌 冒泡排序
    /// </summary>
    public List<Card> SortCards(List<Card> cards)
    {
        //理牌 根据Card脚本的索引和类型理牌
        bool isSort = false;//特殊优化
        for (int i = 0; i < cards.Count; i++)//遍历手中所有牌
        {
            //1.首先判断点数大小，如果点数相同就选择第二点
            //2.其次判断类型顺序
            isSort = false;
            int spriteIndex = cards[i].cardIndex * 4 + (int)cards[i].card_type;         
            //从小到大排序 
            for (int j = 0; j < cards.Count - 1 - i; j++)
            {
                //冒泡排序的优化：确定位置的数字就不需要比较了，极值已经到了对应的位置，所以每完成一轮，后面的位置的数加1就不参与比较
                int sortIndex1 = cards[j].cardIndex * 4 + (int)cards[j].card_type;
                int sortIndex2 = cards[j + 1].cardIndex * 4 + (int)cards[j + 1].card_type;
                if (sortIndex1 > sortIndex2)
                {
                    isSort = true;
                    var temporary = cards[j];
                    cards[j] = cards[j + 1];
                    cards[j + 1] = temporary;
                }
            }

            //当一轮结束后 如果isShort这个标识还是false
            //那就意味着，已经是最终的序列，不需要再判断交换了
            if (!isSort)
            {
                return cards;
            }

        }
        return cards;
    }
}
