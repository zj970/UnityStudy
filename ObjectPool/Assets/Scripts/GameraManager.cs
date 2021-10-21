using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameraManager : MonoBehaviour
{
    private Vector3 offset;//相机与物体之间的绝对位置
    public Transform trsPlay;//跟随物体




    private void Awake()
    {
        offset = transform.position - trsPlay.position;
        offset = new Vector3(0, offset.y, offset.z);
    }

    private void Update()
    {
        this.transform.position = trsPlay.position + offset;
    }
}
