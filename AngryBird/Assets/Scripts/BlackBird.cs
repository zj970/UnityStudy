using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    public List<Pig> blocks = new List<Pig>();//存放猪集合

    /// <summary>
    /// 进入触发领域
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            blocks.Add(collision.gameObject.GetComponent<Pig>());
        }
        
    }

    /// <summary>
    /// 离开触发领域
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            blocks.Remove(collision.gameObject.GetComponent<Pig>());
        }

    }

    public override void ShowSkill()
    {
        base.ShowSkill();
        if (blocks.Count > 0 && blocks != null)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Dead();
            }
        }
        OnClear();
    }

    void OnClear()
    {
        rg.velocity = Vector3.zero;
        Instantiate(boom_bird, transform.position, Quaternion.identity);//播放特效
        birdRender.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;//禁用CircleCollider2D
        myTrail.ClearTrails();//清除拖尾
    }
    protected override void Next()
    {
        base.Next();
        GameManager._instance.birds.Remove(this);//移除当前的小鸟
        Destroy(gameObject);//失活小鸟
        //Instantiate(boom_bird, transform.position, Quaternion.identity);//播放
        GameManager._instance.NextBird();//下一只鸟的逻辑
    }
}
