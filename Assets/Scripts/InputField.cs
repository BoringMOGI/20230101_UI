using System.Linq;
using UnityEngine;

public class InputField : MonoBehaviour
{

    public void OnEndEdit(string str)
    {
        bool isValid = IsValid(str);
        Debug.Log(isValid);
    }
    private bool IsValid(string str)
    {
        // 길이가 5 ~ 20자가 아닐경우.
        if (str.Length < 5 || 20 < str.Length)
            return false;

        // 33~126까지의 배열 중에서 exception을 뺀다 (차집합)
        //var validChar = Enumerable.Range(65, 122 - 65).Except(exception);
        var validChar = Enumerable.Range(65, 122 - 65).Union(Enumerable.Range(48, 57 - 48));

        // 특수 기호 (-),(_)를 포함시킨다.
        validChar = validChar.Union(Enumerable.Range(45, 2));

        for(int i = 0; i<str.Length; i++)
        {
            // 검색한 유효 문자 배열 중에서 str의 i번째 값이 포함되어 있지 않다면...
            if (!validChar.Contains(str[i]))
                return false;
        }

        return true;
    }
}
