using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bullet != null)
            {
                Instantiate(bullet, this.transform.position, bullet.transform.rotation);
            }
        }
    }
}
