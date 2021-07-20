using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System;

public class Lagin : MonoBehaviour
{
    static string connetStr = "server=127.0.0.1;port=3306;user=root;password=admin;database=pet;";
    public InputField AccountInput;//账号输入
    public InputField PasswordInput;//密码输入
    public Text Mistake;//账号及密码输入错误提示
    public Text Register;//登录成功提示
    protected bool isPass = false;
    //protected CLient ss;

    public void OKButton()//Button点击事件
    {
       
        string AccountNumber = AccountInput.text;//获取输入账号
        string PassWordNumber = PasswordInput.text;//获取输入密码
        MySqlConnection conn = new MySqlConnection(connetStr);
        try
        {
            conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                        //Console.WriteLine("已经建立连接");
            print("连接成功");
            //在这里使用代码对数据库进行增删查改
            //check(conn);
            string selectSql = "select name,password from admin";
            //string sql = "select name,password from admin where id = " +"\""+AccountNumber+"\"";
            MySqlCommand cmd = new MySqlCommand(selectSql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            print(reader);
            while (reader.Read())
            {
                //print(reader.GetString("name"));
                if ((reader.GetString("name").Equals(AccountNumber)) && (reader.GetString("password").Equals(PassWordNumber)))
                {
                    isPass = true;
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            print(ex.Message);
            print("连接失败");
        }
        finally
        {
            conn.Close();
        }
        if (isPass)//判断是否输入正确
        {
            //Register.gameObject.SetActive(true);//登录效果提示
            StartCoroutine(Disappear());//调用协程
            SceneManager.LoadScene(2);//跳转别的场景
            print("登录成功了!");

        }
        else
        {
            //Mistake.gameObject.SetActive(true);//账号密码输入错误提示
           // StartCoroutine(Disappear());//调用协程
        }
    }
    IEnumerator Disappear()//协程
    {
        yield return new WaitForSeconds(2);//产生效果两秒
        Mistake.gameObject.SetActive(false);//提示错误效果消失
        Register.gameObject.SetActive(false);//提示登录成功效果消失
    }

    public void zhuceButton()//Button点击事件
    {
        string user = AccountInput.text;//获取输入账号
        string psw = PasswordInput.text;//获取输入密码

        MySqlConnection conn = new MySqlConnection(connetStr);
        try
        {
            conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                        //Console.WriteLine("已经建立连接");
            print("连接成功");
            //在这里使用代码对数据库进行增删查改


            string insertSql = "insert into admin(name, password) values("+"'"+user+"'"+","+"'"+psw+"')";
            MySqlCommand cmd = new MySqlCommand(insertSql, conn);
            int result = cmd.ExecuteNonQuery();
            print(result);
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            print(ex.Message);
            print("连接失败");
        }
        finally
        {
            conn.Close();
        }
    }

    /*2021年7月20日
     * Unity与数据库的连接
     * 1.安装MySql，记得选中Connector.NET 6.9的安装，里面有MySQL与C#连接的动态链接库
     * 2.在Unity中添加一个文件夹plugins，里面添加MySql.data.dll文件
     * 注意：版本不适应，会引起出错
     * 3.建立一个String 变量，存放固定格式:"server=127.0.0.1;port=3306;user=root;password=密码;database=数据库名字;"
     * 4.using MySql.Data.MySqlClient;
     * 5. MySqlConnection conn = new MySqlConnection(connetStr);
     * 6.conn.Open();打开通道
     * 7.编辑SQL语句;
     * 8.MySqlCommand cmd = new MySqlCommand(selectSql, conn);执行
     * 9.MySqlDataReader reader = cmd.ExecuteReader();//接收
     * 
     
     */

}

