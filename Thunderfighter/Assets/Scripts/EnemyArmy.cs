using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    public GameObject enemy;
    public Sprite[] sprites;
    private float repeateRateTime = 1.5f;


    private void Start()
    {
        CreateEnemyArmy();
    }

    public void CreateEnemyArmy()
    {
        InvokeRepeating("CreateEnemy", 0f, repeateRateTime);
    }

    private void CreateEnemy()
    {
        int index = Random.Range(0, 10);
        float site = Random.Range(-2.5f, 2.5f);
        Vector3 pos = new Vector3(site, this.transform.position.y, this.transform.position.z);
        GameObject enemyClone = Instantiate(enemy, pos, enemy.transform.rotation);
        enemyClone.GetComponent<SpriteRenderer>().sprite = sprites[index];//设置敌机样式
        enemyClone.GetComponent<Enemy>().bionergy = index;//设置血量
        enemyClone.GetComponent<Enemy>().speed = (10 - index) * 0.5f;//设置速度

    }
}
