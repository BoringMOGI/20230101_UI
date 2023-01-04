using TMPro;
using UnityEngine;

public class InputFieldRoot : MonoBehaviour
{
    [SerializeField] protected TMP_Text resultText;             // 결과 텍스트.
    [SerializeField] protected RectTransform[] childRects;      // 자식 Rect들.

    protected RectTransform rectTransform;     // 나의 Rect.

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        resultText.gameObject.SetActive(false);     // 결과 텍스트 끄고.
        UpdateHeight();                             // 높이 재계산.
    }

    protected void SetResultText(string str, Color color)
    {
        // str이 비어있으면 결과 텍스트를 끈다.
        resultText.gameObject.SetActive(!string.IsNullOrEmpty(str));
        resultText.text = str;
        resultText.color = color;
        
        UpdateHeight();
    }

    protected void UpdateHeight()
    {
        float height = 0f;
        int activeCount = 0;

        // 자식들 중에서 활성화 되어있는 Rect의 height를 더한다.
        for(int i = 0; i<childRects.Length; i++) 
        {
            if (childRects[i].gameObject.activeSelf)
            {
                height += childRects[i].sizeDelta.y;
                activeCount += 1;
            }
        }

        // 활성화 오브젝트끼리의 간격.
        height += 10 * (activeCount - 1);


        // 총 높이를 대입한다.
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);

        // root 오브젝트의 최종 Hight 크기를 갱신한다.
        InputPanel.Instance.OnChangeContentHeight();
    }
}
