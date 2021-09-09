using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float xLimit = 3f;
    public float yLimit = -3.5f;
    public float yMax = 5.5f;
    public float myBionergy = 10;//默认生命值
    public Sprite[] hreoSprites;


    //mouseOffset = currentPosition - previousPosition,将mouseOffset同步给Hero
    private void Update()
    {
        


        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -xLimit && Camera.main.ScreenToWorldPoint(Input.mousePosition).x < xLimit && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > yLimit && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < yMax)
        {
            if (Input.GetMouseButton(0))
            {
                this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                      Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                      this.transform.position.z);

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            myBionergy -= collision.gameObject.GetComponent<Enemy>().bionergy;
            Destroy(collision.gameObject);
            if (myBionergy <= 0)
            {
                if (GameManager._instanceGameManager.bg!=null)
                {
                    GameManager._instanceGameManager.bg.GetComponent<AudioSource>().Stop();
                }
                Destroy(this.gameObject);
            }
        }
    }

}
