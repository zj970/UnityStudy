using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform weaponHold;
    Gun equippedGun;
    public Gun startingGun;
    private void Start()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }
    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);//移除游戏对象、组件或资产。
        }
        equippedGun = Instantiate(gunToEquip,weaponHold.position,weaponHold.rotation) as Gun;//实例化
        equippedGun.transform.parent = weaponHold;//转换的父元素
    }
    public void Shoot()
    {
        if(equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}
