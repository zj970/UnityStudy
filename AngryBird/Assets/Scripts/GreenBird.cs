using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBird : Bird
{
    public override void ShowSkill()
    {
        base.ShowSkill();
        Vector3 speed = rg.velocity;//获取速度
        speed.x *= -1;//利用相反速度添加鼠标左键回旋效果
        rg.velocity = speed;//赋值给绿鸟速度
    }
}
