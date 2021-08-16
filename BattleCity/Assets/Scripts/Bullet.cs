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

    private void Start()
    {
        if (bulletType == BulletType.Player)
        {
            this.GetComponent<AudioSource>().Play();
        }

    }

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
            if (collision.gameObject.CompareTag("Wall"))
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("AirWall"))
            {
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("GoldWall"))
            {
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("Home"))
            {
                //游戏结束
                GameManager.gameManager_Instance.GameOver();
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
            if (collision.gameObject.CompareTag("Wall"))
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("AirWall"))
            {
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("GoldWall"))
            {
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("Home"))
            {
                //游戏结束
                GameManager.gameManager_Instance.GameOver();
                Destroy(this.gameObject);
            }
        }
    }
}
