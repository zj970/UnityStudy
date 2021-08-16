using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    public float invekeTime = 0.5f;
    public GameObject[] tankList;
    public TankType tankType = TankType.Player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateTank", invekeTime);
        Destroy(this.gameObject, invekeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateTank()
    {
        GameObject obj = null;
        if (tankList.Length < 4)
        {
            return;
        }
        switch (tankType)
        {
            case TankType.Player:
                if (tankList[0] == null)
                {
                    return;
                }
                obj = Instantiate(tankList[0], this.transform.position, tankList[0].transform.rotation);
                break;
            case TankType.Enemy1:
                if (tankList[1] == null)
                {
                    return;
                }
                obj = Instantiate(tankList[1], this.transform.position, tankList[1].transform.rotation);
                break;
            case TankType.Enemy2:
                if (tankList[2] == null)
                {
                    return;
                }
                obj = Instantiate(tankList[2], this.transform.position, tankList[2].transform.rotation);
                break;
            case TankType.Enemy3:
                if (tankList[3] == null)
                {
                    return;
                }
                obj = Instantiate(tankList[3], this.transform.position, tankList[3].transform.rotation);
                break;
            default:
                break;
        }
    }
}
