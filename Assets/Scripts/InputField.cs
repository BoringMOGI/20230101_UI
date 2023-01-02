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
        // ���̰� 5 ~ 20�ڰ� �ƴҰ��.
        if (str.Length < 5 || 20 < str.Length)
            return false;

        // 33~126������ �迭 �߿��� exception�� ���� (������)
        //var validChar = Enumerable.Range(65, 122 - 65).Except(exception);
        var validChar = Enumerable.Range(65, 122 - 65).Union(Enumerable.Range(48, 57 - 48));

        // Ư�� ��ȣ (-),(_)�� ���Խ�Ų��.
        validChar = validChar.Union(Enumerable.Range(45, 2));

        for(int i = 0; i<str.Length; i++)
        {
            // �˻��� ��ȿ ���� �迭 �߿��� str�� i��° ���� ���ԵǾ� ���� �ʴٸ�...
            if (!validChar.Contains(str[i]))
                return false;
        }

        return true;
    }
}
