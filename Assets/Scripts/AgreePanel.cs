using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AgreePanel : MonoBehaviour
{
    [SerializeField] Text errorText;
    [SerializeField] Toggle mainToggle;
    [SerializeField] Toggle[] subToggles;


    public void OnMainToggle()
    {
        bool isOn = mainToggle.isOn;
        for(int i = 0; i<subToggles.Length; i++)
            subToggles[i].isOn = isOn;
    }
    public void OnToggle()
    {
        // sub��ư�� ���� �� ��� Ȱ��ȭ�Ǿ��ִ��� Ȯ��.
        int onCount = subToggles.Where(sub => sub.isOn).Count();
        Debug.Log(subToggles.Length);
        Debug.Log(onCount);
        mainToggle.isOn = onCount >= subToggles.Length;
    }
    public void OnSubmit()
    {
        var agreeCount = subToggles.Where(sub => sub.tag.Equals("Sign")).Count();
        int selectedCount = subToggles.Where(sub => sub.GetComponent<Toggle>().isOn).Count();
        Debug.Log(selectedCount);

        if(selectedCount <= 0)
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
