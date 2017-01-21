using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public draggable.Slot viablePlacement = draggable.Slot.MINION_FIELD;

	public void OnDrop(PointerEventData eventData) {
		Debug.Log (eventData.pointerDrag.name + " dropped onto " + gameObject.name);
		var currentDragged = eventData.pointerDrag.GetComponent<draggable> ();
		if(currentDragged != null) {
				currentDragged.parentToReturnTo = this.transform;

		}


	}
	public void OnPointerEnter(PointerEventData eventData) {
		if(eventData.pointerDrag == null) {
			return;
		}
		var currentDragged = eventData.pointerDrag.GetComponent<draggable> ();
		if(currentDragged != null) {
			currentDragged.placeholderParent = this.transform;
		}
	}
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log ("onPointerExit");
		if(eventData.pointerDrag == null) {
			return;
		}
		var currentDragged = eventData.pointerDrag.GetComponent<draggable> ();

		if(currentDragged != null && currentDragged.placeholderParent==this.transform) {

				currentDragged.placeholderParent = currentDragged.parentToReturnTo;

		}
	}
}
