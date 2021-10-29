using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunController))]
[RequireComponent(typeof(PlayerController))]
public class Player : LivingEnity
{
    public float moveSpeed = 5f;//Player移动速度


    PlayerController controller;//实例化出Player的控制器
    GunController gunController;
    ScoreController scoreController;

    private void Start()
    {
        health = 5;//设置生命值
        controller = GetComponent<PlayerController>();//找到身上的组件
        gunController = GetComponent<GunController>();
        scoreController = GetComponent<ScoreController>();
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("开始射击");
            gunController.Shoot();
        }
        if (dead)
        {
            GameOver();
        }
    }

    /// <summary>
    /// 游戏结束，生命值为0
    /// </summary>
    public void GameOver()
    {
            print("你没了");
            //保存分数
            scoreController.Save();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("你收到了怪物的攻击");
            collision.gameObject.GetComponent<Enemy>().health--;
            health--;
            if (health < 0)
            {
                //TODO:玩家死亡
                dead = true;
            }

            //杀死怪物
            if (collision.gameObject.GetComponent<Enemy>().health < 0)
            {
                scoreController.scoreText.text = "100";
            }
        }
    }
}
