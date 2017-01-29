using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour {

	List <Card> orderedDeck = new List<Card>();
	Hand hand;
	GameObject handGO;

	// Use this for initialization
	void Start () {
		handGO = GameObject.Find ("Hand");
		hand = (Hand) handGO.GetComponent(typeof(Hand));
		populateDeckWithCards ();
	
	}
	public Card generateCard () {
		GameObject gameObject = (GameObject)Instantiate (Resources.Load ("Card"));
		Card generatedCard= gameObject.GetComponent<Card> ();
		string title = "new title";
		string text = "this is the card text";
		int attack = (int) (Random.value * 10);
		int health = 2;
		Color color = Random.ColorHSV (0f, 1f, 1f, 1f, 0.3f, 1f);

		generatedCard.setValues (title, text, attack, health, color);

		return generatedCard;
	}
	public void onClick () {
		Card newCard = drawCardFromDeck ();

		hand.addCardToHand (newCard);
	}
		
	private void populateDeckWithCards () {
		for(int a=0; a<10; a++) {
			Card newCard = generateCard ();
			orderedDeck.Add (newCard);
		}
	}

	public Card drawCardFromDeck () {
		Card drawnCard = orderedDeck [0];
		orderedDeck.RemoveAt(0);
		return drawnCard;
	}
}
