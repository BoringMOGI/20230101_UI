using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPanel : MonoBehaviour
{
    public static InputPanel Instance { get; private set; }

    [SerializeField] ContentSizeFitter sizeFitter;

    private void Awake()
    {
        Instance = this; 
    }

    // 컨텐츠의 높이가 변경되는 이벤트 함수.
    public void OnChangeContentHeight()
    {
        StartCoroutine(IEChangeContentHeight());
    }
    private IEnumerator IEChangeContentHeight()
    {
        // Fitter에게 재계산을 시킨다.
        sizeFitter.enabled = false;
        yield return null;
        sizeFitter.enabled = true;
    }
}
