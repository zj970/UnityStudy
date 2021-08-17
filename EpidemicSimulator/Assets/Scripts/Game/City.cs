using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 城市类
/// </summary>
public class City : Space
{

    //城市里的人
    public List<Person> persons = new List<Person>();
    //城市里的医院
    public Hospital hospital;
    public static City instance;
    public static bool isBegin = false;
    private int nowInfectionNum = 0;

    private void Awake()
    {
        instance = this;
        centerX = -100;
        centerY = 0;
        w = 600;
        h = 600;
    }

    public void CreatePerson(int num)
    {
        StartCoroutine(BeginCreate(num));
    }

    /// <summary>
    /// 用协程来创建对象的目的 是为了防止批量创建过多对象时 卡顿
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public IEnumerator BeginCreate(int num)
    {
        TipsPanel.instance.ShowMe("数据生成中......");
        hospital.InitInfo(Virus.HOSPITAL_BED_NUM);//生成医院床位
        yield return 0;//等待一帧
        //清空
        nowInfectionNum = 0;
        for (int i = 0; i < persons.Count; i++)
        {
            Destroy(persons[i].gameObject);
            if (i % 200 == 0)
            {
                yield return 0;
            }
        }
        persons.Clear();
        //创建人
        for (int i = 0; i < num; i++)
        {
            //创建人的预设体 设置为city 对象的子对象
            GameObject obj = Instantiate(Resources.Load<GameObject>("Person"));
            obj.transform.parent = this.transform;
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;

            //记录创建出来的人
            Person p = obj.GetComponent<Person>();
            p.ChangeType(E_Person_Type.Healthy);
            p.ChangeSpace(this);
            persons.Add(p);


            //创建出来的前n个人患病
            if (nowInfectionNum < Virus.INFECTION_NUM)
            {
                ++nowInfectionNum;
                p.ChangeType(E_Person_Type.Burst);
            }
            if (i % 200 ==0)
            {
                yield return 0;
            }
        }
        TipsPanel.instance.ShowMe("模拟将在3秒后开始");
        yield return new WaitForSeconds(1f);
        TipsPanel.instance.ShowMe("模拟将在2秒后开始");
        yield return new WaitForSeconds(1f);
        TipsPanel.instance.ShowMe("模拟将在1秒后开始");
        yield return new WaitForSeconds(1f);
        TipsPanel.instance.ShowMe("开始");
        InfoPanel.instance.InitPanel(num);
        yield return new WaitForSeconds(1f);
        TipsPanel.instance.HideMe();
        isBegin = true;
    }

}
