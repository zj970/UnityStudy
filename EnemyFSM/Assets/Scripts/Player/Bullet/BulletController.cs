using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;//子弹移动速度
    public float range = 10f;//射程
    private Vector3 lastPosition;
    private void Awake()
    { 
        lastPosition = transform.position;     
    }
    public void Move()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);//移动
        float dis = (transform.position - lastPosition).sqrMagnitude;
        dis = Mathf.Sqrt(dis);
        if (dis > range)
        {
            this.gameObject.SetActive(false);
        }
    }
}
