using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float scoreSum = 0f;
    public Text souceText;
    public GameObject bg;

    public static GameManager _instanceGameManager;


    private void Start()
    {
        _instanceGameManager = this;
    }
}
