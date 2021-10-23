using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 5f;

    private void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        //控制移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rigidbody.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);
    }
}
