using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;//Player移动速度

    PlayerController controller;//实例化出Player的控制器

    private void Start()
    {
        controller = GetComponent<PlayerController>();//找到身上的组件
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);
    }

}
