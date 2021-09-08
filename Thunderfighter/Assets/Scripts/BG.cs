using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 20.48f;

    private void Update()
    {
        if (this.gameObject != null)
        {
            this.transform.position += Vector3.down * speed * Time.deltaTime;
            //Debug.Log(this.transform.position);
            if (this.transform.position.y < -distance)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2 * distance, this.transform.position.z);
            }
        }

    }

}
