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
        // (.) �ƹ� ���ڿ� �ϳ�.
        string str = "abcd";
        Regex regex = new Regex("a.d");     
        Debug.Log(regex.IsMatch(str));

        str = "abd";
        Debug.Log(regex.IsMatch(str));

        // (*) ���� ���ڰ� ���ų� 1�� �̻��� ���.
        Debug.Log("=============== * ===============");
        str = "abcdasabcdbsdcbsdavccbaavasdbdassbdavn";
        regex = new Regex("a*b");
        MatchCollection collect = regex.Matches(str);
        Debug.Log($"Count:{collect.Count}");
        foreach(Match m in collect)
            Debug.Log(m.ToString());

        // (+) ���� ���ڰ� 1�� �̻��� ���.
        Debug.Log("=============== + ===============");
        regex = new Regex("a+b");
        collect = regex.Matches(str);
        Debug.Log($"Count:{collect.Count}");
        foreach (Match m in collect)
            Debug.Log(m.ToString());

        // ([ ]) ���� ���� ���� �� �ƹ��ų�.
        Debug.Log("=============== [] ===============");
        regex = new Regex("[abcd]+b");
        collect = regex.Matches(str);
        Debug.Log($"Count:{collect.Count}");
        foreach (Match m in collect)
            Debug.Log(m.ToString());
        */
    }

}
