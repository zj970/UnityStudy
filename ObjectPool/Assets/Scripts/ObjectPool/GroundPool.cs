using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPool : MonoBehaviour
{
    public static GroundPool groundPoolInstance;//对象池的单例
    public GameObject groundObj;//单一地形的perfabs
    public int pooledAmount = 10;//地形池初始化大小
    public bool lockPoolSize = false;

    private List<GameObject> pooledObjects;//地形池链表
    private int currentIndex = 0; //当前指向链表位置索引


    private void Awake()
    {
        groundPoolInstance = this;//实例化本对象
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();//初始化链表
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(groundObj);
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + i * 100);//铺满相机视锥体范围
            //obj.SetActive(false);
            pooledObjects.Add(obj);//添加到链表里面
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            int temI = (currentIndex + i) % pooledObjects.Count;

            if (!pooledObjects[temI].activeInHierarchy)
            {
                currentIndex = (temI + 1) % pooledObjects.Count;
                return pooledObjects[temI];
            }

            if (!lockPoolSize)
            {
                GameObject obj = Instantiate(groundObj);
                pooledObjects.Add(obj);
                return obj;
            }
        }

        return null;
    }
}

