using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int index;//获取当前怪物在对象池中的索引值

    [Range(0, 100)]
    public float distance = 30f;//检测距离
    public Transform player;//玩家的位置
    public float speed = 10f;
    bool isRotate = false;
    Vector3 lastPosition;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        lastPosition = transform.position;
    }

    /// <summary>
    /// 设置敌人出生点
    /// </summary>
    public void CreateEnemy()
    {
        //获取敌人在对象池的下标
        for (int i = 0; i < GamePool.GamePoolInstance.pooledObjects.Count; i++)
        {
            if (Equals(this.gameObject, GamePool.GamePoolInstance.pooledObjects[i]))
            {
                index = i % 4;
                break;
            }
        }

        //根据下标生成出生点
        switch (index)
        {
            case 0:
                this.transform.position = new Vector3(-100, 1, -100);
                break;
            case 1:
                this.transform.position = new Vector3(100, 1, -100);
                break;
            case 2:
                this.transform.position = new Vector3(100, 1, 100);
                break;
            case 3:
                this.transform.position = new Vector3(-100, 1, 100);
                break;
            default:
                break;
        }

        //设置面朝向
        transform.LookAt(Vector3.zero);
        Quaternion.Euler(0, 45f, 0);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 135f, 0); ;
        isRotate = true;//重置方向
    }

    /// <summary>
    /// 敌人巡逻
    /// </summary>
    public void Patrol()
    {
             
        if (!isRotate)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
            float dis = (transform.position - lastPosition).sqrMagnitude;
            dis = Mathf.Sqrt(dis);
            if (dis > 50)
            {
                isRotate = !isRotate;
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 90f, 0);
            lastPosition = transform.position;
            isRotate = false;
        }

    }

    /// <summary>
    /// 敌人追逐 射线检测
    /// </summary>
    public bool Chasing()
    {
        //TODO:追逐Player
        transform.LookAt(player);
        if (this.transform.position.x > -30f && this.transform.position.x < 30f 
            || this.transform.position.z > -30f && this.transform.position.z < 30f)
        {
            //TODO:脱离了范围
            return false;
        }
        else
        {
            transform.Translate(transform.forward * Time.deltaTime * speed,Space.World);
            //TODO:继续追逐
            return true;
        }
    }

    /// <summary>
    /// 检测Player
    /// </summary>
    public bool Look()
    {
        //TODO:检测Player
        float dis = (transform.position - player.position).sqrMagnitude;
        dis = Mathf.Sqrt(dis);
        if (dis < distance)
        {
            print("玩家进入到视野");
            return true;
        }
        return false;
    }
}
