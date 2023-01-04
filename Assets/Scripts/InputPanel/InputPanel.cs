using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputPanel : MonoBehaviour
{
    public static InputPanel Instance { get; private set; }

    [SerializeField] ContentSizeFitter sizeFitter;

    EventSystem eventSystem;

    private void Awake()
    {
        Instance = this;
        eventSystem = EventSystem.current;      // ���� Ȱ��ȭ �Ǿ��ִ� �̺�Ʈ �ý��� �ޱ�.
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            // ���� ���� ���� ������Ʈ.
            GameObject current = eventSystem.currentSelectedGameObject;     
            if(current != null)
            {
                // �ش� ������Ʈ���Լ� �����ڸ� �˻��� �ϴ� ������Ʈ�� ã�´�.
                Selectable next = current.GetComponent<Selectable>()?.FindSelectableOnDown();
                if (next != null)
                    next.Select();
            }
        }
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
