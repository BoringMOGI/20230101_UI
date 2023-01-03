using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class InputField : MonoBehaviour
{
    // ���� �ʵ尡 ��ȿ���� �ܺο� ����.
    public bool ValidField { get; private set; }

    // �Է��� ������ �� �Ҹ��� �̺�Ʈ �Լ�.
    public virtual void OnEndEdit(string str)
    {
        ValidField = IsValid(str);
    }

    protected virtual bool IsValid(string str)
    {
        // ���̰� 5 ~ 20�ڰ� �ƴҰ��.
        if (str.Length < 5 || 20 < str.Length)
            return false;

        // ��ҹ��� + ���� + (-),(_)
        // Regex : ����ǥ����
        Regex regex = new Regex("[a-zA-Z0-9-_]");
        return regex.Matches(str).Count == str.Length;  // ���ϰ� ��Ī�Ǵ� ������ ������ ���ٸ�..
    }
}