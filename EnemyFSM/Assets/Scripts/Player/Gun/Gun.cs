using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzie;//子弹的位置
    public float msBetweenshoots = 1f;//射击间隙
    public float muzzleVelocity = 35f;//子弹速度
    float nextShootTime;//类似计时器

    public void Shoot()
    {
        if (Time.time > nextShootTime)
        {
            nextShootTime = Time.time + msBetweenshoots;
            //传统创建子弹方法
            //Instantiate(shotObj, shotSpawn.transform.position, shotSpawn.transform.rotation);
            //获取对象池中的子弹
            GameObject bullet = BulletPool.GamePoolInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.SetActive(true);//激活子弹并初始化子弹的位置
                bullet.transform.position = muzzie.position;
                //bullet.transform.SetParent(bullets);//设置子弹归类
            }
        }
    }
}
