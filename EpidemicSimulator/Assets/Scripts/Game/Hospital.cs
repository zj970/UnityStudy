using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : MonoBehaviour
{
    private int nowBedNum;

    /// <summary>
    /// 初始化医院床位数
    /// </summary>
    /// <param name="num"></param>
    public void InitInfo(int num)
    {
        nowBedNum = num;
    }

    /// <summary>
    /// 添加病人
    /// </summary>
    public bool AddPerson()
    {
        if (nowBedNum > 0)
        {
            --nowBedNum;
            return true;
        }
        return false;
    }
}
