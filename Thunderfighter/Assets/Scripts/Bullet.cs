using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float yLimit = 6.3f;


    private void Update()
    {

        this.transform.position += Vector3.up * speed * Time.deltaTime;
        if (this.transform.position.y > yLimit)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //this.transform.parent.GetComponent<AudioSource>().Play();
            if (Gun._instanceGun != null)
            {
                Gun._instanceGun.GetComponent<AudioSource>().Play();
            }
            Destroy(this.gameObject);//销毁子弹
        }
    }
}