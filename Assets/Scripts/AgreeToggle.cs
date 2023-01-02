using UnityEngine;
using UnityEngine.UI;

public enum AGREE_TYPE
{
    Necessary,
    Selected,
}

public class AgreeToggle : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    [SerializeField] AGREE_TYPE type;

    public bool isOn
    {
        get
        {
            return toggle.isOn;
        }
        set
        {
            toggle.isOn = value;
        }
    }

    public bool EqualsType(AGREE_TYPE type)
    {
        return this.type == type;
    }
}
