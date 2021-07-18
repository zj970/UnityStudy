using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    public List<pig> blocks = new List<pig>();//存放猪集合

    /// <summary>
    /// 进入触发领域
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ENemy")
        {
            blocks.Add(collision.gameObject.GetComponent<pig>());
        }
        
    }

    /// <summary>
    /// 离开触发领域
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ENemy")
        {
            blocks.Remove(collision.gameObject.GetComponent<pig>());
        }

    }
}
