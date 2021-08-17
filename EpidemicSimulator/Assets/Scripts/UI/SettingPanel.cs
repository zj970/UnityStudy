using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 设置面板
/// </summary>
public class SettingPanel : MonoBehaviour
{
    public InputField InputSumN;//总人数
    public InputField InputInitial;//初始感染人数
    public InputField SpreadingRate;//传播率
    public InputField LatentTime;//潜伏时间
    public InputField HospitalBed;//医院床位
    public InputField TherapyTime;//医院收治时间
    public InputField OutRate;//流动意向
    public Button Begin;

    public static SettingPanel instance;
    private void Awake()
    {
        instance = this;
        Begin.onClick.AddListener(ClickBegin);//增加点击事件
    }

    public void ClickBegin()
    {
        Debug.Log("123");
        //重置病毒数据
        ResetInfo();
        //然后在城市里创建人
        City.instance.CreatePerson(int.Parse(InputSumN.text));
    }

    /// <summary>
    /// 重置数据 把病毒关键数据设置为输入框里面的内容
    /// </summary>
    private void ResetInfo()
    {
        Virus.INFECTION_NUM = int.Parse(InputInitial.text);
        Virus.TRANSMISSION_RATE = int.Parse(SpreadingRate.text);
        Virus.HIDE_TIME = int.Parse(LatentTime.text);
        Virus.HOSPITAL_BED_NUM = int.Parse(HospitalBed.text);
        Virus.HOSPITAL_TIME = int.Parse(TherapyTime.text);
        Virus.MOVE_INTENTION = int.Parse(OutRate.text);
    }
}
