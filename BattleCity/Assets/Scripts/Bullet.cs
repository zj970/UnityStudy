using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Player,
    Enemy
}

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    public BulletType bulletType = BulletType.Player;
    public float damageValue = 1f;

    private void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bulletType == BulletType.Player)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.SendMessage("BeHit",damageValue);
                Destroy(this.gameObject);
            }
        }
        if (bulletType == BulletType.Enemy)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.SendMessage("BeHit", damageValue);
                Destroy(this.gameObject);
            }
        }
    }
}
