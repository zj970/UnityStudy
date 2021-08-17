using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 中间的提示面板
/// </summary>
public class TipsPanel : MonoBehaviour
{
    public Text txtInfo;
    public static TipsPanel instance;

    private void Awake()
    {
        instance = this;
        HideMe();
    }

    /// <summary>
    /// 显示自己
    /// </summary>
    /// <param name="info"></param>
    public void ShowMe(string info)
    {
        this.gameObject.SetActive(true);
        txtInfo.text = info;
    }

    /// <summary>
    /// 隐藏自己
    /// </summary>
    public void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
