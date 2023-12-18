using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public UnityEngine.UI.Image image;
    [HideInInspector] public Transform parentAfterDrag;
    
    public void OnBeginDrag(PointerEventData eventData) { 
       canvasGroup.alpha = 0.6f;
       canvasGroup.blocksRaycasts = false;
       parentAfterDrag = transform.parent;
       transform.SetParent(transform.root);
       transform.SetAsLastSibling();
       image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) { 
       canvasGroup.alpha = 1f;
       canvasGroup.blocksRaycasts = true;
       transform.SetParent(parentAfterDrag);
       image.raycastTarget = true;
    }

    void Awake() {
        rectTransform = gameObject.GetComponent<RectTransform>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        image = gameObject.GetComponent<UnityEngine.UI.Image>();
    }
}
