using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionSlot : MonoBehaviour, IDropHandler {
    [SerializeField] GameObject actionHolder;
    private bool validate(GameObject dragItem) {   
        return !((dragItem.name.ToUpper() == "ACTIONFUNCTION(CLONE)") && (transform.parent.gameObject.name.ToUpper() == "ACTIONFUNCTIONLIST") || (transform.childCount != 0));
    }

    public void OnDrop(PointerEventData eventData) {
        if (eventData == null) return;
        GameObject dropped = eventData.pointerDrag;
        DragAndDrop draggableItem = dropped.GetComponent<DragAndDrop>();
        if (draggableItem == null) return;
        RectTransform rectTransform = dropped.GetComponent< RectTransform >();

        // Remove action from for loop
        if (draggableItem.parentAfterDrag.name.ToUpper() == "ACTIONHOLDER(CLONE)" && transform.name.ToUpper() == "ACTIONSLOT(CLONE)") {

            // Resize previous action slot 
            GameObject oldActionSlot = draggableItem.parentAfterDrag.parent.parent.gameObject;
            RectTransform oldActionSlotRT = oldActionSlot.GetComponent<RectTransform>();
            if (oldActionSlot.transform.GetChild(0).childCount > 3) {
                oldActionSlotRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100 * (oldActionSlot.transform.GetChild(0).childCount - 2));
            }
            else {
                oldActionSlotRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
            }
            
            // Delete action slot 
            Destroy(draggableItem.parentAfterDrag.gameObject);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
        }

        // Add action to for loop
        if (transform.childCount != 0) {
            GameObject children = transform.GetChild(0).gameObject;
            if (children.name.ToUpper() == "ACTIONFOR(CLONE)") {
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);

                GameObject InstantiatedActionHolder = Instantiate(actionHolder);
                InstantiatedActionHolder.transform.SetParent(children.transform);
                
                draggableItem.parentAfterDrag = InstantiatedActionHolder.transform;
                draggableItem.parentAfterDrag.position = new Vector3(50, -50, 0);

                // Resize action slot to expand fit with children inside
                RectTransform actionSlotRectTransform = gameObject.GetComponent< RectTransform >();

                if (children.transform.childCount > 2) {
                    actionSlotRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100 * (children.transform.childCount - 1));
                }
                else {
                    actionSlotRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                }

                return;
            }
        }

        if (validate(dropped)) {

            // Resize previous action slot and new action slot size when move action for
            if (dropped.name.ToUpper() == "ACTIONFOR(CLONE)") {
                //previous action slot
                RectTransform actionSlotRectTransform = draggableItem.parentAfterDrag.gameObject.GetComponent<RectTransform>();
                actionSlotRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                actionSlotRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);

                //new action slot
                actionSlotRectTransform = transform.GetComponent<RectTransform>();
                
                if (dropped.transform.childCount > 2) {
                    actionSlotRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100 * (dropped.transform.childCount - 1));
                }
                else {
                    actionSlotRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                }
            }

            draggableItem.parentAfterDrag = transform;
            draggableItem.parentAfterDrag.position = new Vector3(50, -50, 0);
        }
    }
}
