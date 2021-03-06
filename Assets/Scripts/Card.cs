﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public Text title;
	private Text text;
	public Text attack;
	public Text health;
	public Text cost;
	public bool scouting;


	public Card setValues (string cardTitle, string cardText, int cardCost, int cardAttack, int cardHealth, Color color, Texture image, bool isScout) {
		Image cardColor = GetComponent<Image> ();
		cardColor.color = color;
		RawImage cardImage = GetComponentInChildren<RawImage> ();
		cardImage.texture = image;
		scouting = isScout;

		Text [] children = GetComponentsInChildren<Text> ();

		foreach (Text child in children) {
			if (child.name == "card title") {
				title = child.GetComponent <Text> ();
				title.text = cardTitle;
			}
			if (child.name == "card description") {
				text = child.GetComponent <Text> ();
				text.text = cardText;
			}
			if (child.name == "attack") {
				attack = child.GetComponent <Text> ();
				attack.text = cardAttack.ToString();
			}
			if (child.name == "health") {
				health = child.GetComponent <Text> ();
				health.text = cardHealth.ToString ();
			}
			if (child.name == "cost") {
				cost = child.GetComponent <Text> ();
				cost.text = cardCost.ToString ();
			}
		}
		return this.GetComponent<Card>();
	}
	void OnDisable () {
		TurnController.setup -= handleSetupPhase;
		TurnController.battle -= handleBattlePhase;
		TurnController.reaction -= handleReactionPhase;
	}
	public void handleSetupPhase () {
		
	}
	public void handleReactionPhase () {
		

	}
	public void handleBattlePhase () {
		
	}
	public int getGoldCost () {
		return int.Parse (cost.text);
	}

}
