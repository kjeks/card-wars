using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void Start () {
		TurnController.battle += handleBattlePhase;
		TurnController.summary += handleSummaryPhase;
	}
	public void OnPointerEnter(PointerEventData eventData) {
		if(isItemSelected(eventData)) {
			Draggable selectedItem = eventData.pointerDrag.GetComponent<Draggable> ();
			if (isSpaceInDropzone (this)) {
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
		Card card = eventData.pointerDrag.GetComponent<Card> ();
		if(isSpaceInDropzone(this) && cardCanBeDropped(card)) {
			selectedItem.setCurrentDropZone (this.transform);
		}
	}

	bool isItemSelected (PointerEventData eventData) {
		return eventData.pointerDrag != null;
	}
	public bool isSpaceInDropzone (DropZone dropZone) {
		TurnController.getCurrentPhase ();
		int maxCardsInZone = 0;
		int cardsInZone = dropZone.getCardsInZone().Count;

		if (dropZone.tag == "Field") {
			maxCardsInZone = 3;
		}
		if(dropZone.tag == "Hand") {
			maxCardsInZone = 7;
		}
		return cardsInZone < maxCardsInZone;
	}

	public bool cardCanBeDropped (Card card) {
		if (TurnController.getCurrentPhase () == TurnController.Phase.SETUP) {
			return true;
		}
		return card.scouting && (TurnController.getCurrentPhase () == TurnController.Phase.REACTION); 
	}
	public List <Card> getCardsInZone () {
		List<Card> cardList = new List<Card>();

		foreach (Transform child in this.transform) {
			if (child.tag == "Card") {
				cardList.Add (child.GetComponent<Card>());
			}
		}
		return cardList;
	}
	public void handleBattlePhase () {
		int damageDealth = 0;
		List <Card> cardsInZone = getCardsInZone ();
		if (this.tag == "Field") {
			foreach(Card card in cardsInZone) {
				damageDealth = damageDealth + int.Parse (card.attack.text);
			}
		}
	}
	public void handleSummaryPhase () {
		int damageReceived = 6;
		List <Card> cardsInZone = getCardsInZone ();
		if (this.tag == "Field") {
			while (damageReceived > 0 && cardsInZone.Count > 0) {
				Card cardReceivingDamage = cardsInZone [0];
				int health = int.Parse (cardReceivingDamage.health.text);

				if (damageReceived >= health) {
					damageReceived = damageReceived - health;
					cardsInZone.Remove (cardReceivingDamage);
					Destroy (cardReceivingDamage.gameObject);
				} else {
					cardReceivingDamage.health.text = (health - damageReceived).ToString ();
					break;
				}
			}
		}
	}
}
