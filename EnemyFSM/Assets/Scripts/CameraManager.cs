using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 offset;//相机与物体之间的距离
    public Transform trsPlay;//跟随物体的位置

    private void Awake()
    {
        offset = transform.position - trsPlay.position;
        offset = new Vector3(0, offset.y, offset.z);
    }

    private void Update()
    {
        transform.position = trsPlay.position + offset;//更新位置
    }
}
