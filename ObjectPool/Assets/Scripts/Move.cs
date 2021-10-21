using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;//子弹移动速度
    public float range = 10f;//射程
    private Vector3 offset;
    private void Awake()
    {
        offset = new Vector3(this.transform.position.x + range, this.transform.position.y, this.transform.position.z);
    }
    private void Update()
    {
        this.transform.Translate(Vector3.back * speed * Time.deltaTime);//移动
        Debug.Log(transform.position.x);
        if (this.transform.position.x > offset.x)
        {
            this.gameObject.SetActive(false);
        }
    }

}
