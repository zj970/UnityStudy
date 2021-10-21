using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPool : MonoBehaviour
{
    public Camera camera;
    private Plane[] planes;
    private Bounds bounds;

    private void Awake()
    {
        bounds = this.GetComponent<Collider>().bounds;
    }

    private void Update()
    {
        print(IsVisible());
    }

    /// <summary>
    /// 判断物体是否在近裁剪面与远裁剪面之中（渲染四棱锥中）
    /// </summary>
    /// <returns></returns>
    bool IsVisible()
    {
        //得到摄像机的六个面
        planes = GeometryUtility.CalculateFrustumPlanes(camera);
        //判断边框bounds是否在六个面内
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}

