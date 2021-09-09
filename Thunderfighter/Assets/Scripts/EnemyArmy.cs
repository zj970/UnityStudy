using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    public GameObject enemy;
    public Sprite[] enemySprites;
    public float repeateRateTime = 1f;


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
        enemyClone.GetComponent<SpriteRenderer>().sprite = enemySprites[index];//设置敌机样式
        enemyClone.GetComponent<Enemy>().bionergy = index+1;//设置血量
        enemyClone.GetComponent<Enemy>().speed = (10 - index) * 0.5f;//设置速度
        enemyClone.GetComponent<Enemy>().score = 1000f + index * (10 - index) * 20f;//设置分数

    }
}
