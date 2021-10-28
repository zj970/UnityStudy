using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class Enemy : MonoBehaviour
{
    private EnemyController enemyController;

    private enum State { patrol, Chasing, Attacking };
    State currentState;

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        enemyController.CreateEnemy();//初始化怪物位置
        currentState = State.patrol;//默认在巡逻状态
        enemyController.Patrol();
       
    }

    private void Update()
    {
        if (currentState == State.patrol)
        {
            enemyController.Patrol();
        }
        //检测到Player
        if (enemyController.Look())
        {
            currentState = State.Chasing;//改变怪物状态
            enemyController.Chasing();

            if (!enemyController.Chasing())
            {
                enemyController.CreateEnemy();//初始化怪物位置
                currentState = State.patrol;//初始化怪物巡逻状态
            }
        }
    }
}
