using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;//移动速度
    public float bionergy = 1;//默认生命值
    public float yLimit = -4.5f;
    public float score = 1000f;

    private void Update()
    {
        this.transform.position += Vector3.down * speed * Time.deltaTime;
        if (this.transform.position.y < yLimit)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        bionergy--;
        if (bionergy == 0)
        {
            GameManager._instanceGameManager.scoreSum += score;
            GameManager._instanceGameManager.souceText.text = GameManager._instanceGameManager.scoreSum.ToString();
            Destroy(this.gameObject);
        }

    }
}
