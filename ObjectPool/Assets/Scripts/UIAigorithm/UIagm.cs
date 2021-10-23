using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIagm : MonoBehaviour
{

    public InputField inputA;
    public InputField inputB;

    public Text ResultA;
    public Text ResultB;

    private List<char> charList;
    private List<int> intList;



    public void Begin()
    {
        string a = inputA.text.ToString();
        string b = inputB.text.ToString();
        charList = new List<char>();
        intList = new List<int>();
        bool isTarget = true;

        for (int i = 0; i < a.Length; i++)
        {
            charList.Add(a[i]);
        } 

        for (int i = 0; i < charList.Count - b.Length + 1; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                if (charList[i+j]==b[j])
                {
                    isTarget = false;
                }
                else
                {
                    isTarget = true;
                    break;
                }
            }
            if (!isTarget)
            {
                intList.Add(i);
            }
        }
        for (int i = 0; i < intList.Count; i++)
        {
            int dex = intList[i] - i * b.Length;
            ResultB.text += b;
            
            charList.RemoveRange(dex, b.Length);
        }
        for (int i = 0; i < charList.Count; i++)
        {
            ResultA.text += charList[i].ToString();
        }

    }

}
