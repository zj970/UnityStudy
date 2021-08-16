using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TankType
{
    Player,
    Enemy1,
    Enemy2,
    Enemy3
}

/// <summary>
/// 游戏状态
/// </summary>
public enum GameState
{
    ready,
    running,
    pause,
    gameOver

}

public class GameManager : MonoBehaviour
{

    //weight:22,height:18,enter (0,0)
    public float x_length = 11f;
    public float y_length = 7.5f;

    public GameObject AirWall;
    public GameObject Maps;
    public GameObject gameOver;

    public GameObject born;
    public GameObject[] bornPos;
    public TankType enemyTankType = TankType.Enemy1;
    public Vector3 enemyTankPos = Vector3.zero;
    public float enemyBornTimeInterval = 2f;
    public int MaxEnemyCount = 5;
    public int currentEnemyCount = 0;
    public int RestEnemyCount = 20;
    public int PlayerCount = 3;
    public float invokeTime = 0.5f;
    //static接口
    public static GameManager gameManager_Instance;
    public SpriteRenderer homeSpriteRenderer;
    public Sprite hurtSprite;
    public GameState game_State = GameState.ready;

    //奖励物品
    public GameObject star;
    public Vector3 startPos = Vector3.zero;
    public float starBornIntervalTime = 5f;
    public int currentStarCount = 0;

    private void Awake()
    {
        gameManager_Instance = this;
    }

    private void Start()
    {
        GameStart();
    }

    private void Update()
    {
        if (game_State == GameState.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameRestart();
            }
        }
    }

    //TODO:Create a few AirWall on the Map
    void CreateAirWall()
    {
        //Creat Up and Down AirWalls
        for (float i = -x_length; i <= x_length; i++)
        {
            //first Down(-11,-8.5,0)/Up(11,8.5f,0)
            Vector3 posDown = new Vector3(i, -8.5f, 0);
            Vector3 posUp = new Vector3(i, 8.5f, 0);
            if (AirWall != null)
            {
                GameObject airWallDown = Instantiate(AirWall, posDown, AirWall.transform.rotation);//instantiation this AirWaill
                GameObject airWallUp = Instantiate(AirWall, posUp, AirWall.transform.rotation);
                airWallDown.transform.SetParent(Maps.transform);//Sort out
                airWallUp.transform.SetParent(Maps.transform);
            }

        }
        //Creat Lift and Right AirWalls
        for (float j = -y_length; j <= y_length; j++)
        {
            //first Lift(-11,-7.5,0)/Right(11,7.5f,0)
            Vector3 posLift = new Vector3(11, j, 0);
            Vector3 posRight = new Vector3(-11, j, 0);
            if (AirWall != null)
            {
                GameObject airWallRight = Instantiate(AirWall, posRight, AirWall.transform.rotation);//instantiation this AirWaill
                GameObject airWallLeft = Instantiate(AirWall, posLift, AirWall.transform.rotation);
                airWallRight.transform.SetParent(Maps.transform);
                airWallLeft.transform.SetParent(Maps.transform);
            }

        }
    }

    /// <summary>
    /// Create tank
    /// </summary>
    public void CreatePlayer()
    {
        if (PlayerCount < 0)
        {
            //游戏结束
            GameOver();
        }
        if (born != null && bornPos.Length >= 4 && bornPos[0] != null)
        {
            var obj = Instantiate(born, bornPos[0].transform.position, born.transform.rotation);
            obj.GetComponent<Born>().tankType = TankType.Player;
        }
        PlayerCount--;
    }
    /// <summary>
    /// Enemy have three pos
    /// </summary>
    void CreateEnemy()
    {
        if (RestEnemyCount < 0)
        {
            return;//结束游戏
        }

        if (currentEnemyCount >= MaxEnemyCount)
        {
            return;
        }
        float randomEnemy = Random.Range(0, 6);
        float randomPos = Random.Range(0, 6);
        if (randomEnemy <= 1)
        {
            enemyTankType = TankType.Enemy3;
        }
        if (randomEnemy > 1 && randomEnemy <= 3)
        {
            enemyTankType = TankType.Enemy2;
        }
        if (randomEnemy <= 6 && randomEnemy > 3)
        {
            enemyTankType = TankType.Enemy1;
        }
        if (bornPos.Length < 4)
        {
            return;
        }
        if (randomPos <= 2)
        {
            if (bornPos[1] == null)
            {
                return;
            }
            enemyTankPos = bornPos[1].transform.position;
        }
        if (randomPos > 2 && randomPos <= 4)
        {
            if (bornPos[2] == null)
            {
                return;
            }
            enemyTankPos = bornPos[2].transform.position;
        }
        if (randomPos <= 6 && randomPos > 4)
        {
            if (bornPos[3] == null)
            {
                return;
            }
            enemyTankPos = bornPos[3].transform.position;
        }
        var obj = Instantiate(born, enemyTankPos, born.transform.rotation);
        obj.GetComponent<Born>().tankType = enemyTankType;
        currentEnemyCount++;
        RestEnemyCount--;
    }

    public void ReCreatePlayer()
    {
        Invoke("CreatePlayer", invokeTime);
    }

    public void GameOver()
    {
        if (homeSpriteRenderer != null && hurtSprite != null)
        {

            homeSpriteRenderer.sprite = hurtSprite;
            game_State = GameState.gameOver;//禁用掉键盘控制Player
            if (gameOver != null)
            {
                gameOver.SetActive(true);
            }
        }
    }

    void GameRestart()
    {
        SceneManager.LoadScene("Start");
    }

    void GameStart()
    {
        game_State = GameState.running;
        CreateAirWall();
        CreatePlayer();
        CreateEnemy();
        InvokeRepeating("CreateEnemy", 0.1f, enemyBornTimeInterval);//延迟委托，并且会一直调用
        if (gameOver != null)
        {
            gameOver.SetActive(false);
        }
        this.GetComponent<AudioSource>().Play();
            InvokeRepeating("CreateStar", starBornIntervalTime, starBornIntervalTime);
 

    }

    void CreateStar()
    {
        if (currentStarCount>= 1)
        {
            return;
        }
        float x = Random.Range(1 - x_length, x_length - 1);
        float y = Random.Range(1 - y_length, y_length - 1);
        startPos = new Vector3(x, y, 0);
        if (star != null)
        {
             var starObj = Instantiate(star, startPos, star.transform.rotation);
            starObj.GetComponent<SpriteRenderer>().sortingOrder = 1;
            currentStarCount++;
        }

    }
}
