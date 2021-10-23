using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatGround : GameManager
{
    private Plane[] planes;
    private Bounds bounds;


    private void Start()
    {
        bounds = this.GetComponent<Collider>().bounds;
    }

    private void Update()
    {
        print(mainCamera);
        if (IsVisible())
        {
            print("物体在视锥体里");
            this.gameObject.SetActive(true);
        }
        else
        {
            print("物体没有在视锥体里");
            this.gameObject.SetActive(false);
        }
    }

     /// <summary>
     /// 判断物体是否在近裁剪面与远裁剪面之中（渲染四棱锥中）
     /// </summary>
     /// <returns></returns>
     /// 
     
      //1.移动物体本身不会产生判断
      //2.移动摄像机会产生判断
      //3.当挂载物体失效后，也不会再判断

     bool IsVisible()
    {
        //得到摄像机的六个面
        planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        //判断边框bounds是否在六个面内
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}
