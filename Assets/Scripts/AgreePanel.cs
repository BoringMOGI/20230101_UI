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
        // sub버튼을 누른 뒤 모두 활성화되어있는지 확인.
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
            Debug.Log("필수항목을 체크해주세요");
            errorText.text = "필수 항목을 체크해주세요.";
        }
        else
        {
            Debug.Log("다음 창으로 넘어가기");
        }
    }
}
