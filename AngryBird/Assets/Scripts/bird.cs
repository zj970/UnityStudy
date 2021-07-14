using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private bool isClick = false;
    public float maxDis = 3f;
    [HideInInspector]
    public SpringJoint2D sp;//隐藏
    private Rigidbody2D rg;

    public Transform rightPos;
    public LineRenderer right;
    public Transform leftPos;
    public LineRenderer left;

    public GameObject boom_bird;

    private TestMyTrail myTrail;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
        myTrail = GetComponent<TestMyTrail>();
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
        rg.isKinematic = false;//脚本物理学失活
        Invoke("Fly", 0.1f);//固定时间执行方法
        //禁用画线组件
        right.enabled = false;
        left.enabled = false;
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
            Line();
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
        myTrail.StartTrails();
        sp.enabled = false;
        Invoke("Next", 5f);
    }
    /// <summary>
    ///画线
    /// </summary>

    void Line()
    {
        right.enabled = true;
        left.enabled = true;

        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);

        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
    }

    /// <summary>
    /// 下一只小鸟的飞出
    /// </summary>
    void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom_bird, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        myTrail.ClearTrails();
    }
}
