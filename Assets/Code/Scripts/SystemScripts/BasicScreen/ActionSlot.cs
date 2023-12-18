using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionSlot : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0) {
            GameObject dropped = eventData.pointerDrag;
            DragAndDrop draggableItem = dropped.GetComponent<DragAndDrop>();
            draggableItem.parentAfterDrag = transform;
            Debug.Log(draggableItem.parentAfterDrag.position);
            draggableItem.parentAfterDrag.position = new Vector3(50, -50, 0);
        }
    }
}
