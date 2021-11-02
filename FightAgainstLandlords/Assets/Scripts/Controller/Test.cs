using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Test : MonoBehaviour
{
    public Text name01;
    public Text scoure;
    void Start()
    {
        if (name01 != null && scoure != null)
        {
            name01.text = Login.getName;
            scoure.text = Login.intergral;
        }
    }


}
