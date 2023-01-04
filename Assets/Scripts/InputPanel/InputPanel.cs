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
        eventSystem = EventSystem.current;      // 현재 활성화 되어있는 이벤트 시스템 받기.
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            // 현재 선택 중인 오브젝트.
            GameObject current = eventSystem.currentSelectedGameObject;     
            if(current != null)
            {
                // 해당 오브젝트에게서 선택자를 검색후 하단 오브젝트를 찾는다.
                Selectable next = current.GetComponent<Selectable>()?.FindSelectableOnDown();
                if (next != null)
                    next.Select();
            }
        }
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
