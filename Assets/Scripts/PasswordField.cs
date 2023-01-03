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
        None,           // 아무것도 아님.
        NotValid,       // 유효하지 않음.
        Warning,        // 주의.
        Valid,          // 유효함.
    }

    [SerializeField] Image lockImage;
    [SerializeField] TMP_Text lockText;
    [SerializeField] Color[] lockColors;

    IEnumerable<int> signGroup;     // 특수기호 그룹.
    
    readonly string[] lockContext = { string.Empty, "사용불가", "위험", "안전" };

    private void Start()
    {
        // 초기 색상과 텍스트 대입.
        lockImage.color = lockColors[(int)VALID_TYPE.None];
        lockText.text = lockContext[(int)VALID_TYPE.None];

        // 특수 기호 집합체.
        signGroup = Enumerable.Range(33, 47 - 33);
        signGroup.Union(Enumerable.Range(58, 64 - 58));
        signGroup.Union(Enumerable.Range(91, 96 - 91));
        signGroup.Union(Enumerable.Range(123, 126 - 123));
    }

    public override void OnEndEdit(string str)
    {
        base.OnEndEdit(str);

        VALID_TYPE validType = VALID_TYPE.None;

        // 대소문자,특수기호,숫자가 모두 들어가면 안전.
        // 그렇지 않으면 위험.
        if (ValidField)
            validType = IsSafe(str) ? VALID_TYPE.Valid : VALID_TYPE.Warning;
        else
            validType = VALID_TYPE.NotValid;

        // 비밀번호 상태에 따라 색상과 텍스트 변경.
        lockImage.color = lockColors[(int)validType];
        lockText.color = lockColors[(int)validType];
        lockText.text = lockContext[(int)validType];
    }

    // 패스워드 필드는 모든 특수문자를 포함시킨다.
    protected override bool IsValid(string str)
    {
        if (str.Length < 5 || 20 < str.Length)
            return false;

        Regex regex = new Regex(@"[a-zA-Z0-9~!@#$%^&*()_+|[\]{};':,.<>/?\-=]");
        return regex.Matches(str).Count == str.Length;
    }

    // 안전한가? 위험한가?
    private bool IsSafe(string str)
    {
        // 안전 : 대문자,소문자,숫자,특수기호가 최소 1개 이상씩 다 들어가야한다.

        // Regex 특수 문자.
        // +는 앞에 오는 문자가 1회 이상 반복되고 있는지를 체크한다.
        // -는 범위 지정자이며 앞,뒤 문자의 사이 값을 전부 받는다.
        // []는 그룹으로 해당 안에 들어있는 문자가 그룹이 된다.

        Regex regex = new Regex("[a-z]+[A-Z]+[0-9]+[~!@#$%^&*()_+|[\\]{};':,.<>/?\\-=]+");
        Debug.Log($"{str}({str.Length})");
        Debug.Log(regex.IsMatch(str));
        return regex.IsMatch(str);
    }
}
