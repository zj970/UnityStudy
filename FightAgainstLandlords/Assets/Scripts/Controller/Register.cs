using UnityEngine.UI;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;

public class Register : MonoBehaviour
{
    public InputField inputName;
    public InputField inputPass;

    /// <summary>
    /// 登录事件
    /// </summary>
    public void btnRegister_Click()
    {
        //1.获取数据
        string userName = inputName.text.ToString();
        string password = inputPass.text.ToString();

        //2.验证数据
        //判断用户输入是否为空，若为空，提示用户信息
        if (userName.Equals("") || password.Equals(""))
        {
            print("用户名或密码不能为空");
        }
        //若不为空，验证用户名和密码是否正确
        else
        {
            try
            {
                //1.创建数据库连接
                SqlAccess.sqlInstance.OpenSql();
                //2.执行Sql语句
                string sqlSel = "insert into user (username,password) values ('" + userName.ToString() + " ','" + password.ToString() + "')";
                object data = SqlAccess.sqlInstance.ExecuteQuery(sqlSel);
                //3.判断
                if (data != null)
                {
                    //跳转到主界面
                    print("注册成功");
                    print(data);
                }
                //用户名或密码错误，提示
                else
                {
                    print("注册失败");
                }
            }
            catch (Exception e)
            {
                print(e.Message.ToString() + "失败");
            }
            finally
            {
                SqlAccess.sqlInstance.Close();
            }

        }
    }
}
