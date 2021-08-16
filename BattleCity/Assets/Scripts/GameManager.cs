using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TankType
{
    Player,
    Enemy1,
    Enemy2,
    Enemy3
}

public class GameManager : MonoBehaviour
{

    //weight:22,height:18,enter (0,0)
    public float x_length = 11f;
    public float y_length = 7.5f;

    public GameObject AirWall;
    public GameObject Maps;

    public GameObject born;
    public GameObject[] bornPos;
    public TankType enemyTankType = TankType.Enemy1;
    public Vector3 enemyTankPos = Vector3.zero;
    public float enemyBornTimeInterval = 2f;


    private void Start()
    {
        CreateAirWall();
        CreatePlayer();
        CreateEnemy();
        InvokeRepeating("CreateEnemy",0.1f, enemyBornTimeInterval);//延迟委托，并且会一直调用
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
    void CreatePlayer()
    {
        if (born != null && bornPos.Length >= 4 && bornPos[0] != null)
        {
            var obj = Instantiate(born, bornPos[0].transform.position, born.transform.rotation);
            obj.GetComponent<Born>().tankType = TankType.Player;
        }
    }
    /// <summary>
    /// Enemy have three pos
    /// </summary>
    void CreateEnemy()
    {
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
    }
}
