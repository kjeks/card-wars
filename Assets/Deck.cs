using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour {

	List <Card> orderedDeck = new List<Card>();
	Hand hand;

	// Use this for initialization
	void Start () {
		GameObject handGameObject = GameObject.Find ("Hand");
		hand = (Hand) handGameObject.GetComponent(typeof(Hand));
		populateDeckWithCards ();
		Debug.Log (orderedDeck [5]);
	}
	public void onClick () {
		hand.generateCard ();
	}
		
	public void populateDeckWithCards () {
		for(int a=0; a<10; a++) {
			Card newCard = hand.generateCard ();
			orderedDeck.Add (newCard);
		}




	}
}
