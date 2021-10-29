using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform weaponHold;//装枪的位置
    Gun equippedGun;//枪
    public Gun startingGun;//初始配枪

    private void Start()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    /// <summary>
    /// 装配枪支
    /// </summary>
    /// <param name="gunToEquip"></param>
    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);//移除原来配枪
        }
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;//实例化枪
        equippedGun.transform.parent = weaponHold;//进行枪支管理
    }


    /// <summary>
    ///枪射击
    /// </summary>
    public void Shoot()
    {
        //安全
        if (equippedGun != null)
        {
            //TODO:进行射击
            equippedGun.Shoot();
        }
        else
        {
            print("没有可用的枪支");
        }
    }
}
