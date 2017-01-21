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
			if (viablePlacement == currentDragged.viablePlacement) {
				currentDragged.parentToReturnTo = this.transform;
			}

		}
	}
	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log ("onPointerEnter");
	}
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log ("onPointerExit");
	}
}
