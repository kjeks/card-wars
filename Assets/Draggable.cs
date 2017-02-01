using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform currentDropZone = null;
	public Transform placeholderDropZone = null;
	public GameObject placeholder = null;

	public Draggable () {
		this.currentDropZone = null;
		this.placeholderDropZone = null;
		this.placeholder = null;
	}

	public void OnBeginDrag(PointerEventData eventData) {
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		currentDropZone = this.transform.parent;
		placeholderDropZone = this.transform.parent;
	
		replaceSelectedCardWithPlaceholder ();
	}

	public void replaceSelectedCardWithPlaceholder () {
		Transform canvas = this.transform.parent.parent;
		this.transform.SetParent (canvas);
		placeholder = createPlaceholder ();
		setPlaceholderToCardSize ();
	}

	GameObject createPlaceholder () {
		placeholder = new GameObject (); 
		placeholder.transform.SetParent (this.transform.parent);
		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());

		return placeholder;
	}
	public void OnDrag(PointerEventData eventData) {
		this.transform.position = eventData.position;
		putPlaceholderInCorrectDropzone ();
		putPlaceholderInCorrectPosition ();

	}
	public void putPlaceholderInCorrectDropzone () {
		//TODO check if legal before changing placeholder pos
		if (placeholder.transform.parent != placeholderDropZone) {
			placeholder.transform.SetParent (placeholderDropZone);
		}
	}

	void putPlaceholderInCorrectPosition () {
		int correctPlaceholderPosition = findCorrectPlaceholderPosition (); 

		placeholder.transform.SetSiblingIndex (correctPlaceholderPosition);
	}

	int findCorrectPlaceholderPosition () {
		int placeholderPosition = 0;
		int numberOfCardsInZone = placeholderDropZone.childCount;
		for (int i = 0; i < numberOfCardsInZone; i++) {
			if (isDraggedItemLeftOfListItem(i)) {
				placeholderPosition = i;

				if (isPlaceholderLastInZone(placeholderPosition)) {
					placeholderPosition--;
				}
				break;
			}
			placeholderPosition = placeholderDropZone.childCount;
		}
		return placeholderPosition;
	}
	bool isPlaceholderLastInZone (int placeholderPosition) {
		return placeholder.transform.GetSiblingIndex () < placeholderPosition;
	}
	bool isDraggedItemLeftOfListItem (int i) {
		return this.transform.position.x < placeholderDropZone.GetChild (i).position.x;
	}
	public void OnEndDrag(PointerEventData eventData) {
		this.transform.SetParent (currentDropZone);
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());
		if (isLegalDropzone ()) {
			
		}
		Destroy (placeholder);

	}
	public void setPlaceholderToCardSize () {
		LayoutElement layout = placeholder.AddComponent<LayoutElement> ();
		layout.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		layout.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		layout.flexibleWidth = 0;
		layout.flexibleHeight = 0;
	}
	public void setCurrentDropZone (Transform dropZone) {
		currentDropZone = dropZone;
	}
	public Transform getCurrentDropZone () {
		return currentDropZone;
	}
	public void setPlaceholderDropZone (Transform dropZone) {
		placeholderDropZone = dropZone;
	}
	public Transform getPlaceholderDropZone () {
		return placeholderDropZone;
	}
	public bool isLegalDropzone () {
		int maxCardsInZone = 0;
		Debug.Log (currentDropZone);
		if(currentDropZone.GetType() == typeof(DropZone)) {
			maxCardsInZone = 3;
		}
		if(currentDropZone.GetType() == typeof(Hand)) {
			maxCardsInZone = 7;
		}
		return currentDropZone.transform.childCount < maxCardsInZone;
	}
}