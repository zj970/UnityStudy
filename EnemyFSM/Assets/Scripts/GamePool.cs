using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePool : MonoBehaviour
{



    public static GamePool GamePoolInstance; //对象池单例
    public GameObject poolObj; //池中的perfabs
    public int pooledAmount = 5; //对象池的初始化大小
    public bool lockPoolSize = false;//是否锁定对象池大小
    public List<GameObject> pooledObjects; //对象池链表
    private int currentIndex = 0;//当前指向链表位置索引
    public Transform poolManager;

    private void Awake()
    {
        GamePoolInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();//初始化链表
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(poolObj);//创建预制体对象
            obj.transform.SetParent(poolManager,false);
            pooledObjects.Add(obj);//将预制体添加到链表（对象池）中
        }
    }

    /// <summary>
    /// 获取对象池中可以使用的预制体
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
                return pooledObjects[temI];//找到没有被激活的对象并返回
            }
        }
        //如果遍历完一遍对象库发现没有可以用的，执行
        if (!lockPoolSize)
        {
            //如果没有锁定对象池大小，创建预制体并添加到对象池-----意味着增大对象池
            GameObject obj = Instantiate(poolObj);
            obj.transform.SetParent(poolManager);
            //obj.SetActive(false);//设置对象无效
            pooledObjects.Add(obj);
            return obj;

        }
        //如果遍历完发现没有而且锁定了对象池大小，返回空
        return null;
    }
}


