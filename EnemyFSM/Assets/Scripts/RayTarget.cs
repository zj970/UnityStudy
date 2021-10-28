using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTarget : MonoBehaviour
{
    private Ray ray;//从摄像机发出射线（根据鼠标在屏幕的位置）
    private RaycastHit hitInfo;//获取射线信息

    private void Update()
    {
        //ray = ;//从当前鼠标位置发射射先
        if (Input.GetMouseButtonDown(0))//鼠标左键按下
        {
            if (Physics.Raycast(ray, out hitInfo))//使用默认射线长度和其他默认参数
            {
                if (hitInfo.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Hit--" + hitInfo.collider.gameObject.name);//碰到物体的名称
                    this.transform.position
                        = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
    }
}
