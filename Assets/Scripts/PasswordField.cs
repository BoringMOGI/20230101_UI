using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordField : InputField
{
    private enum VALID_TYPE
    {
        None,           // �ƹ��͵� �ƴ�.
        NotValid,       // ��ȿ���� ����.
        Warning,        // ����.
        Valid,          // ��ȿ��.
    }

    [SerializeField] Image lockImage;
    [SerializeField] TMP_Text lockText;
    [SerializeField] Color[] lockColors;

    IEnumerable<int> signGroup;     // Ư����ȣ �׷�.
    
    readonly string[] lockContext = { string.Empty, "���Ұ�", "����", "����" };

    private void Start()
    {
        // �ʱ� ����� �ؽ�Ʈ ����.
        lockImage.color = lockColors[(int)VALID_TYPE.None];
        lockText.text = lockContext[(int)VALID_TYPE.None];

        // Ư�� ��ȣ ����ü.
        signGroup = Enumerable.Range(33, 47 - 33);
        signGroup.Union(Enumerable.Range(58, 64 - 58));
        signGroup.Union(Enumerable.Range(91, 96 - 91));
        signGroup.Union(Enumerable.Range(123, 126 - 123));
    }

    public override void OnEndEdit(string str)
    {
        base.OnEndEdit(str);

        VALID_TYPE validType = VALID_TYPE.None;

        // ��ҹ���,Ư����ȣ,���ڰ� ��� ���� ����.
        // �׷��� ������ ����.
        if (ValidField)
            validType = IsSafe(str) ? VALID_TYPE.Valid : VALID_TYPE.Warning;
        else
            validType = VALID_TYPE.NotValid;

        // ��й�ȣ ���¿� ���� ����� �ؽ�Ʈ ����.
        lockImage.color = lockColors[(int)validType];
        lockText.color = lockColors[(int)validType];
        lockText.text = lockContext[(int)validType];
    }

    // �н����� �ʵ�� ��� Ư�����ڸ� ���Խ�Ų��.
    protected override bool IsValid(string str)
    {
        if (str.Length < 5 || 20 < str.Length)
            return false;

        Regex regex = new Regex(@"[a-zA-Z0-9~!@#$%^&*()_+|[\]{};':,.<>/?\-=]");
        return regex.Matches(str).Count == str.Length;
    }

    // �����Ѱ�? �����Ѱ�?
    private bool IsSafe(string str)
    {
        // ���� : �빮��,�ҹ���,����,Ư����ȣ�� �ּ� 1�� �̻� �� �����Ѵ�.

        // Regex Ư�� ����.
        // +�� �տ� ���� ���ڰ� 1ȸ �̻� �ݺ��ǰ� �ִ����� üũ�Ѵ�.
        // -�� ���� �������̸� ��,�� ������ ���� ���� ���� �޴´�.
        // []�� �׷����� �ش� �ȿ� ����ִ� ���ڰ� �׷��� �ȴ�.

        Regex regex = new Regex("[a-z]+[A-Z]+[0-9]+[~!@#$%^&*()_+|[\\]{};':,.<>/?\\-=]+");
        Debug.Log($"{str}({str.Length})");
        Debug.Log(regex.IsMatch(str));
        return regex.IsMatch(str);
    }
}
