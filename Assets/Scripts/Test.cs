using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    void Start()
    {
        string chatting = "���� �ٺ� ��û�̾�";
        string pattern = @"�ٺ�|��û��|�����";
        MatchCollection collection = Regex.Matches(chatting, pattern);
        foreach (Match match in collection)
        {
            string old = match.ToString();
            chatting = chatting.Replace(old, new string(Enumerable.Repeat('*', old.Length).ToArray()));
        }
        Debug.Log(chatting);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
