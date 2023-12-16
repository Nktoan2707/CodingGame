using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler {
    [SerializeField] Canvas canvas;
    CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private RectTransform oldTransform;
    public void OnBeginDrag(PointerEventData eventData) { 
       Debug.Log("OnBeginDrag");
       canvasGroup.alpha = 0.6f;
       canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        rectTransform.anchoredPosition = oldTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData) { 
       Debug.Log("OnEndDrag");
       canvasGroup.alpha = 1f;
       canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
        oldTransform = rectTransform;
    }

    void Awake() {
        rectTransform = gameObject.GetComponent<RectTransform>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
