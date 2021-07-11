using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private bool isClick = false;
    public Transform rightPos;
    public float maxDis = 3f;
    private SpringJoint2D sp;
    private Rigidbody2D rg;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
    }

    //鼠标按下
    private void OnMouseDown()
    {
        isClick = true;
        rg.isKinematic = true;
    }

    //鼠标抬起
    private void OnMouseUp()
    {
        isClick = false;
        rg.isKinematic = false;
        Invoke("Fly", 0.1f);
        
    }
    private void Update()
    {
        if (isClick)//鼠标一直按下，进行位置的跟随
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position = new Vector3(0, 0, 10);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);
            if (Vector3.Distance(transform.position,rightPos.position) > maxDis)//进行位置限定
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;//单位化：向量方向保持不变，长度为1
                pos *= maxDis;//最大长度的向量
                transform.position = pos + rightPos.position;//赋给小鸟的位置
            }
        }
        //如果鼠标左键按住不放时
        //if (Input.GetMouseButton(0))
        //{
        //    this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    this.transform.position = new Vector3(0, 0, 10);
        //}
    }
    void Fly()
    {
        sp.enabled = false;
    }
}
