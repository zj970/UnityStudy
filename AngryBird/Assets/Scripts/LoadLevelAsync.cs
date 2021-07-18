using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAsync : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1080, 2340, true);
        Invoke("Load", 2f);
    }

   void Load()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
