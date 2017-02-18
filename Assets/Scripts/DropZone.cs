using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	ResourceHandler resourceHandler;


	public void Start () {
		TurnController.battle += handleBattlePhase;
		TurnController.summary += handleSummaryPhase;
		GameObject resourceHandlerGO = GameObject.FindWithTag ("ResourceHandler");
		resourceHandler = resourceHandlerGO.GetComponent<ResourceHandler> ();
	}
	public void OnPointerEnter(PointerEventData eventData) {
		if(isItemSelected(eventData)) {
			Draggable selectedItem= eventData.pointerDrag.GetComponent<Draggable> ();
			Card card = eventData.pointerDrag.GetComponent<Card> ();
			if (isSpaceInDropzone () && cardCanBeDropped(card)) {
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

		if (selectedItem.initialDropZone.tag == "Hand" && this.tag == "Field") {
			playMinionFromHand (card, selectedItem);
		}else if(selectedItem.initialDropZone.tag == "Field" && this.tag == "Field") {
			cardSwitchDropzone (card, selectedItem);
		}
	}
	private void playMinionFromHand (Card card, Draggable selectedItem) {
		if(TurnController.getCurrentPhase () == TurnController.Phase.SETUP &&
			resourceHandler.canAffordCard(card) &&
			isSpaceInDropzone()){
				putCardIntoPlay (card, selectedItem);
			}
	}
	private void cardSwitchDropzone (Card card, Draggable selectedItem) {
		if (isLegalPhase(card) && isSpaceInDropzone ()) {
			selectedItem.setCurrentDropZone (this.transform);
		}
	}

	private bool isLegalPhase (Card card) {
		if (card.scouting) {
			return TurnController.getCurrentPhase () == TurnController.Phase.SETUP || TurnController.getCurrentPhase () == TurnController.Phase.REACTION;
		} else {
			return TurnController.getCurrentPhase () == TurnController.Phase.SETUP;
		}
	}
	public void putCardIntoPlay (Card card, Draggable selectedItem) {
		resourceHandler.handleMinionPlayed (card.getGoldCost(), 0);
		selectedItem.setCurrentDropZone (this.transform);
	}


	bool isItemSelected (PointerEventData eventData) {
		return eventData.pointerDrag != null;
	}

	public bool cardCanBeDropped (Card card) {
		if (isSpaceInDropzone ()) {
			if (TurnController.getCurrentPhase () == TurnController.Phase.SETUP) {
				return true;
			}
			return card.scouting && (TurnController.getCurrentPhase () == TurnController.Phase.REACTION); 
		}
		return false;
	}

	public bool isSpaceInDropzone () {
		int maxCardsInZone = 0;
		int cardsInZone = this.getCardsInZone().Count;

		if (this.tag == "Field") {
			maxCardsInZone = 3;
		}
		if(this.tag == "Hand") {
			maxCardsInZone = 7;
		}
		return cardsInZone < maxCardsInZone;
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
