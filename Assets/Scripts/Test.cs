using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    void Start()
    {
        string chatting = "야이 바보 멍청이야";
        string pattern = @"바보|멍청이|모니터";
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
