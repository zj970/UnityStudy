using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//定义一个星星颜色枚举
public enum StarColor
{
    blue,
    green,
    orange,
    purple,
    red
}

public class Star : MonoBehaviour
{
    //public声明的变量，可以在Unity中的Inspector
    public int Row = 0;
    public int Column = 0;
    public StarColor starColor = StarColor.blue;
    public int moveDownCount = 0;   
    public int moveLeftCount = 0;
    private bool isMoveDown = false; 
    private bool isMoveLeft = false;
    public float speed = 50f;
    private int targetRow = 0;
    private int targetColumn = 0;


    private void Update()
    {
        //下移
        if (isMoveDown)
        {
            Row = targetRow;
            //当前的位置为 Column * 48 ,需要移动的距离 48 * moveDownCount,最终移动到达的位置 (Column - moveLeftCount)*48f
            if (this.transform.localPosition.y> targetRow * 48f)
            {
                this.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else
            {
                this.transform.localPosition = new Vector3( this.transform.localPosition.x, targetRow * 48f, this.transform.localPosition.z);
                isMoveDown = false;
                moveDownCount = 0;

            }

        }
        //左移
        if (isMoveLeft)
        {
            Column = targetColumn;
            //当前的位置为 row * 48 ,需要移动的距离 48 * moveDownCount,最终移动到达的位置 row * 48 - 48 * moveDownCount
            if (this.transform.localPosition.x > targetColumn * 48f)
            {
                this.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                this.transform.localPosition = new Vector3(targetColumn * 48f,this.transform.localPosition.y, this.transform.localPosition.z);
                isMoveDown = false;
                moveLeftCount = 0;

            }

        }
    }


    public void OnClick_Star()
    {
        //Debug.Log("ddddd"+starColor.ToString());
        GameManager.gameManager_Instance.FindTheSameStar(this);
        GameManager.gameManager_Instance.ClearClickedStarList();
    }

    /// <summary>
    /// 销毁自身的游戏对象
    /// </summary>
    public void DestroyStar()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// 向下移动的开关
    /// </summary>
    public void OpenMoveDown()
    {
        isMoveDown = true;
        targetRow = Row - moveDownCount;
    }

    public void OpenMoveLeft()
    {
        isMoveLeft = true;
        targetColumn = Column - moveLeftCount;
    }
}
