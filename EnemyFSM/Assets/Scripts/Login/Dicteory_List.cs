using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class Add_user
{
    public string name;      //名字
    public string leixing;   //类型
    public string password;   //密码
}

public class Dicteory_List : MonoBehaviour
{
    public static Dicteory_List instance;

    public string patch_account = @"\Data\Useneed.txt";   //账户的路径
    public List<Add_user> List_addUser = new List<Add_user>();
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        Read_Account();
        Debug.Log(List_addUser.Count);
    }
    void OnApplicationQuit()
    {
        Debug.Log("执行了么");
        SaveUser();
    }


    /// <summary>
    /// 保存账户
    /// </summary>
    public void SaveUser()
    {
        string text = "";//\r\n表示换一行 两行就是\r\n\r\n       
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + patch_account, true, Encoding.UTF8);

        for (int i = 0; i < List_addUser.Count; i++)
        {
            text += List_addUser[i].name + "*" + List_addUser[i].leixing + "*" + List_addUser[i].password + "*" + "\r\n";
        }
        sw.Write(text);
        sw.Flush();
        sw.Close();
    }
   
    /// <summary>
    /// 读取账户
    /// </summary>
    public void Read_Account()
    {
        string[] RawString = System.IO.File.ReadAllLines(Application.streamingAssetsPath + patch_account);

        if (RawString.Length != 0)
        {
            for (int i = 0; i < RawString.Length; i++)
            {
                string[] ss = RawString[i].Split('*');
                Add_user add_User = new Add_user();
                add_User.name = ss[0];
                add_User.leixing = ss[1];
                add_User.password = ss[2];
                List_addUser.Add(add_User);
            }
        }
        /*string tex3 = "";
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + patch_account, false);
        sw.Write(tex3);*/
       /* sw.Flush();
        sw.Close();*/
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        //List_addUser.Clear();
    }
}
