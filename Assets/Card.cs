using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public string title;
	private Text text;
	public int attack;
	public int health;



	void Start () {
		Text [] children = GetComponentsInChildren<Text> ();
		foreach (Text child in children) {
			Debug.Log (child.name);
			if (child.name == "card title") {
				text = child.GetComponent <Text> ();
			}
		}
		text.text = "test";
	}
}
