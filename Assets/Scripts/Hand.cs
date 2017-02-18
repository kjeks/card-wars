using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : DropZone {

	public void addCardToHand (Card card) {
		card.transform.SetParent (this.transform);
	}
}
