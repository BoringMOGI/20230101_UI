using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;




public class AgreePanel : MonoBehaviour
{
    [SerializeField] Text errorText;
    [SerializeField] Toggle mainToggle;
    [SerializeField] AgreeToggle[] subToggles;

    bool isPressToggle;

    public void OnMainToggle()
    {
        if (isPressToggle)
            return;

        isPressToggle = true;

        bool isOn = mainToggle.isOn;
        for(int i = 0; i<subToggles.Length; i++)
            subToggles[i].isOn = isOn;

        isPressToggle = false;
    }
    public void OnSubToggle()
    {
        if (isPressToggle)
            return;

        isPressToggle = true;

        // sub��ư�� ���� �� ��� Ȱ��ȭ�Ǿ��ִ��� Ȯ��.
        int onCount = subToggles.Where(sub => sub.isOn).Count();
        mainToggle.isOn = onCount >= subToggles.Length;

        isPressToggle = false;
    }
    public void OnSubmit()
    {
        // �ʼ� ��۸� �˻��Ѵ�.
        var neccesaryToggles = subToggles.Where(sub => sub.EqualsType(AGREE_TYPE.Necessary));

        // �ʿ��� üũ ������ ���� üũ�� ������ �˻��Ѵ�.
        int needCount = neccesaryToggles.Count();
        int selectedCount = neccesaryToggles.Where(sub => sub.isOn).Count();

        if(selectedCount < needCount)
        {
            Debug.Log("�ʼ��׸��� üũ���ּ���");
            errorText.text = "�ʼ� �׸��� üũ���ּ���.";
        }
        else
        {
            Debug.Log("���� â���� �Ѿ��");
        }
    }
}
