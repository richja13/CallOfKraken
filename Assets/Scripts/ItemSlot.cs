using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    public DragAndDrop dragAndDrop;
    public bool isEmpty = true;
    // Start is called before the first frame update
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            if(isEmpty)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
               
            }
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
       // GetComponent<Image>().raycastTarget = false;
        if(dragAndDrop.DraggingItem == true)
        {
            if(isEmpty == false)
            {
                isEmpty = true;
            }
            else
            {
                isEmpty = false;
            }
        }
        
    }

    public void Update()
    {
        Debug.Log(isEmpty);
    }
  
}
