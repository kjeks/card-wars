using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	public GameObject placeholder = null;

	public enum Slot {MINION_FIELD, HAND};
	public Slot viablePlacement = Slot.HAND; 

	public void OnBeginDrag(PointerEventData eventData) {
		Debug.Log ("test");
		placeholder = new GameObject ();
		placeholder.transform.SetParent (this.transform.parent);

		LayoutElement layout = placeholder.AddComponent<LayoutElement> ();
		layout.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		layout.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		layout.flexibleWidth = 0;
		layout.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());


		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	public void OnDrag(PointerEventData eventData) {
		//Debug.Log ("dragging");

		this.transform.position = eventData.position;

		if (placeholder.transform.parent != placeholderParent) {

			placeholder.transform.SetParent (placeholderParent);
		}

		int newSibliingIndex = placeholderParent.childCount;

		for (int i = 0; i < placeholderParent.childCount; i++) {
			if (this.transform.position.x < placeholderParent.GetChild (i).position.x) {
				newSibliingIndex = i;

				if (placeholder.transform.GetSiblingIndex () < newSibliingIndex) {
					newSibliingIndex--;
				}
				break;
			}
		}
		placeholder.transform.SetSiblingIndex (newSibliingIndex);
	}
	public void OnEndDrag(PointerEventData eventData) {
		//Debug.Log ("end drag");
		this.transform.SetParent (parentToReturnTo);
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());
		Destroy (placeholder);

	}
}
