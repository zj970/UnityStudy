using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontal = 0f;
    public float vertical = 0f;
    public float speed = 2f;

    public bool isVerticalAvailable = false;
    private Vector3 playerRotation = Vector3.zero;

    //TODO:The keyboard controls the player's movement;
    private void Update()
    {
        //Input.GetAxis("");//判断我们键盘输入，左右方向键 -1，0，1,也就是可以达到我们控制的目的
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.S))
        {
            isVerticalAvailable = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
        {
            isVerticalAvailable = false;
        }
        if (isVerticalAvailable)
        {
            if (vertical > 0)
            {
                playerRotation = new Vector3(0, 0, 180);
            }
            if (vertical < 0)
            {
                playerRotation = Vector3.zero;
            }
        }

        if (!isVerticalAvailable)
        {
            if (horizontal > 0)
            {
                playerRotation = new Vector3(0, 0, 90);

            }
            if (horizontal < 0)
            {
                playerRotation = new Vector3(0, 0, -90);
            }
        }
        this.transform.rotation = Quaternion.Euler(playerRotation);//重置游戏对象的Rotation

        if (vertical != 0 || horizontal != 0)
        {
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
