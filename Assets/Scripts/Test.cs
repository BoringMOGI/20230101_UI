using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    void Start()
    {
        /*string chatting = "���� �ٺ� ��û�̾�";
        string pattern = @"�ٺ�|��û��|�����";
        MatchCollection collection = Regex.Matches(chatting, pattern);
        foreach (Match match in collection)
        {
            string old = match.ToString();
            chatting = chatting.Replace(old, new string(Enumerable.Repeat('*', old.Length).ToArray()));
        }
        Debug.Log(chatting);*/

        string str = "abcdEFGH130@$";
        Regex regex = new Regex("[a-z]+[A-Z]+[0-9]+[~!@#$%^&*()_+|[\\]{};':,.<>/?\\-=]+");
        Debug.Log(regex.IsMatch(str));
    }

}
