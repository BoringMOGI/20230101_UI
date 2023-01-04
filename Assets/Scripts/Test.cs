using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        /*
        // (.) 아무 문자열 하나.
        string str = "abcd";
        Regex regex = new Regex("a.d");     
        Debug.Log(regex.IsMatch(str));

        str = "abd";
        Debug.Log(regex.IsMatch(str));

        // (*) 앞의 문자가 없거나 1개 이상인 경우.
        Debug.Log("=============== * ===============");
        str = "abcdasabcdbsdcbsdavccbaavasdbdassbdavn";
        regex = new Regex("a*b");
        MatchCollection collect = regex.Matches(str);
        Debug.Log($"Count:{collect.Count}");
        foreach(Match m in collect)
            Debug.Log(m.ToString());

        // (+) 앞의 문자가 1개 이상인 경우.
        Debug.Log("=============== + ===============");
        regex = new Regex("a+b");
        collect = regex.Matches(str);
        Debug.Log($"Count:{collect.Count}");
        foreach (Match m in collect)
            Debug.Log(m.ToString());

        // ([ ]) 범위 안의 문자 중 아무거나.
        Debug.Log("=============== [] ===============");
        regex = new Regex("[abcd]+b");
        collect = regex.Matches(str);
        Debug.Log($"Count:{collect.Count}");
        foreach (Match m in collect)
            Debug.Log(m.ToString());
        */
    }

}
