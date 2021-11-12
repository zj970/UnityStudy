
using UnityEngine;

using System.Collections.Generic;

//此脚本使用的是System.Json 来操作JSON数据的
//将System.Json.dll 拉到unity  Plugins 文件夹下
// System.Json.dll 文件位置   unity安装位置下
//  Editor\Data\Mono\lib\mono\unity\System.Json.dll
using System.Json;

//数据流的写入和读取
using System.IO;

//让编辑器刷新资源
using UnityEditor;

using System.Text;

using System;

public class JsonScript : MonoBehaviour
{
    public static List<JsonObject> tempJson = new List<JsonObject>();
    public static string[] reslut = new string[3];
    public static int[] reslutint = new int[3];
    void Start()
    {
        // 使用代码创建JSON 保存数据
        //CreatJSONData();
        // 解析JSON
        //ParseJSONData();
    }

    // 创建json
    public static void CreatJSONData(string userName)
    {
        // 写一个大括号
        JsonObject Users = new JsonObject();

        JsonObject message_1 = new JsonObject();
        
        // 填充数据
        message_1.Add("userName", userName);
        message_1.Add("Score", 20);
        tempJson.Add(message_1);

        // 信息数组
        JsonArray MessageArr = new JsonArray();

        for (int i = 0; i < tempJson.Count; i++)
        {
            MessageArr.Add(tempJson[i]);
        }

        //MessageArr.Add(message_1);

        Users.Add("Messages", MessageArr);
        Users.Add("tableName", "Users");
        // 拓展-- 数据留存档
        // 创建数据流的写入
        StreamWriter writer = new StreamWriter(Application.dataPath + "/StreamingAssets/Json/MySystemJSON.txt");
        Users.Save(writer);
        //自动装载缓冲区
        //writer.AutoFlush = true;
        writer.Close();
        //让编辑器刷新资源
        //AssetDatabase.Refresh();
    }

    public static userJSON ParseJSONData()
    {
        // 本地文件的读取
        FileInfo file = new FileInfo(Application.dataPath + "/StreamingAssets/Json/MySystemJSON.txt");
        StreamReader reader = new StreamReader(file.OpenRead(), Encoding.UTF8);
        string str = reader.ReadToEnd();

        // print (str);
        reader.Close();
        // 释放资源
        reader.Dispose();
        // 开始解析
        userJSON m_UserInfo = JsonUtility.FromJson<userJSON>(str);

        return m_UserInfo;

       /* for (int i = 0; i < m_StudentInfo.Messages.Count; i++)
        {
            print(m_StudentInfo.Messages[i].Score); //93 95 96 99
        }*/
    }

    public static void JSONData()
    {
        userJSON userJSON = ParseJSONData();
        for (int i = 0; i < userJSON.Messages.Count; i++)
        {
            JsonObject message_1 = new JsonObject();

            // 填充数据
            message_1.Add("userName", userJSON.Messages[i].userName);
            message_1.Add("Score", userJSON.Messages[i].Score);
            tempJson.Add(message_1);
            print(userJSON.Messages[i]); //93 95 96 99
        }
        
    }

    public static void SortData()
    {
        userJSON sortJSON = ParseJSONData();
        Message temp = new Message();
        print(sortJSON.Messages.Count);
        for (int i = 0; i < sortJSON.Messages.Count; i++)
        {

            for (int j = 0; j < sortJSON.Messages.Count -1 -i; j++)
            {
                if (sortJSON.Messages[j].Score > sortJSON.Messages[j+1].Score)
                {
                    temp = sortJSON.Messages[j];
                    sortJSON.Messages[j] = sortJSON.Messages[j + 1];
                    sortJSON.Messages[j + 1] = temp;
                }
            }
            //print(sortJSON.Messages[i].Score); //93 95 96 99
        }

        reslut[0] = sortJSON.Messages[sortJSON.Messages.Count - 1].userName;
        reslutint[0] = sortJSON.Messages[sortJSON.Messages.Count - 1].Score;        
        reslut[1] = sortJSON.Messages[sortJSON.Messages.Count - 2].userName;
        reslutint[1] = sortJSON.Messages[sortJSON.Messages.Count - 2].Score;        
        reslut[2] = sortJSON.Messages[sortJSON.Messages.Count - 3].userName;
        reslutint[2] = sortJSON.Messages[sortJSON.Messages.Count - 3].Score;
    }

    /// <summary>
    /// 根据名字设置分数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="score"></param>
    public static void SetScore(string name, int score)
    {

        userJSON userJSON = ParseJSONData();
        tempJson.Clear();
        for (int i = 0; i < userJSON.Messages.Count; i++)
        {
            if (userJSON.Messages[i].userName == name)
            {
                userJSON.Messages[i].Score += score;
            }
            JsonObject message_1 = new JsonObject();

            // 填充数据
            message_1.Add("userName", userJSON.Messages[i].userName);
            message_1.Add("Score", userJSON.Messages[i].Score);
            tempJson.Add(message_1);
            print(userJSON.Messages[i].Score); //93 95 96 99
        }

        // 写一个大括号
        JsonObject Users = new JsonObject();
        // 信息数组
        JsonArray MessageArr = new JsonArray();

        for (int i = 0; i < tempJson.Count; i++)
        {
            MessageArr.Add(tempJson[i]);
        }

        //MessageArr.Add(message_1);

        Users.Add("Messages", MessageArr);
        Users.Add("tableName", "Users");
        // 拓展-- 数据留存档
        // 创建数据流的写入
        StreamWriter writer = new StreamWriter(Application.dataPath + "/StreamingAssets/Json/MySystemJSON.txt");
        Users.Save(writer);
        //自动装载缓冲区
        //writer.AutoFlush = true;
        writer.Close();
    }


    //创建数据模型 接受解析数据 [因为我们是面向对象开发的]
    // 将我们在需要数据的地方直接使用类就可以点出这个模型

    //序列化  你发个qq 消息别人接收你的qq消息 不会分别将不同的数据类型发送或接收
    // 序列化后 相当于将消息编码加密 解密
    //[SerializeField] 修饰私有字段的 [强制将脚本中的私有变量在unity面板中出现 可以实现引用拖拽 但是其他脚本还是拿不到这个变量]


    //[Serializable]  修饰对象 作用 将对象序列化为二进制数据流 byte 类型  传输数据或解析数据

    [Serializable]
    public class Message
    {
        public string userName = "";
        public int Score = 0;
    }

    [Serializable]
    public class userJSON
    {
        public List<Message> Messages = new List<Message>();
        //public List<Message> Messages = new List<Message>();
        public string tableName = "";
    }
}
