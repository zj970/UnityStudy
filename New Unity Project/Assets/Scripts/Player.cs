using UnityEngine;

[RequireComponent(typeof (PlayerController))]//为Player组件添加PlayerController.cs脚本
[RequireComponent (typeof(GunController))]
public class Player : LivingEnity
{
    public float moveSpeed = 5;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
        controller = this.GetComponent<PlayerController>();
        gunController = this.GetComponent<GunController>();//找到身上组件
        viewCamera = Camera.main;//找到相机MainCamera
    }
    
    // Update is called once per frame
    void Update()
    {
        //Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));//定义一个三维向量的变量moveInput，GetAxis做平滑处理，GetAxisRaw不做平滑处理，两者都是返回由轴名识别的虚拟轴值
        //Debug.Log("This moveInput is :"+moveInput);
        Vector3 moveVelocity = moveInput.normalized * moveSpeed; //moveInput.normalized返回一个向量值为1与浮点数moveSpeed相乘赋给三维向量变量moveVelocity
        controller.Move(moveVelocity);//调用另外一个C#即PlayerController.cs里面的Move方法并传入moveVelocity作为形参的值

        //Look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);//定义Raw的结构体变量ray两个三维的Vextor3
        Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
        //Debug.Log("This groundPlne is "+groundPlane);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);//沿着射线返回距离单位的一个点。
            //Debug.Log("This point is "+point);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }
        //Weapon input
        if (Input.GetMouseButton(0))//参数为int,表示左键,1表示右键,2表示滚轮
        {
            gunController.Shoot();
        }
    }
}
