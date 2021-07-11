   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 veiocity;
    Rigidbody myRigidbody;//定义一个刚体变量
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(Vector3 _velocity)
    {
        veiocity = _velocity;//controller.Move(moveVelocity);将moveVelocity的值赋给veiocity
        //问题：veiocity的值能否外部引用，以及它的作用范围（veiocity的生命周期是整个PlayerController）
    }
    // 固定更新方法，和物理相关的操作代码，都要写在此方法中。固定更新的时间是0.02s，1秒执行50次，可在Edit--->Project Settings--->Time面板中的Fixed Timestep查看。
    void FixedUpdate()
    {
        //Debug.Log("This veicoty is :" + veiocity);
        myRigidbody.MovePosition(myRigidbody.position + veiocity * Time.fixedDeltaTime);//更新刚体的位置
    }
    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        //Debug.Log("This heigthCorrectedPoint is "+heightCorrectedPoint);
        //transform.LookAt(lookPoint);//Rotation.x,y值变换/Position.x,y,z都变化
        transform.LookAt(heightCorrectedPoint);//旋转转换，使前向量点位于世界位置。(Position.y值不变，x ,z值跟随鼠标变换\Rotation.y值变化)
        //问题：为什么同时改变了位置参数和旋转参数
        //传入的参数位置Position.y值改变了力的作用。从而导致位置其他参数会发生变化
    }
}
