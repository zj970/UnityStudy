using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausePanel : MonoBehaviour
{
    private Animator anim;//储存动画
    public GameObject button;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Retry()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    /// <summary>
    /// 点击了pause按钮
    /// </summary>
    public void Pause()
    {
        //1.播放Pause动画
        anim.SetBool("isPause",true);
        button.SetActive(false);

    }


    /// <summary>
    /// 点击了Resume按钮
    /// </summary>
    public void Resume()
    {
        //1.播放Resume动画
        Time.timeScale = 1;//
        anim.SetBool("isPause", false);
        button.SetActive(true);
    }


    /// <summary>
    /// pause动画播放完成调用
    /// </summary>
    public void pauseAnimEnd()
    {
        Time.timeScale = 0;
    }

    public void Home()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    /// <summary>
    /// resume动画播放完成调用
    /// </summary>
    public void ResumeAnimEnd()
    {
        button.SetActive(true);
    }
}
