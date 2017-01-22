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
		Card selectedItem = eventData.pointerDrag.GetComponent<Card> ();
		selectedItem.setPlaceholderDropZone (this.transform);
	}
	public void OnPointerExit(PointerEventData eventData) {
		if(isItemSelected(eventData)) {
			putPlaceholderInInitialDropZone (eventData);
		}
	}
	void putPlaceholderInInitialDropZone (PointerEventData eventData) {
		var selectedItem = eventData.pointerDrag.GetComponent<Card> ();

		if(selectedItem != null && selectedItem.placeholderDropZone==this.transform) {
			selectedItem.setPlaceholderDropZone (selectedItem.getCurrentDropZone ());
		}
	}
	public void OnDrop(PointerEventData eventData) {
		Card selectedItem = eventData.pointerDrag.GetComponent<Card> ();
		selectedItem.setCurrentDropZone (this.transform);
	}
	bool isItemSelected (PointerEventData eventData) {
		return eventData.pointerDrag != null;
	}
}
