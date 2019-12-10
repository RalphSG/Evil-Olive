using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    public void ClickSound() {
        FindObjectOfType<audiomanager>().Play("ButtonClick");
    }

    public void StartLevels()
    {
        FindObjectOfType<audiomanager>().Play("Door");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FindObjectOfType<audiomanager>().Play("ButtonHover");
    }
}
