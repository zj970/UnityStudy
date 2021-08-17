using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 当前数据面板
/// </summary>
public class InfoPanel : MonoBehaviour
{
    public Text JKNumber;
    public Text QFNumber;
    public Text BFNumber;
    public Text HospitalBed;

    public static InfoPanel instance;

    private int nowJKNumber;
    private int nowQFNumber;
    private int nowBFNumber;
    private int nowHospitalBed;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 初始化面板
    /// </summary>
    /// <param name="num"></param>
    public void InitPanel(int num)
    {
        //健康人数
        SetJKNum(num-Virus.INFECTION_NUM);
        //设置患病者
        SetBFNum(Virus.INFECTION_NUM);
        //潜伏者
        SetQFNum(0);
        //医院床位
        SetHospitalBed(Virus.HOSPITAL_BED_NUM);

    }

    /// <summary>
    /// 改变健康人数
    /// </summary>
    /// <param name="isAdd"></param>
    public void ChangeJKNum(bool isAdd = false)
    {
        nowJKNumber += isAdd ? 1 : -1;
        SetJKNum(nowJKNumber);
    }


    /// <summary>
    /// 改变潜伏人数
    /// </summary>
    /// <param name="isAdd"></param>
    public void ChangeQFNum(bool isAdd = true)
    {
        nowQFNumber += isAdd ? 1 : -1;
        SetQFNum(nowQFNumber);
    }

    /// <summary>
    /// 改变潜伏人数
    /// </summary>
    /// <param name="isAdd"></param>
    public void ChangeBFNum(bool isAdd = true)
    {
        nowBFNumber += isAdd ? 1 : -1;
        SetBFNum(nowBFNumber);
    }

    /// <summary>
    /// 改变潜伏人数
    /// </summary>
    /// <param name="isAdd"></param>
    public void ChangeSetHospitalBed(bool isAdd = false)
    {
        nowHospitalBed += isAdd ? 1 : -1;
        SetHospitalBed(nowHospitalBed);
    }

    /// <summary>
    /// 设置面板显示的健康的人数
    /// </summary>
    /// <param name="num"></param>
    public void SetJKNum(int num)
    {
        JKNumber.text = num + "人";
        nowJKNumber = num;
    }
    /// <summary>
    /// 设置面板显示的潜伏的人数
    /// </summary>
    /// <param name="num"></param>
    public void SetQFNum(int num)
    {
        QFNumber.text = num + "人";
        nowQFNumber = num;
    }
    /// <summary>
    /// 设置面板显示的爆发的人数
    /// </summary>
    /// <param name="num"></param>
    public void SetBFNum(int num)
    {
        BFNumber.text = num + "人";
        nowBFNumber = num;
    }
    /// <summary>
    /// 设置面板显示的医院的床位
    /// </summary>
    /// <param name="num"></param>
    public void SetHospitalBed(int num)
    {
        HospitalBed.text = num + "/" +Virus.HOSPITAL_BED_NUM;
        nowHospitalBed = num;

    }
}
