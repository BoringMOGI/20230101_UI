using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class InputField : InputFieldRoot
{
    // 현재 필드가 유효한지 외부에 공개.
    public bool IsValidField { get; private set; }

    // 입력이 끝났을 때 불리는 이벤트 함수.
    public virtual void OnEndEdit(string str)
    {
        IsValidField = IsValid(str);

        if (IsValidField)
            SetResultText("멋진 아이디네요!", Color.green);
        else
            SetResultText("5~20자의 영문 소문자, 숫자와 특수기호(_),(-)만 사용 가능합니다.", Color.red);
    }

    protected virtual bool IsValid(string str)
    {
        // 길이가 5 ~ 20자가 아닐경우.
        if (str.Length < 5 || 20 < str.Length)
            return false;

        // 대소문자 + 숫자 + (-),(_)
        // Regex : 정규표현식
        Regex regex = new Regex("[a-zA-Z0-9-_]");
        return regex.Matches(str).Count == str.Length;  // 패턴과 매칭되는 글자의 개수가 같다면..
    }
}