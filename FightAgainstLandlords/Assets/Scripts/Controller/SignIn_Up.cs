using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 登录/注册
/// </summary>
public class SignIn_Up : MonoBehaviour
{

    public static SignIn_Up _instance;
    // 注册页面
    public GameObject signUp;
    public InputField upUserName;
    public InputField upPassword;
    public InputField passwordAgain;
    public Text upTips;

    // 登录页面
    public GameObject signIn;
    public InputField inUserName;
    public InputField inPassword;
    public Text inTips;

    bool didSignedUp = false;
    bool didSignedIn = false;

    private void Start()
    {
        _instance = this;
        //PlayerPrefs.DeleteAll();
        JsonScript.JSONData();

        print(JsonScript.tempJson.Count);
    }

    void Update()
    {
        if (didSignedUp)
        {
            didSignedUp = false;
            upTips.text = "注册成功，请返回到登录页面登录！";
            Debug.Log("注册成功，跳转到登录页面");
        }
        if (didSignedIn)
        {
            didSignedIn = false;
            Debug.Log("登录成功，跳转到登录成功页面");
            SceneManager.LoadSceneAsync("MainScene");
            //name01.text = Login.getName;
            signIn.SetActive(false);
        }
    }

    public void OnBackClicked() // 注册页面返回按钮
    {
        signIn.SetActive(true);
        signUp.SetActive(false);
    }

    public void OnUpSignUpClicked() // 注册页面注册按钮
    {
        var pass = passwordAgain.text.Trim();

        if (!upPassword.text.Trim().Equals(pass))
        {
            upTips.text = "两次输入的密码不一致，请重新输入！";
            return;
        }
        else if (upUserName.text.Trim() == "" || upPassword.text.Trim() == "" || pass == "")
        {
            upTips.text = "用户名密码不能为空，请重新输入！";
            return;
        }
        else if (PlayerPrefs.HasKey(upUserName.text))
        {
            upTips.text = "账户名已存在！";
            return;
        }
        else
        {
            PlayerPrefs.SetString(upUserName.text, upPassword.text); // 以用户名为键名进行存储
            //PlayerPrefs.SetInt(upUserName.text,0); // 以用户名为键名进行存储
            //存储数据
             JsonScript.CreatJSONData(upUserName.text);
            //Debug.Log(PlayerPrefs.GetInt(upUserName.text));
            Debug.Log(PlayerPrefs.GetString(upUserName.text));
            OnBackClicked();
        }
    }

    public void OnSignInClicked() // 登录页面登录按钮
    {
        if (inUserName.text.Trim() == "" || inPassword.text.Trim() == "")
        {
            inTips.text = "用户名密码不能为空，请重新输入！";
        }
        else if (PlayerPrefs.GetString(inUserName.text.Trim()) == null)
        {
            inTips.text = "用户不存在！请注册后再登录！";
        }
        else if (PlayerPrefs.GetString(inUserName.text.Trim()) != inPassword.text.Trim())
        {
            inTips.text = "用户密码错误，请重新输入！";
        }
        else
        {
            didSignedIn = true;
        }
    }

    public void OnInSignUpClicked() // 登录页面注册按钮
    {
        signUp.SetActive(true);
        signIn.SetActive(false);
    }

    public void OnQuitClicked() // 登录成功页面退出按钮
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}