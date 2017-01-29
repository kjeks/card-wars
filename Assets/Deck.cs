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
	public Card generateCard (string title, string text, int cost, int attack, int health, Color color) {
		GameObject gameObject = (GameObject)Instantiate (Resources.Load ("Card"));
		Card generatedCard= gameObject.GetComponent<Card> ();

		generatedCard.setValues (title, text, cost, attack, health, color);

		return generatedCard;
	}
	public void onClick () {
		Card newCard = drawCardFromDeck ();

		hand.addCardToHand (newCard);
	}
		
	public void addRandomCardFromCollection () {
		int randomCardId = (int)(Random.value * CardCollection.getCollectionSize ());
		string [] values = CardCollection.getCardValues(randomCardId);
		string title = values[0];
		string text = values[1];
		int attack = int.Parse(values[2]);
		int health = int.Parse(values[3]) ;
		int cost = int.Parse(values[4]); 
		Color color = GetCorrectColor(values[5]);

		orderedDeck.Add(generateCard (title, text, cost, attack, health, color));
	}

	public Color GetCorrectColor (string colorName){
		switch (colorName) {
		case "red":
			return Color.red;
		case "blue":
			return Color.blue;
		case "green":
			return Color.green;
		default:
			return Color.black;
		}
	}
	public void populateDeckWithCards () {
		while (orderedDeck.Count < 30) {
			addRandomCardFromCollection ();
		}
	}


	public Card drawCardFromDeck () {
		Card drawnCard = orderedDeck [0];
		orderedDeck.RemoveAt(0);
		return drawnCard;
	}
}
