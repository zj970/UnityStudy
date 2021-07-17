using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxSpeed = 10f;//速度决定血量
    public float minSpeed = 5f;
    private SpriteRenderer render;
    public Sprite hurt;//受伤后的图片
    public GameObject boom;//存放特效对像
    public GameObject score;//存放分数对象
    public bool isPig = false;//判定是否为猪

    public AudioClip hurtCollision;//存储声音
    public AudioClip dead;
    public AudioClip birdCollision;
    //public bool isBlock = false;//判定是否为木块

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();//开始就获取
    }

    private void OnCollisionEnter2D(Collision2D collision)//两个刚体之间的接触就调用
    {
        //print(collision.relativeVelocity.magnitude);
        //Invoke("Next", 0.5f);

        if (collision.gameObject.tag == "Player")
        {
            AudioPlay(birdCollision);
        }

        if (collision.relativeVelocity.magnitude > maxSpeed)//直接死了
        {
            Dead();

        }else if(collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            render.sprite = hurt;//切换成受伤的图片
            AudioPlay(hurtCollision);
        }
    }
    
    /// <summary>
    /// 处理猪死亡
    /// </summary>
    void Dead()
    {
        if (isPig)
        {
            GameManager._instance.pigs.Remove(this);
        }
        Destroy(gameObject);//清除对象
        Instantiate(boom, transform.position, Quaternion.identity);

        AudioPlay(dead);

        GameObject go = Instantiate(score, transform.position+new Vector3(0,0.65f,0), Quaternion.identity);//显示分数
        Destroy(go, 1.5f);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //}
    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
