using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //weight:22,height:18,enter (0,0)
    public float x_length = 11f;
    public float y_length = 7.5f;

    public GameObject AirWall;
    public GameObject Maps;

    private void Start()
    {
        CreatAirWall();
    }

    //TODO:Creat a few AirWall on the Map
    void CreatAirWall()
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


}
