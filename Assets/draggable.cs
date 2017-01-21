using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform parentToReturnTo = null;

	public enum Slot {MINION_FIELD, HAND};
	public Slot viablePlacement = Slot.HAND; 

	public void OnBeginDrag(PointerEventData eventData) {
		Debug.Log ("test");
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	public void OnDrag(PointerEventData eventData) {
		//Debug.Log ("dragging");

		this.transform.position = eventData.position;
	}
	public void OnEndDrag(PointerEventData eventData) {
		//Debug.Log ("end drag");
		this.transform.SetParent (parentToReturnTo);
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}
}
