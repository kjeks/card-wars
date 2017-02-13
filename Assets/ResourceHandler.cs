using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceHandler : MonoBehaviour {

	Text gold;
	Text mana;
	// Use this for initialization
	void Awake () {
		Text[] children = GetComponentsInChildren<Text> ();
		foreach (Text child in children) {
			if (child.name == "Gold") {
				gold = child;
			}
			if (child.name == "Mana") {
				mana = child;
			}
		}

		TurnController.initialDraw += handleInitialPhase;
		TurnController.summary += handleSummaryPhase;
		TurnController.draw += handleDrawPhase;
	}
	void handleDrawPhase () {
		addMana (1);
		addGold (3);
	}
	void handleInitialPhase () {
		setMana (5);
		setGold (10);
	}
	void handleSummaryPhase () {
		
	}
	public void handleMinionPlayed (int goldCost, int manaCost) {
		removeMana (1);
		removeGold (goldCost);
	}
	public bool canAffordCard (Card card) {
		return (getGold () >= card.getGoldCost() && getMana () >= 1);
	}

	public int getGold () {
		return int.Parse (gold.text);
	}
	public int getMana () {
		return int.Parse (mana.text);
	}
	public void setMana (int manaValue){
		mana.text = manaValue.ToString ();
	}
	public  void setGold (int goldValue){
		gold.text = goldValue.ToString ();
	}
	public void addGold (int addedValue) {
		gold.text = (int.Parse (gold.text) + addedValue).ToString ();
	}
	public void addMana (int addedValue) {
		mana.text = (int.Parse (mana.text) + addedValue).ToString ();
	}
	public void removeMana (int removedValue) {
		mana.text = (int.Parse (mana.text) - removedValue).ToString ();
	}
	public void removeGold (int removedValue) {
		gold.text = (int.Parse (gold.text) - removedValue).ToString ();
	}
}
