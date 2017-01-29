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

		//populateDeckWithCards ();
		addCardFromCollection();
	
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
		
//	private void populateDeckWithCards () {
//		for(int a=0; a<10; a++) {
//			Card newCard = generateCard ();
//			orderedDeck.Add (newCard);
//		}
//	}
	public void addCardFromCollection () {
		for (int a = 0; a < 3; a++) {
			string [] values = CardCollection.getCardValues(a);
			string title = values[0];
			string text = values[1];
			int attack = int.Parse(values[2]);
			int health = int.Parse(values[3]) ;
			int cost = int.Parse(values[4]); 


			Color color = GetCorrectColor(values[5]);
			foreach (string value in values) {
				orderedDeck.Add(generateCard (title, text, cost, attack, health, color));
			}
		}
	}
	public Color GetCorrectColor (string colorName){
		switch (colorName) {
		case "red":
			return Color.red;
			break;
		case "blue":
			return Color.blue;
			break;
		case "green":
			return Color.green;
			break;
		default:
			return Color.black;
		}
	}

	public Card drawCardFromDeck () {
		Card drawnCard = orderedDeck [0];
		orderedDeck.RemoveAt(0);
		return drawnCard;
	}
}
