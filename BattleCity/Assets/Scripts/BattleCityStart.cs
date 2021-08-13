using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleCityStart : MonoBehaviour
{
    public GameObject player;//实例化开始界面的对象
    public GameObject[] playerPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            if (player != null && playerPos.Length >= 2)
            {
                Vector3 pos1 = playerPos[0].transform.position;
                Vector3 pos2 = playerPos[1].transform.position;
                player.transform.position = player.transform.position == pos1 ? pos2 : pos1;//改变位置
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("BattleCity");//加载游戏场景都Build add 一遍
        }
    }
}
