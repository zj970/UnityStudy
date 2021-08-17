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

    private void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// 设置面板显示的健康的人数
    /// </summary>
    /// <param name="num"></param>
    public void SetJKNum(int num)
    {
        JKNumber.text = num + "人";
    }
    /// <summary>
    /// 设置面板显示的潜伏的人数
    /// </summary>
    /// <param name="num"></param>
    public void SetQFNum(int num)
    {
        QFNumber.text = num + "人";
    }
    /// <summary>
    /// 设置面板显示的爆发的人数
    /// </summary>
    /// <param name="num"></param>
    public void SetBFNum(int num)
    {
        BFNumber.text = num + "人";
    }
    /// <summary>
    /// 设置面板显示的医院的床位
    /// </summary>
    /// <param name="num"></param>
    public void SetHospitalBed(int num)
    {
        HospitalBed.text = num + "/" + num;
    }
}
