using System;
using UnityEngine;

public class Class1 ：MonoBehaviour
{
    //获取子物体
    this.transform.Find("<name>");//根据名字找，能找到失活的物体

    //丢父
    this.transform.parent = null;
    this.transform.SetParent(null);
    //认父
    this.transform.parent = GameObject.Find("<name>").transform;
    this.transform.SetParent(GameObject.Find("<name>").transform);

    //如何获取子物体下的子物体
    //利用的是gameObject.GetComponentsInChildren<>();
    void Start()
    {
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            //Debug.Log(children[i].name);
            children[i].SetParent(null);
            //失效子物体
            //LiaoWangTai.gameObject.transform.DetachChildren();
            //Destroy(children[i], 0.5f);

        }

    }
