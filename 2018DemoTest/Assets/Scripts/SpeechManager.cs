using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{
    public Text ASRmsg;
    public Text tryTex;
    public Text aad;

    public Button TryBtn;
    public Button ASR_Btn;


    private AndroidJavaObject jo;


    private void Awake()
    {
       /* ASR_Btn = GameObject.Find("Speech/ASR_Btn").GetComponent<Button>();
        TryBtn = GameObject.Find("Test/TryBtn").GetComponent<Button>();
*/
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
    }
    void Start()
    {
        ASR_Btn.onClick.AddListener(() => {

            jo.Call("beginListen");

        });
        TryBtn.onClick.AddListener(tryConnect);
    }

    public void OnResult(string msg)
    {
        ASRmsg.text = msg;

    }

    /// <summary>
    /// 点击Try按钮
    /// </summary>
    public void tryConnect()
    {
        int aaa;
        aaa = jo.Call<int>("beginTest", 2, 3);
        aad.text = aaa.ToString();

        jo.Call("connected");
    }

    public void tryConnected(string tryMsg)
    {
        tryTex.text = tryMsg;

        Color ramColor = ColorRandom();
        tryTex.color = ramColor;
    }

    public Color ColorRandom()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        Color color = new Color(r, g, b);
        return color;
    }

}

