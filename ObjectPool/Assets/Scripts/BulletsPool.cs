using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    public static BulletsPool BulletsPoolInstance; //子弹池单例
    public GameObject bulletObj; //子弹perfabs
    public int pooledAmount = 5; //子弹池的初始化大小
    public bool lockPoolSize = false;//是否锁定子弹池大小
    public List<GameObject> pooledObjects; //子弹池链表
    private int currentIndex = 0;//当前指向链表位置索引

    private void Awake()
    {
        BulletsPoolInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();//初始化链表
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(bulletObj);//创建子弹对象
            obj.SetActive(false);//设置对象无效
            pooledObjects.Add(obj);//将子弹添加到链表（对象池）中
        }
    }

    /// <summary>
    /// 获取对象池中可以使用的子弹
    /// </summary>
    /// <returns></returns>
    public virtual GameObject GetPooledObject()
    {
        //遍历对象池一遍
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //贪心算法：每次便利都是从上一个被使用过的对象的下一个开始遍历
            int temI = (currentIndex + i) % pooledObjects.Count;
            //判断该子弹是否在场景中激活
            if (!pooledObjects[temI].activeInHierarchy)
            {
                currentIndex = (temI + 1) % pooledObjects.Count;
                return pooledObjects[temI];//找到没有被激活的子弹并返回
            }
        }
        //如果遍历完一遍子弹库发现没有可以用的，执行
        if (!lockPoolSize)
        {
            //如果没有锁定对象池大小，创建子弹并添加到对象池-----意味着增大对象池
            GameObject obj = Instantiate(bulletObj);
            //obj.SetActive(false);//设置对象无效
            pooledObjects.Add(obj);
            return obj;

        }
        //如果遍历完发现没有而且锁定了对象池大小，返回空
        return null;
    }
}
