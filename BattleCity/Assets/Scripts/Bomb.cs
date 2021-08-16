using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float invekeTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject, invekeTime);
    }

}
