using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    [SerializeField] Canvas canvas;
    CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    Transform parentAfterDrag;
    
    public void OnBeginDrag(PointerEventData eventData) { 
       Debug.Log("OnBeginDrag");
       canvasGroup.alpha = 0.6f;
       canvasGroup.blocksRaycasts = false;
       parentAfterDrag = transform.parent;
       transform.SetParent(transform.root);
       transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) { 
       Debug.Log("OnEndDrag");
       canvasGroup.alpha = 1f;
       canvasGroup.blocksRaycasts = true;
       transform.SetParent(parentAfterDrag);
    }

    void Awake() {
        rectTransform = gameObject.GetComponent<RectTransform>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
