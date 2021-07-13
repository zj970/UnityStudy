using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float minSpeed = 5f;
    private SpriteRenderer render;
    public Sprite hurt;//受伤后的图片
    public GameObject boom;//存放特效对像
    public GameObject score;//存放分数对象
    public bool isPig = false;//判定是否为猪

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.relativeVelocity.magnitude);
        //Invoke("Next", 0.5f);
        if (collision.relativeVelocity.magnitude > maxSpeed)//直接死了
        {
            Dead();

        }else if(collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            render.sprite = hurt;
        }
    }
    void Dead()
    {
        if (isPig)
        {
            GameManager._instance.pigs.Remove(this);
        }
        Destroy(gameObject);//清除对象
        Instantiate(boom, transform.position, Quaternion.identity);

        GameObject go = Instantiate(score, transform.position+new Vector3(0,0.65f,0), Quaternion.identity);
        Destroy(go, 1.5f);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //}
}
