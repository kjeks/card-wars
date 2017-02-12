using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceHandler : MonoBehaviour {

	Text gold;
	Text mana;
	// Use this for initialization
	void Start () {
		
		Text[] children = GetComponentsInChildren<Text> ();
		foreach (Text child in children) {
			if (child.name == "Gold") {
				gold = child;
			}
			if (child.name == "Mana") {
				mana = child;
			}
		}

		TurnController.setup += handleSetupPhase;
		TurnController.initialDraw += handleInitialPhase;
		TurnController.summary += handleSummaryPhase;

	}
	void handleSetupPhase () {
		Debug.Log ("ResourceHandler");
	}
	void handleInitialPhase () {
		setMana (10);
		setGold (10);
	}
	void handleSummaryPhase () {
		addMana (2);
		removeGold (2);
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
	public void setGold (int goldValue){
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
