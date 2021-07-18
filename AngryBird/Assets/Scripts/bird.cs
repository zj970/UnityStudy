using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isClick = false;//定义一个鼠标是否按下的布尔值，按下为真，抬起为假
    public float maxDis = 3f;//定义弹绳的长度
    [HideInInspector]
    public SpringJoint2D sp;//隐藏SpringJoint2D
    protected Rigidbody2D rg;//定义一个刚体，用于

    public Transform rightPos;//定义右边的位置变化
    public LineRenderer right;//画线右边
    public Transform leftPos;//定义左边的位置变化
    public LineRenderer left;//画线左边

    public GameObject boom_bird;//定义一个GameObject对象，储存动画播放

    public Sprite birdHurt;//添加小鸟受伤图片
    protected SpriteRenderer birdRender;

    protected TestMyTrail myTrail;//实例化，引用StartTrails()方法，实现拖尾

    private bool canMove = true;//用于防止小鸟飞出去后还回到弹弓上

    public float smooth = 3f;//Lerp平滑度

    public AudioClip select;//播放音效
    public AudioClip fly;

    //
    private bool isFly = false;

   

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
        myTrail = GetComponent<TestMyTrail>();
        birdRender = GetComponent<SpriteRenderer>();
    }

    //鼠标按下
    private void OnMouseDown()
    {
        if (canMove)//用于防止小鸟飞出去后还回到弹弓上
        {
            AudioPlay(select);
            isClick = true;
            rg.isKinematic = true;
        }
      
    }

    //鼠标抬起
    private void OnMouseUp()
    {
        if(canMove)//用于防止小鸟飞出去后还回到弹弓上
        {
            isClick = false;
            rg.isKinematic = false;//脚本物理学失活
            Invoke("Fly", 0.1f);//固定时间执行方法
                                //禁用画线组件
            right.enabled = false;
            left.enabled = false;
            canMove = false;
        }
       
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

        //相机跟随
        float posX = transform.position.x;//只需要改变相机的X值
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(Mathf.Clamp(posX, 0, 15), Camera.main.transform.position.y, Camera.main.transform.position.z),smooth*Time.deltaTime);//Lerp平滑移动

        if (isFly)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShowSkill();
            }
        }

        //如果鼠标左键按住不放时
        //if (Input.GetMouseButton(0))
        //{
        //    this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    this.transform.position = new Vector3(0, 0, 10);
        //}
    }

    /// <summary>
    /// 小鸟飞行方法
    /// </summary>
    void Fly()
    {
        isFly = true;
        AudioPlay(fly);
        myTrail.StartTrails();//开始拖尾
        sp.enabled = false;//释放弹力
        Invoke("Next", 5f);
    }
    /// <summary>
    ///画线
    /// </summary>

    void Line()
    {
        right.enabled = true;//激活
        left.enabled = true;
        //两点确定一条直线
        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);

        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
    }

    /// <summary>
    /// 下一只小鸟的飞出
    /// </summary>
    protected virtual void Next()
    {
        GameManager._instance.birds.Remove(this);//移除当前的小鸟
        Destroy(gameObject);//失活小鸟
        Instantiate(boom_bird, transform.position, Quaternion.identity);//播放
        GameManager._instance.NextBird();//下一只鸟的逻辑
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFly = false;
        myTrail.ClearTrails();//清除拖尾
        //BirdHurt();
        

    }

    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    /// <summary>
    /// 炫技操作
    /// </summary>
    public  virtual void ShowSkill()//改成虚方法
    {
        isFly = false;
    }

    public void BirdHurt()
    {
        birdRender.sprite = birdHurt;
    }
}
