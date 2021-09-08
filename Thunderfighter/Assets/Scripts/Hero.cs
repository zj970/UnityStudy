using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private float xLimit = 3f;
    private float yLimit = -3.5f;
    private float yMax = 5.5f;

    private bool isMouseDown = false;


    //mouseOffset = currentPosition - previousPosition,将mouseOffset同步给Hero
    private void Update()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x>-xLimit && Camera.main.ScreenToWorldPoint(Input.mousePosition).x < xLimit && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > yLimit && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < yMax)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                      Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                      this.transform.position.z);
            }
        }

        
    }
}
