using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]//为所在物体添加刚体组件
public class PlayerController : MonoBehaviour
{
    Vector3 veiocity;
    Rigidbody myRigidbbody;

    private void Start()
    {
        myRigidbbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        veiocity = _velocity;
    }

    private void FixedUpdate()
    {
        myRigidbbody.MovePosition(myRigidbbody.position + veiocity * Time.fixedDeltaTime);
        //myRigidbbody.MovePosition(myRigidbbody.position + veiocity);
    }

    
}
