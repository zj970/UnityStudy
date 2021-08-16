using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float randomTime = 2f;
    public float timer = 0f;
    public float bulletSpeed = 2f;
    public GameObject bullet;
    public GameObject gun;
    public GameObject bomb;

    public float fireTimeInterval = 2f;
    public float fireTimer = 0f;
    public float enemyPH = 1f;
    public bool isDeath = false;

    private void Start()
    {
        randomTime = Random.Range(0.5f, 1f);
        fireTimeInterval = Random.Range(1f, 2f);
        //Invoke("Fire", fireTimeInterval);
    }

    void Update()
    {
        //print(Random.Range(0, 4));
        timer += Time.deltaTime;
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (timer >= randomTime)
        {
            ChangeRotation();
            timer = 0f;
            randomTime = Random.Range(0.75f, 2);
        }

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireTimeInterval)
        {
            Fire();
            fireTimer = 0f;
            fireTimeInterval = Random.Range(1f, 2f);
        }
        if (isDeath)
        {
            Bomb();
            Destroy(this.gameObject);
        }
    }

    void ChangeRotation()
    {
        //this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 * Random.Range(0, 4)));
        float direc = Random.Range(0, 9);
        if (direc < 2)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (5 > direc && direc >= 2)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        if (direc >= 5 && direc < 7)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if (direc >= 7 && direc < 9)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        }
    }

    void Fire()
    {
        if (bullet != null && gun != null)
        {
            var obj = Instantiate(bullet, gun.transform.position, this.transform.rotation);
            obj.GetComponent<Bullet>().speed = bulletSpeed;
        }

    }

    /// <summary>
    /// 被击中
    /// </summary>
    public void BeHit(float damageValue)
    {
        if (enemyPH > 0)
        {
            enemyPH -= damageValue;
        }
        else
        {
            isDeath = true;
        }
    }

    void Bomb()
    {
        if (bomb != null)
        {
            Instantiate(bomb, this.transform.position, bomb.transform.rotation);
        }
    }
}
