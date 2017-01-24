using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData) {
		if(isItemSelected(eventData)) {
			putPlaceholderInDropZone (eventData);
		}
	}
	void putPlaceholderInDropZone (PointerEventData eventData) {
		Draggable selectedItem = eventData.pointerDrag.GetComponent<Draggable> ();
		selectedItem.setPlaceholderDropZone (this.transform);
	}
	public void OnPointerExit(PointerEventData eventData) {
		if(isItemSelected(eventData)) {
			putPlaceholderInInitialDropZone (eventData);
		}
	}
	void putPlaceholderInInitialDropZone (PointerEventData eventData) {
		var selectedItem = eventData.pointerDrag.GetComponent<Draggable> ();

		if(selectedItem != null && selectedItem.placeholderDropZone==this.transform) {
			selectedItem.setPlaceholderDropZone (selectedItem.getCurrentDropZone ());
		}
	}
	public void OnDrop(PointerEventData eventData) {
		Draggable selectedItem = eventData.pointerDrag.GetComponent<Draggable> ();
		selectedItem.setCurrentDropZone (this.transform);
	}
	bool isItemSelected (PointerEventData eventData) {
		return eventData.pointerDrag != null;
	}
}
