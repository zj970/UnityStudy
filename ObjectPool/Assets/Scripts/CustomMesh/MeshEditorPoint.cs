using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制点脚本
/// </summary>
public class MeshEditorPoint : MonoBehaviour
{
    //顶点的Id（顶点初始位置转字符串）
    [HideInInspector] 
    public string pointid;
    //记录坐标点上一次移动的位置，用于判断控制点是否移动
    [HideInInspector]
    private Vector3 lastposition;
    public delegate void MoveDelegate(string pid, Vector3 pos);
    //控制点移动时的回调
    public MoveDelegate OnMove = null;
    private void Start()
    {
        lastposition = transform.position;
    }
    private void Update()
    {
        if (transform.position != lastposition)
        {
            if (OnMove != null)
            {
                OnMove(pointid, transform.localPosition);
            }
            lastposition = transform.position;
        }
    }
}
