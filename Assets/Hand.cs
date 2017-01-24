using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : DropZone {

	public void generateCard () {
		GameObject gameObject = (GameObject)Instantiate (Resources.Load ("Card"));
		Card generatedCard= gameObject.GetComponent<Card> ();
		string title = "new title";
		string text = "this is the card text";
		int attack = 2;
		int health = 2;

		generatedCard.setValues (title, text, attack, health);

		gameObject.transform.SetParent (this.transform);
	}

}
