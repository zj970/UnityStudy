using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{

    /// <summary>
    /// /动画播放完，显示星星
    /// </summary>
    public void ShowDo()
    {
        GameManager._instance.ShowStart();
    }
}
