using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float repeateRateTime = 0.1f;


    private AudioSource audioSource;
    public static Gun _instanceGun;
    public AudioClip[] audios;

    private void Start()
    {
        _instanceGun = this;
        InvokeRepeating("CreateBullet", 0f, repeateRateTime);
        audioSource = this.GetComponent<AudioSource>();
    }

    private void CreateBullet()
    {
        if (bullet != null)
        {
            Instantiate(bullet, this.transform.position, bullet.transform.rotation);
        }
    }
}
