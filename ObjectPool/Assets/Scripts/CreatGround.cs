using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatGround : MonoBehaviour
{
    void OnBecameVisible()  //当物体进入相机视野
    {
        this.gameObject.SetActive(true);
        print(1111);
    }
    void OnBecameInvisible()  //当物体离开相机视野
    {
        this.gameObject.SetActive(false);
        print(222);
    }


    private void Update()
    {
        if (this.GetComponent<MeshRenderer>().isVisible)
        {
            Debug.Log("111第一个cube在视野内");
        }
        else
            Debug.Log("222第一个cube不在视野内");
    }
}
