using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public Text title;
	private Text text;
	public int attack;
	public int health;

	public Card setValues (string cardTitle, string cardText, int attack, int health) {
		Debug.Log (this);
	
		Text [] children = GetComponentsInChildren<Text> ();
		foreach (Text child in children) {
			Debug.Log (child.name);
			if (child.name == "card title") {
				title = child.GetComponent <Text> ();
				title.text = cardTitle;
			}
			if (child.name == "card description") {
				text = child.GetComponent <Text> ();
				text.text = cardText;
			}
		}

		return this.GetComponent<Card>();
	}

}
