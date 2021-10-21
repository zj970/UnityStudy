using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    //传统创建子弹方法需要子弹的perfabs
    //public GameObject shotObj;
    public GameObject shotSpawn;//子弹发射的初始位置
    public float fireRate = 1f;//每次发射子弹事件间隔
    private float nextFire;//下一次发射子弹的时间
    public Transform bullets;
    private void Update()
    {
        Fire();
        Debug.Log(shotSpawn.transform.position);
    }

    public void Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //传统创建子弹方法
            //Instantiate(shotObj, shotSpawn.transform.position, shotSpawn.transform.rotation);
            //获取对象池中的子弹
            GameObject bullet = BulletsPool.BulletsPoolInstance.GetPooledObject();
            if(bullet != null)
            {
                bullet.SetActive(true);//激活子弹并初始化子弹的位置
                bullet.transform.position = shotSpawn.transform.position;
                //bullet.transform.SetParent(bullets);//设置子弹归类
            }
        }
    }
}
