using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public bool DraggingItem;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

   public void OnPointerDown(PointerEventData eventData)
   {
       Debug.Log("OnPointerDown");
       DraggingItem = true;
       
   }

   public void OnBeginDrag(PointerEventData eventData)
   {
       canvasGroup.blocksRaycasts = false;
       canvasGroup.alpha = .6f;
   }

    public void OnEndDrag(PointerEventData eventData)
   {
       canvasGroup.blocksRaycasts = true;
       canvasGroup.alpha = 1f;
   }

   public void OnDrag(PointerEventData eventData)
   {
       rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor /0.6999975f;
   }

   public void OnDrop(PointerEventData eventData)
   {
       DraggingItem = false;
   }


}
