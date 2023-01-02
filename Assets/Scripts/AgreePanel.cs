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

        // sub버튼을 누른 뒤 모두 활성화되어있는지 확인.
        int onCount = subToggles.Where(sub => sub.isOn).Count();
        mainToggle.isOn = onCount >= subToggles.Length;

        isPressToggle = false;
    }
    public void OnSubmit()
    {
        // 필수 토글만 검색한다.
        var neccesaryToggles = subToggles.Where(sub => sub.EqualsType(AGREE_TYPE.Necessary));

        // 필요한 체크 개수와 내가 체크한 개수를 검색한다.
        int needCount = neccesaryToggles.Count();
        int selectedCount = neccesaryToggles.Where(sub => sub.isOn).Count();

        if(selectedCount < needCount)
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
