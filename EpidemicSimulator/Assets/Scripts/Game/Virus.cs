using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 病毒类 只有关键数据
/// </summary>
public class Virus
{
    public static int INFECTION_NUM = 5;//初始感染人数
    public static int TRANSMISSION_RATE = 50;//传播率
    public static int HIDE_TIME = 60;//潜伏时间
    public static int HOSPITAL_BED_NUM = 200;//医院床位
    public static int HOSPITAL_TIME = 100;//医院收治响应时间
    public static int MOVE_INTENTION = 100;//流动意向
}
