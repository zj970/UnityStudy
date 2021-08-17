using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 人的状态
/// </summary>
public enum E_Person_Type
{
    /// <summary>
    /// 健康
    /// </summary>
    Healthy,
    /// <summary>
    /// 潜伏
    /// </summary>
    Hide,
    /// <summary>
    /// 爆发
    /// </summary>
    Burst,
    /// <summary>
    /// 住院
    /// </summary>
    Hospital
}


/// <summary>
/// 人的逻辑
/// </summary>
public class Person : MonoBehaviour
{
    private static int RandomMoveTime = 60;//节省空间
    private static int CheckInfection = 2;//节省空间
    //当前人的状态
    E_Person_Type personType;
    //当前人所在的空间
    Space mySpace;
    private Vector3 moveDir;
    //可以移动的方向 结构体
    private List<Vector3> dirs = new List<Vector3>()
    {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right
    };

    private Image image;
    private int nowMoveTime = 0;//当前随机移动时间
    private int nowCheckInfectionTime = 0;//传染检测计时器
    private int checkInHospital = 0;//住院的计时器
    private int nowHideTime = 0;//潜伏剩余时间


    private void Awake()
    {
        image = this.GetComponent<Image>();
    }

    /// <summary>
    /// 人改变状态
    /// </summary>
    /// <param name="type"></param>
    public void ChangeType(E_Person_Type type)
    {
        if (personType == type)
        {
            return;//防止协程造成数据混乱
        }
        switch (type)
        {
            case E_Person_Type.Healthy:
                image.color = Color.white;
                break;
            case E_Person_Type.Hide:
                if (personType == E_Person_Type.Healthy)
                {
                    InfoPanel.instance.ChangeJKNum();//减健康
                }
                InfoPanel.instance.ChangeQFNum();//加一个潜伏
                image.color = Color.yellow;
                break;
            case E_Person_Type.Burst:
                if (personType == E_Person_Type.Healthy)
                {
                    InfoPanel.instance.ChangeJKNum();//减健康
                }
                else if (personType == E_Person_Type.Hide)
                {
                    InfoPanel.instance.ChangeQFNum(false);//减少潜伏
                }
                InfoPanel.instance.ChangeBFNum();//加一个潜伏
                image.color = Color.red;
                break;
            case E_Person_Type.Hospital:
                InfoPanel.instance.ChangeBFNum(false);//加一个潜伏
                InfoPanel.instance.ChangeSetHospitalBed();//减
                image.color = Color.green;
                break;
            default:
                break;
        }
        personType = type;
    }

    /// <summary>
    /// 人改变位置
    /// </summary>
    /// <param name="space"></param>
    public void ChangeSpace(Space space)
    {
        mySpace = space;

        //随机位置
        this.transform.localPosition = new Vector3(space.centerX - space.w / 2 + Random.Range(0, space.w), space.centerY - space.h / 2 + Random.Range(0, space.h), 0);

        //随机移动方向
        RandomMove();
    }

    //随机移动
    public void RandomMove()
    {
        //取出随机方向放回列表
        if (moveDir != Vector3.zero)
        {
            dirs.Add(moveDir);
        }
        //进行范围判断
        if (this.transform.localPosition.x <= mySpace.centerX - mySpace.w / 2)
        {
            //如果超出左范围 强制让它向右移动
            moveDir = Vector3.right;
            dirs.Remove(moveDir);
        }
        else if (this.transform.localPosition.x >= mySpace.centerX + mySpace.w / 2)
        {
            //如果超出右范围 强制让它向左移动
            moveDir = Vector3.left;
            dirs.Remove(moveDir);
        }
        else if (this.transform.localPosition.y >= mySpace.centerY + mySpace.h / 2)
        {
            //如果超出上范围 强制让它向下移动
            moveDir = Vector3.down;
            dirs.Remove(moveDir);
        }
        else if (this.transform.localPosition.y <= mySpace.centerY - mySpace.h / 2)
        {
            //如果超出下范围 强制让它向上移动
            moveDir = Vector3.up;
            dirs.Remove(moveDir);
        }
        else
        {
            int index = Random.Range(0, dirs.Count);
            moveDir = dirs[index];
            dirs.RemoveAt(index);
        }


    }
    //传染
    public IEnumerator Infection()
    {
        //是城市 才传染别人
        if (mySpace is City)//里氏替换原则
        {
            City city = mySpace as City;
            float rate = Virus.TRANSMISSION_RATE / 100f * Virus.MOVE_INTENTION / 100f;//传播概率

            for (int i = 0; i < city.persons.Count; i++)
            {
                //传染健康的人&&小于一定范围

                if (city.persons[i].personType == E_Person_Type.Healthy && Vector3.Distance(this.transform.localPosition, city.persons[i].transform.localPosition) < 20 && Random.Range(0, 1f) < rate)
                {
                    if (Virus.HIDE_TIME > 0)
                    {
                        //染病潜伏
                        city.persons[i].ChangeType(E_Person_Type.Hide);
                        city.persons[i].nowHideTime = Virus.HIDE_TIME;
                    }
                    else
                    {
                        //染病爆发
                        city.persons[i].ChangeType(E_Person_Type.Burst);
                    }

                }
                if (i % (city.persons.Count/ CheckInfection) == 0)
                {
                    yield return 0;
                }
            }
        }
    }


    //定时更新
    private void Update()
    {
        if (!City.isBegin)
        {
            return;
        }

        this.transform.Translate(moveDir * Time.deltaTime * 20);
        //定时检测改变移动方向
        ++nowMoveTime;
        if (nowMoveTime > RandomMoveTime)
        {
            nowMoveTime = 0;
            RandomMove();
        }

        //定时检测传染 当人的状态是爆发，潜藏的时候
        if (personType == E_Person_Type.Burst || personType == E_Person_Type.Hide)
        {
            ++nowCheckInfectionTime;
            if (nowCheckInfectionTime > CheckInfection)
            {
                nowCheckInfectionTime = 0;
                //Infection();
                StartCoroutine(Infection());
            }
        }

        //处于爆发期的病人 我们要检测 什么时候 送她进医院
        if (personType == E_Person_Type.Burst)
        {
            ++checkInHospital;
            if (checkInHospital >= Virus.HOSPITAL_TIME)
            {
                //住院成功
                if ((mySpace as City).hospital.AddPerson())
                {
                    //放到医院，改变状态
                    ChangeType(E_Person_Type.Hospital);
                    ChangeSpace((mySpace as City).hospital);
                }
            }
        }
        else if (personType == E_Person_Type.Hide)
        {
            --nowHideTime;
            if (nowHideTime<0)
            {
                ChangeType(E_Person_Type.Burst);
            }
        }
    }

}
