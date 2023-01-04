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

    // �������� ���̰� ����Ǵ� �̺�Ʈ �Լ�.
    public void OnChangeContentHeight()
    {
        StartCoroutine(IEChangeContentHeight());
    }
    private IEnumerator IEChangeContentHeight()
    {
        // Fitter���� ������ ��Ų��.
        sizeFitter.enabled = false;
        yield return null;
        sizeFitter.enabled = true;
    }
}