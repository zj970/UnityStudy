using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserLogin : MonoBehaviour
{
    public InputField userField;
    public InputField passwordField;
    public Button loginBtn;

    public GameObject player;
    public GameObject gameController;
    //public GameObject deFenObjectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        loginBtn.onClick.AddListener(delegate {
            IsOnoffUserPassword();
        });
    }
    public void IsOnoffUserPassword()
    {
        if (Dicteory_List.instance.List_addUser.Count != 0)
        {
            for (int i = 0; i < Dicteory_List.instance.List_addUser.Count; i++)
            {
                if (userField.text == Dicteory_List.instance.List_addUser[i].name &&
                    passwordField.text == Dicteory_List.instance.List_addUser[i].password)
                {
                    if (player  != null && gameController != null)
                    {
                        player.SetActive(true);
                        gameController.SetActive(true);
                        DestroyAll();
                    }
                }

            }
        }
        else
        {
            if (userField.text == "0" && passwordField.text == "0")
            {
                Debug.Log("登录成功了啊啊 ");
            }
            print("登录失败");
        }
    }
    public void DestroyAll()
    {
        Destroy(this.gameObject);
    }
}
