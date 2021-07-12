using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float minSpeed = 5f;
    private SpriteRenderer render;
    public Sprite hurt;//受伤后的图片
    public GameObject boom;
    public GameObject score;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.relativeVelocity.magnitude);
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
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);

        GameObject go = Instantiate(score, transform.position+new Vector3(0,0.65f,0), Quaternion.identity);
        Destroy(go, 1.5f);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //}
}
