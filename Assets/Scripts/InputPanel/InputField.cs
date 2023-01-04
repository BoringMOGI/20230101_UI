using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class InputField : InputFieldRoot
{
    // ���� �ʵ尡 ��ȿ���� �ܺο� ����.
    public bool IsValidField { get; private set; }

    // �Է��� ������ �� �Ҹ��� �̺�Ʈ �Լ�.
    public virtual void OnEndEdit(string str)
    {
        IsValidField = IsValid(str);

        if (IsValidField)
            SetResultText("���� ���̵�׿�!", Color.green);
        else
            SetResultText("5~20���� ���� �ҹ���, ���ڿ� Ư����ȣ(_),(-)�� ��� �����մϴ�.", Color.red);
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