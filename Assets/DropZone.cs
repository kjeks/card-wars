using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData) {
		if(isItemSelected(eventData)) {
			Draggable selectedItem = eventData.pointerDrag.GetComponent<Draggable> ();
			if (isLegalDropzone (this)) {
				selectedItem.setPlaceholderDropZone (this.transform);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
		if(isItemSelected(eventData)) {
			putPlaceholderInInitialDropZone (eventData);
		}
	}
	void putPlaceholderInInitialDropZone (PointerEventData eventData) {
		var selectedItem = eventData.pointerDrag.GetComponent<Draggable> ();

		if(selectedItem.placeholderDropZone==this.transform) {
			selectedItem.setPlaceholderDropZone (selectedItem.getCurrentDropZone ());
		}
	}
	public void OnDrop(PointerEventData eventData) {
		Draggable selectedItem = eventData.pointerDrag.GetComponent<Draggable> ();
		if(isLegalDropzone(this)) {
			selectedItem.setCurrentDropZone (this.transform);
		}
	}
	bool isItemSelected (PointerEventData eventData) {
		return eventData.pointerDrag != null;
	}
	public bool isLegalDropzone (DropZone dropZone) {
		int maxCardsInZone = 0;
		int cardsInZone = 0;
		foreach (Transform child in dropZone.transform) {
			if (child.tag == "Card") {
				cardsInZone = cardsInZone + 1;
			}
		}
		if (dropZone.tag == "Field") {
			maxCardsInZone = 3;
		}
		if(dropZone.tag == "Hand") {
			maxCardsInZone = 7;
		}
		return cardsInZone < maxCardsInZone;
	}
}
