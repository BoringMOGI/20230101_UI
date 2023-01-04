using TMPro;
using UnityEngine;

public class InputFieldRoot : MonoBehaviour
{
    [SerializeField] protected TMP_Text resultText;             // ��� �ؽ�Ʈ.
    [SerializeField] protected RectTransform[] childRects;      // �ڽ� Rect��.

    protected RectTransform rectTransform;     // ���� Rect.

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        resultText.gameObject.SetActive(false);     // ��� �ؽ�Ʈ ����.
        UpdateHeight();                             // ���� ����.
    }

    protected void SetResultText(string str, Color color)
    {
        // str�� ��������� ��� �ؽ�Ʈ�� ����.
        resultText.gameObject.SetActive(!string.IsNullOrEmpty(str));
        resultText.text = str;
        resultText.color = color;
        
        UpdateHeight();
    }

    protected void UpdateHeight()
    {
        float height = 0f;
        int activeCount = 0;

        // �ڽĵ� �߿��� Ȱ��ȭ �Ǿ��ִ� Rect�� height�� ���Ѵ�.
        for(int i = 0; i<childRects.Length; i++) 
        {
            if (childRects[i].gameObject.activeSelf)
            {
                height += childRects[i].sizeDelta.y;
                activeCount += 1;
            }
        }

        // Ȱ��ȭ ������Ʈ������ ����.
        height += 10 * (activeCount - 1);


        // �� ���̸� �����Ѵ�.
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);

        // root ������Ʈ�� ���� Hight ũ�⸦ �����Ѵ�.
        InputPanel.Instance.OnChangeContentHeight();
    }
}
