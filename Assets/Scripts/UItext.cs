using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// author: chelsea houston
// date last modified: 01/12/23
public class UItext : MonoBehaviour
{
    public GameObject NeedsIcon, TasksIcon;
    public TextMeshProUGUI NeedsTMP, TasksTMP;


    // Start is called before the first frame update
    void Start()
    {
        // set to inactive on start
        DisableIcons();
    }

    public void SetIconsActive()
    {
        SetIconActive(TasksIcon);
        SetIconActive(NeedsIcon);
    }

    public void DisableIcons()
    {
        SetIconInactive(TasksIcon);
        SetIconInactive(NeedsIcon);
    }

    private void SetIconActive(GameObject icon)
    {
        // set icon as active but not the text child
        icon.SetActive(true);
        SetTextInactive(icon);
    }

    private void SetIconInactive(GameObject icon)
    {
        icon.SetActive(false);
    }

    public void SetTextActive(GameObject icon) // set text child of GO to active (on hover)
    {
        icon.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SetTextInactive(GameObject icon) // set text child of GO to inactive (on mouse off and on parent activation)
    {
        icon.transform.GetChild(0).gameObject.SetActive(false);
    }


}
