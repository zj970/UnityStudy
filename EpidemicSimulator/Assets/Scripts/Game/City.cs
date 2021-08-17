using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 城市类
/// </summary>
public class City : MonoBehaviour
{

    //城市里的人
    public List<Person> persons = new List<Person>();
    //城市里的医院
    public Hospital Hospital;
    public static City instance;

    private void Awake()
    {
        instance = this;
    }

    public void CreatePerson(int num)
    {
        BeginCreate(num);
    }

    /// <summary>
    /// 用协程来创建对象的目的 是为了防止批量创建过多对象时 卡顿
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public IEnumerator BeginCreate(int num)
    {
        TipsPanel.instance.ShowMe("数据生成中......");
        yield return 0;//等待一帧
        //清空
        for (int i = 0; i < persons.Count; i++)
        {
            Destroy(persons[i]);
            if (i % 200 == 0)
            {
                yield return 0;
            }
        }
        //创建人
        for (int i = 0; i < num; i++)
        {
            //创建人的预设体 设置为city 对象的子对象
            GameObject obj = Instantiate(Resources.Load<GameObject>("Person"));
            obj.transform.parent = this.transform;
            obj.transform.localScale = Vector3.zero;
            obj.transform.localPosition = Vector3.zero;

            //记录创建出来的人
            Person p = obj.GetComponent<Person>();
            persons.Add(p);
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
        yield return new WaitForSeconds(1f);
        TipsPanel.instance.HideMe();
    }

}
