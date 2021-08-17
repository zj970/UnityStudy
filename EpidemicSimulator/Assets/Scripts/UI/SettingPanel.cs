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
        //重置病毒数据
        ResetInfo();
        //然后在城市里创建人
        if (int.Parse(InputSumN.text)< 0)
        {
            InputSumN.text = "1000";
        }
        City.instance.CreatePerson(int.Parse(InputSumN.text));
    }
    
    /// <summary>
    /// 重置数据 把病毒关键数据设置为输入框里面的内容
    /// </summary>
    private void ResetInfo()
    {
        int num;
        //初始感染人数
        if (int.TryParse(InputInitial.text,out num))
        {
            Virus.INFECTION_NUM = (num <= 0 || num > int.Parse(InputSumN.text)) ? Virus.INFECTION_NUM : num;
            InputInitial.text = Virus.INFECTION_NUM.ToString();
        }
        else
        {
            InputInitial.text = Virus.INFECTION_NUM.ToString();
        }
        //传播率
        if (int.TryParse(SpreadingRate.text, out num))
        {
            Virus.TRANSMISSION_RATE = (num <0||num >= 100) ? Virus.TRANSMISSION_RATE : num;
            SpreadingRate.text = Virus.TRANSMISSION_RATE.ToString();
        }
        else
        {
            SpreadingRate.text = Virus.TRANSMISSION_RATE.ToString();
        }
        //Virus.TRANSMISSION_RATE = int.Parse(SpreadingRate.text);

        //潜伏时间
        if (int.TryParse(LatentTime.text, out num))
        {
            Virus.HIDE_TIME = num <0 ? Virus.HIDE_TIME : num;
            LatentTime.text = Virus.HIDE_TIME.ToString();
        }
        else
        {
            LatentTime.text = Virus.HIDE_TIME.ToString();
        }
        //Virus.HIDE_TIME = int.Parse(LatentTime.text);

        //医院床位
        if (int.TryParse(HospitalBed.text, out num))
        {
            Virus.HOSPITAL_BED_NUM = num < 0  ? Virus.HOSPITAL_BED_NUM : num;
            HospitalBed.text = Virus.HOSPITAL_BED_NUM.ToString();
        }
        else
        {
            HospitalBed.text = Virus.HOSPITAL_BED_NUM.ToString();
        }
        //Virus.HOSPITAL_BED_NUM = int.Parse(HospitalBed.text);

        //医院收治响应时间
        if (int.TryParse(TherapyTime.text, out num))
        {
            Virus.HOSPITAL_TIME = num < 0 ? Virus.HOSPITAL_TIME : num;
            TherapyTime.text = Virus.HOSPITAL_TIME.ToString();
        }
        else
        {
            TherapyTime.text = Virus.HOSPITAL_TIME.ToString();
        }
        //Virus.HOSPITAL_TIME = int.Parse(TherapyTime.text);

        //流动意向
        if (int.TryParse(OutRate.text, out num))
        {
            Virus.MOVE_INTENTION = num < 0 || num > 100 ? Virus.MOVE_INTENTION : num;
            OutRate.text = Virus.MOVE_INTENTION.ToString();
        }
        else
        {
            OutRate.text = Virus.MOVE_INTENTION.ToString();
        }
        //Virus.MOVE_INTENTION = int.Parse(OutRate.text);
    }
}
